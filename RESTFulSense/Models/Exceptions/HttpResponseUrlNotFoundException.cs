﻿// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Models.Exceptions
{
    public class HttpResponseUrlNotFoundException : HttpResponseException
    {
        public HttpResponseUrlNotFoundException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseUrlNotFoundException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}