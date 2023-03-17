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
    public class HttpResponseLoopDetectedException : HttpResponseException
    {
        public HttpResponseLoopDetectedException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseLoopDetectedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseLoopDetectedException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
