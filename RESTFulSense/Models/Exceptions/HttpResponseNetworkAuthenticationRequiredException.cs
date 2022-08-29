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
    public class HttpResponseNetworkAuthenticationRequiredException : HttpResponseException
    {
        public HttpResponseNetworkAuthenticationRequiredException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseNetworkAuthenticationRequiredException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseNetworkAuthenticationRequiredException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
