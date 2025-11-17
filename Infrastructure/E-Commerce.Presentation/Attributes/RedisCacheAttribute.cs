using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace E_Commerce.Presentation.Attributes
{
    internal class RedisCacheAttribute(int durationInMins = 2)
        : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //GEgt Cache Using di
            var casheService = context.HttpContext.RequestServices.GetRequiredService<ICasheService>();
            //Create Cache Key Using QueryString and order them and RouteData
            string Key = GenerateCasheKey(context.HttpContext.Request);
            // Search in cache if exists return the cached response
            var casheValue = await casheService.GetAsync(Key);
            if (casheService is not null)
            {
                context.Result = new ContentResult
                {
                    Content = casheValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }
            var actionExecutedContext = await next.Invoke();
            var Result = actionExecutedContext.Result;
            //Check for OkObjectResult
            if (Result is OkObjectResult okObjectResult)
            {
                await casheService.SetAsync(Key, okObjectResult.Value!, TimeSpan.FromMinutes(durationInMins));
            }
            throw new NotImplementedException();
        }

        private static string GenerateCasheKey(HttpRequest httpRequest)
        {
            var keyBuilder = new StringBuilder();
            foreach (var Kvp in httpRequest.Query.OrderBy(q => q.Key))
            {
                keyBuilder.Append($"{Kvp.Key}-{Kvp.Value}-");
            }
            return keyBuilder.ToString().Trim('-');
        }
    }
}
