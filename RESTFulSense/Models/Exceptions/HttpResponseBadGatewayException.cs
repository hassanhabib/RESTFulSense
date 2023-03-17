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
    public class HttpResponseBadGatewayException : HttpResponseException
    {
        public HttpResponseBadGatewayException()
            : base(httpResponseMessage: default, message: default)
        { }

        public HttpResponseBadGatewayException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseBadGatewayException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
