// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseRequestTimeoutException : HttpResponseException
    {
        public HttpResponseRequestTimeoutException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
