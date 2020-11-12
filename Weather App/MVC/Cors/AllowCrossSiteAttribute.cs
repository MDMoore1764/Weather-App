using Microsoft.AspNetCore.Mvc.Filters;

namespace Weather_App.MVC.Cors
{

    public class AllowCrossSiteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:3000");
           // filterContext.HttpContext.Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            filterContext.HttpContext.Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            filterContext.HttpContext.Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            base.OnActionExecuting(filterContext);
        }
    }
}
