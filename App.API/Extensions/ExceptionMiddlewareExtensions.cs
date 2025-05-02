using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Models.ErrorModels;
using Models.Exceptions;
using Services.Contracts;

namespace App.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,ILoggingService looger)
        {
            app.UseExceptionHandler(e =>
            {
                e.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        looger.LogError($"Something went wrong {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later."
                        }.ToString());
                    }
                });
            });
        }

    }
}
