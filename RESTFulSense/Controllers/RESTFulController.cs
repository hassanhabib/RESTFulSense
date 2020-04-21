// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Models;

namespace RESTFulSense.Controllers
{
    public class RESTFulController : ControllerBase, IRESTFulController
    {
        public BadGatewayObjectResult BadGateway(object value) =>
            new BadGatewayObjectResult(value);

        public ExpectationFailedObjectResult ExpectationFailed(object value) =>
            new ExpectationFailedObjectResult(value);

        public FailedDependencyObjectResult FailedDependency(object value)
        {
            throw new System.NotImplementedException();
        }

        public LockedObjectResult Locked(object value) =>
            new LockedObjectResult(value);
    }
}
