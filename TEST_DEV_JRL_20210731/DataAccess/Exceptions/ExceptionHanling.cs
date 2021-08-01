using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TEST_DEV_JRL_20210731.DataAccess.Dto.Output;

namespace TEST_DEV_JRL_20210731.DataAccess.Exceptions
{
    public class ExceptionHanling : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is SystemValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Result = new ObjectResult(new ResponseResult()
                {
                    Message = exception.Message
                });
            }

            base.OnException(context);
        }
    }
}
