// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Exceptions
{
    public class HttpResponseServiceUnavailableException : HttpResponseException
    {
        public HttpResponseServiceUnavailableException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseServiceUnavailableException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
