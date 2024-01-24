// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Exceptions
{
    public class HttpResponseInsufficientStorageException : HttpResponseException
    {
        public HttpResponseInsufficientStorageException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseInsufficientStorageException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseInsufficientStorageException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
