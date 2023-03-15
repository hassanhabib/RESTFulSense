// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Models.Exceptions
{
    public class HttpResponseRequestEntityTooLargeException : HttpResponseException
    {
        public HttpResponseRequestEntityTooLargeException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseRequestEntityTooLargeException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            AddData((IDictionary)problemDetails.Errors);
        }
    }
}
