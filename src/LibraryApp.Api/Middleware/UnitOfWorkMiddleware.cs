using System.Net;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;
using System.Text.Json;
using LibraryApp.Api.Settings;
using LibraryApp.CrossCutting;
using LibraryApp.EntityFrameworkCore;

namespace LibraryApp.Api
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if(context.Request.Method.Equals(HttpMethod.Post.Method) || context.Request.Method.Equals(HttpMethod.Put.Method))
                {
                    using (var db = context.RequestServices.GetService<ApplicationContext>())
                    await db!.SaveChangesAsync();
                }
            } catch(Exception ex)
            {
                await HandleExceptionAsync(context ,ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception.InnerException != null)
            {
                await HandleExceptionAsync(context, exception.InnerException);
            }

            var code = HttpStatusCode.InternalServerError;

            var result = "Bir hata oluştu lütfen tekrar deneyin.";

            switch (exception)
            {
                case ApplicationException ex:
                    code = HttpStatusCode.BadRequest;
                    result = ex.Message;
                    break;
            }
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                var envelope = Envelope.BaseError(result);
                await context.Response.WriteAsJsonAsync(envelope);
            }
        }
    }
}