using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
    //    public RequestDelegate requestDelegate;

    //    public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
    //    {
    //        this.requestDelegate = requestDelegate;
    //    }
    //    public async Task Invoke(HttpContext context)
    //    {
    //        try
    //        {
    //            await requestDelegate(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            //_logger.LogError($"Something went wrong: {ex}");
    //            await HandleException(context, ex);
    //        }
    //    }

      

    //    private static Task HandleException(HttpContext context, Exception ex)
    //    {
    //        var errorMessageObject = new Error { Message = ex.Message, Code = "GE" };
    //        var statusCode = (int)HttpStatusCode.InternalServerError;
    //        switch (ex)
    //        {
    //            case InvalidException:
    //                errorMessageObject.Code = "M001";
    //                statusCode = (int)HttpStatusCode.BadRequest;
    //                break;

    //        }

    //        var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

    //        context.Response.ContentType = "application/json";
    //        context.Response.StatusCode = statusCode;

    //        return context.Response.WriteAsync(errorMessage);
    //    }

      
    }
}
