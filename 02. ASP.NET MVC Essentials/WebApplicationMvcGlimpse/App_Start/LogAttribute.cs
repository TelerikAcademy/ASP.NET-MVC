using System.Diagnostics;
using System.Web.Mvc;

namespace WebApplicationMvcGlimpse
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Trace.TraceInformation("OnActionExecuting() called!");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace.TraceInformation("OnActionExecuted() called!");
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Trace.TraceInformation("OnResultExecuting() called!");
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Trace.TraceInformation("OnResultExecuted() called!");
            base.OnResultExecuted(filterContext);
        }
    }
}