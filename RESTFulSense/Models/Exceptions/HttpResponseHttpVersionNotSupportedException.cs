// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseHttpVersionNotSupportedException : HttpResponseException
    {
        public HttpResponseHttpVersionNotSupportedException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseHttpVersionNotSupportedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseHttpVersionNotSupportedException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
