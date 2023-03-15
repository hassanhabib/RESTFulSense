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
    public class HttpResponseGoneException : HttpResponseException
    {
        public HttpResponseGoneException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseGoneException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseGoneException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            AddData((IDictionary)problemDetails.Errors);
        }
    }
}
