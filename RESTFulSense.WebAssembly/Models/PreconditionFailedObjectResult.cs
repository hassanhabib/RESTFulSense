// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Http;

namespace RESTFulSense.WebAssembly.Models
{
    public class PreconditionFailedObjectResult : ObjectResult
    {
        public PreconditionFailedObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status412PreconditionFailed;
        }
    }
}
