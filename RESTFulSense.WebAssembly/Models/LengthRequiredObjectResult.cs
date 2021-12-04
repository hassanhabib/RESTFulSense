// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Http;

namespace RESTFulSense.WebAssembly.Models
{
    public class LengthRequiredObjectResult : ObjectResult
    {
        public LengthRequiredObjectResult(object value) : base(value) =>
            StatusCode = StatusCodes.Status411LengthRequired;
    }
}
