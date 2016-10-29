using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class shareDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["Temp"] = "Test";
        }
    }
}