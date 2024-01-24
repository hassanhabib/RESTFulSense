// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Exceptions
{
    public class HttpResponseVariantAlsoNegotiatesException : HttpResponseException
    {
        public HttpResponseVariantAlsoNegotiatesException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseVariantAlsoNegotiatesException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseVariantAlsoNegotiatesException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetails problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}
