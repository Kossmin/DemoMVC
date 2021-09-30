using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.CustomAttribute
{
    public class CustomErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!
            Console.WriteLine(filterContext.Exception);

            //Redirect or return a view, but not both.
            filterContext.Result = new RedirectResult("Error.cshtml");
        }
    }
}