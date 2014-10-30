using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Parameter_Tampering_Demo.Models;

namespace Parameter_Tampering_Demo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController() 
        {
            IdentityManager = new AuthenticationIdentityManager(
                new IdentityStore(new ApplicationDbContext()));
        }

        public AccountController(AuthenticationIdentityManager manager)
        {
            IdentityManager = manager;
        }

        public AuthenticationIdentityManager IdentityManager { get; private set; }

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Validate the password
                IdentityResult result = await IdentityManager.Authentication.CheckPasswordAndSignInAsync(
                    AuthenticationManager, model.UserName, model.Password, model.RememberMe);
                if (result.Success)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a local login before signing in the user
                var user = new ApplicationUser();
                user.UserName = model.UserName;
                var result = await IdentityManager.Users.CreateLocalUserAsync(user, model.Password);
                if (result.Success)
                {
                    await IdentityManager.Authentication.SignInAsync(
                        AuthenticationManager, user.Id, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Manage
        public async Task<ActionResult> Manage(string message)
        {
            ViewBag.StatusMessage = message ?? "";
            ViewBag.HasLocalPassword = await IdentityManager.Logins.HasLocalLoginAsync(User.Identity.GetUserId());
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            string userId = User.Identity.GetUserId();
            bool hasLocalLogin = await IdentityManager.Logins.HasLocalLoginAsync(userId);
            ViewBag.HasLocalPassword = hasLocalLogin;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalLogin)
            {               
                if (ModelState.IsValid)
                {
                    IdentityResult result = await IdentityManager.Passwords.ChangePasswordAsync(User.Identity.GetUserName(), model.OldPassword, model.NewPassword);
                    if (result.Success)
                    {
                        return RedirectToAction("Manage", new { Message = "Your password has been changed." });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    // Create the local login info and link it to the user
                    IdentityResult result = await IdentityManager.Logins.AddLocalLoginAsync(userId, User.Identity.GetUserName(), model.NewPassword);
                    if (result.Success)
                    {
                        return RedirectToAction("Manage", new { Message = "Your password has been set." });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            return Task.Run(async () =>
            {
                var linkedAccounts = new List<IUserLogin>(await IdentityManager.Logins.GetLoginsAsync(User.Identity.GetUserId()));
                ViewBag.ShowRemoveButton = linkedAccounts.Count > 1;
                return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
            }).Result;
        }

        protected override void Dispose(bool disposing) {
            if (disposing && IdentityManager != null) {
                IdentityManager.Dispose();
                IdentityManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUrl)
            {
                LoginProvider = provider;
                RedirectUrl = redirectUrl;
            }

            public string LoginProvider { get; set; }
            public string RedirectUrl { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties() { RedirectUrl = RedirectUrl }, LoginProvider);
            }
        }
        #endregion
    }
}