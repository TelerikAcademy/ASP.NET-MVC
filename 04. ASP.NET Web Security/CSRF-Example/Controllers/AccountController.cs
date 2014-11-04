namespace CSRF_Example.Controllers
{
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using CSRF_Example.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    [Authorize]
    [ValidateInput(false)]
    public class AccountController : Controller
    {
        public AccountController()
        {
            this.IdentityManager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
        }

        public AccountController(AuthenticationIdentityManager manager)
        {
            this.IdentityManager = manager;
        }

        public AuthenticationIdentityManager IdentityManager { get; private set; }

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Validate the password
                IdentityResult result =
                    await
                    this.IdentityManager.Authentication.CheckPasswordAndSignInAsync(
                        this.AuthenticationManager,
                        model.UserName,
                        model.Password,
                        model.RememberMe);
                if (result.Success)
                {
                    return this.RedirectToLocal(returnUrl);
                }
                else
                {
                    this.AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a local login before signing in the user
                var user = new User(model.UserName);
                var result = await this.IdentityManager.Users.CreateLocalUserAsync(user, model.Password);
                if (result.Success)
                {
                    await
                        this.IdentityManager.Authentication.SignInAsync(this.AuthenticationManager, user.Id, isPersistent: false);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Account/Manage
        public async Task<ActionResult> Manage(string message)
        {
            ViewBag.StatusMessage = message ?? string.Empty;
            ViewBag.HasLocalPassword = await this.IdentityManager.Logins.HasLocalLoginAsync(User.Identity.GetUserId());
            ViewBag.ReturnUrl = Url.Action("Manage");
            return this.View();
        }

        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            string userId = User.Identity.GetUserId();
            bool hasLocalLogin = await this.IdentityManager.Logins.HasLocalLoginAsync(userId);
            ViewBag.HasLocalPassword = hasLocalLogin;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalLogin)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result =
                        await
                        this.IdentityManager.Passwords.ChangePasswordAsync(
                            User.Identity.GetUserName(),
                            model.OldPassword,
                            model.NewPassword);
                    if (result.Success)
                    {
                        return this.RedirectToAction("Manage", new { Message = "Your password has been changed." });
                    }
                    else
                    {
                        this.AddErrors(result);
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
                    IdentityResult result =
                        await
                        this.IdentityManager.Logins.AddLocalLoginAsync(
                            userId,
                            User.Identity.GetUserName(),
                            model.NewPassword);
                    if (result.Success)
                    {
                        return this.RedirectToAction("Manage", new { Message = "Your password has been set." });
                    }
                    else
                    {
                        this.AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.IdentityManager != null)
            {
                this.IdentityManager.Dispose();
                this.IdentityManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUrl)
            {
                this.LoginProvider = provider;
                this.RedirectUrl = redirectUrl;
            }

            public string LoginProvider { get; set; }

            public string RedirectUrl { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.GetOwinContext()
                    .Authentication.Challenge(
                        new AuthenticationProperties() { RedirectUrl = this.RedirectUrl },
                        this.LoginProvider);
            }
        }

        #endregion
    }
}