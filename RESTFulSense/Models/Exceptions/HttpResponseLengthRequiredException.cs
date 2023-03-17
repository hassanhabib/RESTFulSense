// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseLengthRequiredException : HttpResponseException
    {
        public HttpResponseLengthRequiredException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseLengthRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseLengthRequiredException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
