// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Http;

namespace RESTFulSense.WebAssembly.Models
{
    public class TooManyRequestsObjectResult : ObjectResult
    {
        public TooManyRequestsObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status429TooManyRequests;
        }
    }
}