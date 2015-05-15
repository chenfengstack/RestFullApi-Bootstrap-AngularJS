using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Net;
using Spartan.Framework.Log;
using Spartan.Api.Common;

namespace Spartan.Api.Filter
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            base.OnException(context);
            Logger.Log.Error(context.Exception.Message);
            Console.WriteLine(context.Exception.Message);
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new ErrorMessage { Message = "系统级别错误" });
        }
    }


}