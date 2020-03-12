// Copyright (c) Hassan Habib.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseLoopDetectedException : HttpResponseException
    {
        public HttpResponseLoopDetectedException(HttpResponseMessage responseMessage)
            : base(responseMessage) { }
    }
}
