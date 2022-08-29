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
    public class HttpResponseUnprocessableEntityException : HttpResponseException
    {
        public HttpResponseUnprocessableEntityException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseUnprocessableEntityException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseUnprocessableEntityException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
