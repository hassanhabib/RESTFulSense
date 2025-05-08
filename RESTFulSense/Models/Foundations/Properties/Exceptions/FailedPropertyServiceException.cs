﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class FailedPropertyServiceException : Xeption
    {
        public FailedPropertyServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}