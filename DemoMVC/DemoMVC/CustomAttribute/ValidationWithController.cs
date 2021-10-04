using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.CustomAttribute
{
    public class ValidationWithController : FilterAttribute, IActionFilter 
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tmp = filterContext.ActionParameters;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}