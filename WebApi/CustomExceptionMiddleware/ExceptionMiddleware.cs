using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly string connString;
        //private readonly ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next, string connectionString)
        {
            // _logger = logger;
            _next = next;
            connString = connectionString;

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {

                //_logger.LogError($"A new violation exception has been thrown: {avEx}");
                //_logger.LogInformation(avEx.Message);
                //_logger.LogInformation(avEx.StackTrace);
                //_logger.LogInformation(avEx.InnerException.ToString());
                SendExcepToDB(avEx);
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (InvalidException ivEx)
            {
                //_logger.LogInformation(ivEx.Message);
                //_logger.LogInformation(ivEx.StackTrace);
                //_logger.LogInformation(ivEx.InnerException.ToString());
                SendExcepToDB(ivEx);
                await HandleExceptionAsync(httpContext, ivEx);

            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                //_logger.LogInformation(ex.Message);
                //_logger.LogInformation(ex.StackTrace);
                //_logger.LogInformation(ex.InnerException.ToString());
                SendExcepToDB(ex);
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = string.Empty;
            message = exception switch
            {
                DivideByZeroException => "Divide By Zero",
                _ => "Internal Server Error from the custom middleware."
            };

            message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                _ => "Internal Server Error from the custom middleware."
            };
            message = exception switch
            {
                InvalidException => "Invalid exception error from the custom middleware.in",
                _ => "Internal Server Error from the custom middleware."
            };

            await context.Response.WriteAsync(new Error()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }

        public void SendExcepToDB(Exception exdb)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string exepurl = "test";
            SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", exepurl);
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
            com.ExecuteNonQuery();
        }
    }
}
