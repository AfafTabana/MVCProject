using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCProject.Customfilters
{
    public class MyFilters : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // no implementation here 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // no implementation here  
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult 
            {
                ViewName = "CustomError" 
            };
            context.ExceptionHandled = true; 
        }
    }
}
