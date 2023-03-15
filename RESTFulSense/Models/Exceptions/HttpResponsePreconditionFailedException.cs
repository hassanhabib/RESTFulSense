// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;

namespace RESTFulSense.Models.Exceptions
{
    public class HttpResponsePreconditionFailedException : HttpResponseException
    {
        public HttpResponsePreconditionFailedException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponsePreconditionFailedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponsePreconditionFailedException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            AddData((IDictionary)problemDetails.Errors);
        }
    }
}
