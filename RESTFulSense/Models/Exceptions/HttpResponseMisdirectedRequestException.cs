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
    public class HttpResponseMisdirectedRequestException : HttpResponseException
    {
        public HttpResponseMisdirectedRequestException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseMisdirectedRequestException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseMisdirectedRequestException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
