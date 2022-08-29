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
    public class HttpResponseInternalServerErrorException : HttpResponseException
    {
        public HttpResponseInternalServerErrorException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseInternalServerErrorException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseInternalServerErrorException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
