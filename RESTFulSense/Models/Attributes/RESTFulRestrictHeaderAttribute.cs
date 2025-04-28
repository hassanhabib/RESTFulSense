// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RESTFulSense.Models.Attributes
{
    public sealed class RESTFulRestrictHeaderAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            actionExecutingContext.Result = actionExecutingContext.HttpContext.Request.Headers
                .TryGetValue(
                    key: this.Name, 
                    value: out var headerValue) switch
            {
                true when headerValue == this.Value => null,
                _ => new UnauthorizedResult()
            };
        }
    }
}
