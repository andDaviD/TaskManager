using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManager.Web
{
    internal sealed class ModelValidationAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new CustomInvalidModelStateResponseFactory().Create(context);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}