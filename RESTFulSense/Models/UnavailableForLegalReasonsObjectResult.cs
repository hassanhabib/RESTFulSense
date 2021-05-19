// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTFulSense.Models
{
    public class UnavailableForLegalReasonsObjectResult : ObjectResult
    {
        public UnavailableForLegalReasonsObjectResult(object value) : base(value) =>
            StatusCode = StatusCodes.Status451UnavailableForLegalReasons;
    }
}