// Copyright (c) Hassan Habib.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseNotFoundException : HttpResponseException
    {
        public HttpResponseNotFoundException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
