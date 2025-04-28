// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Models.Attributes.RESTFulRestrictHeaderAttributes
{
    public partial class RESTFulRestrictHeaderAttributeTests
    {
        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static ActionContext CreateRandomActionContext(HttpContext httpContext)
        {
            var randomRouteData = new RouteData();
            var randomActionDescriptor = new ControllerActionDescriptor();

            return new ActionContext
            {
                HttpContext = httpContext,
                RouteData = randomRouteData,
                ActionDescriptor = randomActionDescriptor
            };
        }

        private static ActionExecutingContext CreateRandomActionExecutingContext(
            ActionContext actionContext)
        {
            var randomFilters = new List<IFilterMetadata>();
            var randomActionArguments = new Dictionary<string, object>();
            object nullController = null;

            return new ActionExecutingContext(
                actionContext,
                randomFilters,
                randomActionArguments,
                nullController);
        }
    }
}
