// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;

using Xeptions;

namespace RESTFulSense.Models.Exceptions
{
    public class HttpResponseException : Xeption
    {
        public HttpResponseException() { }

        public HttpResponseException(HttpResponseMessage httpResponseMessage, string message)
            : base(message) => HttpResponseMessage = httpResponseMessage;

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}
