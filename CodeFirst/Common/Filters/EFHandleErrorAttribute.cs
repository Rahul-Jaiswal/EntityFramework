using EntityFramework.CodeFirst.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.CodeFirst.Common.Filters
{
    public class EFHandleErrorAttribute:HandleErrorAttribute
    {
        /// <summary>
        /// It is use for handle the exception which is come in controller
        /// </summary>
        /// <param name="filterContext">object of exception context</param>
        /// 

        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            if (filterContext.ExceptionHandled)
                return;

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
                return;

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
                return;

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = filterContext.Exception.Message
                };
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };

            }
            LogHelper.Error(filterContext);
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
        }
    }
}