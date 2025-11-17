using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Middlewares
{
    public class GlobalExceptionHandler(RequestDelegate next
        , ILogger<GlobalExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                await HandleNotFoundEndPointAsync(context);

            }
            catch (Exception ex)
            {
                logger.LogError("Something Went Wrong {Message}", ex.Message);
                var problem = new ProblemDetails
                {
                    Title = "Error Processing the Http Request",
                    Detail = ex.Message,
                    Status = ex switch
                    {
                        NotFoundExceptions => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    },
                    Instance = context.Request.Scheme + context.Request.Host + context.Request.Path,
                };
                context.Response.StatusCode = problem.Status.Value;

                await context.Response.WriteAsJsonAsync(problem);

            }
        }

        private async Task HandleNotFoundEndPointAsync(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var problem = new ProblemDetails
                {
                    Title = "Error processing the Current Endpoint Not Found",
                    Detail = $"EndPoint {context.Request.Scheme + context.Request.Host + context.Request.Path} Not Found",
                    Instance = context.Request.Scheme + context.Request.Host + context.Request.Path,
                    Status = StatusCodes.Status404NotFound,
                };
                try
                {
                    await context.Response.WriteAsJsonAsync(problem);
                }
                catch (IOException ioEx)
                {
                    logger.LogWarning(ioEx, "Client disconnected before response was fully sent.");
                }
            }
        }
    }
    public static class GlobalExceptionHandlerExtentions
    {
        public static WebApplication UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
            return app;
        }
    }
}
