using ECommerce.ServicesAbstractions.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_Commerce.Web.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ApiBaseController : ControllerBase
    {
        // ✅ For non-generic results (e.g., no return value)
        protected IActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
                return Ok(); // return 200 instead of 204

            return Problem(result.Errors);
        }

        // ✅ For generic results (e.g., Result<T>)
        protected ActionResult<TValue> HandleResult<TValue>(Result<TValue> result)
        {
            if (result.IsSuccess)
            {
                // ✅ Return the actual value inside Result<T>
                if (result.Value is not null)
                    return Ok(result.Value);

                return NoContent(); // in case the value is somehow null
            }

            return Problem(result.Errors);
        }

        private ActionResult Problem(IReadOnlyList<Error> errors)
        {
            if (errors.Count == 0)
                return Problem(statusCode: 500, title: "Unexpected Error");

            if (errors.All(e => e.Type == ErrorType.Validation))
                return HandleValidationProblem(errors);

            return HandleSingleErrorProblem(errors[0]);
        }

        private ActionResult HandleSingleErrorProblem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(
                statusCode: statusCode,
                title: error.Description,
                type: error.Code
            );
        }

        private ActionResult HandleValidationProblem(IReadOnlyList<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description
                );
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
