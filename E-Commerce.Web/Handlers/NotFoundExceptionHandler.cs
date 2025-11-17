using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Handlers
{
    public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex,
            CancellationToken cancellationToken)
        {
            if (ex is NotFoundExceptions notFound)
            {
                logger.LogError("Something Went Wrong {Message}", notFound.Message);
                var problem = new ProblemDetails
                {
                    Title = "Error Processing the Http Request",
                    Detail = notFound.Message,
                    Status = notFound switch
                    {
                        NotFoundExceptions => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    },
                    Instance = context.Request.Scheme + context.Request.Host + context.Request.Path,
                };
                context.Response.StatusCode = problem.Status.Value;

                await context.Response.WriteAsJsonAsync(problem);
                return true;
            }
            return false;
        }
    }
}
