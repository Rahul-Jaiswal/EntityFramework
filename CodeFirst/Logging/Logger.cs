using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.CodeFirst.Logging
{
    /// <summary>
    /// This class is use for logging error in log file.
    /// </summary>
    public static class LogHelper
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Write exception in log file.
        /// </summary>
        /// <param name="filterContext">Object of ExceptionContext</param>
        public static void Error(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var message = new StringBuilder();
            message.Append(string.Format("\tControllerName-: {0}," + System.Environment.NewLine + "\tActionName-: {1}," + System.Environment.NewLine + "\tClassName-: {2}," + System.Environment.NewLine + "\tFunctionName-: {3}," + System.Environment.NewLine + "\tException-: {4}",
                controllerName,
                actionName,
                model.Exception.TargetSite.ReflectedType.FullName,
                model.Exception.TargetSite,
                model.Exception.Message.Replace("\n","\n\t")
                ));
            log.Error(message);
        }
    }
}