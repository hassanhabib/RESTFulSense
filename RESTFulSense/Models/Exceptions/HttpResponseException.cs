﻿// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage httpResponseMessage, string message)
            : base(message) => this.HttpResponseMessage = httpResponseMessage;

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}
