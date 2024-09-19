// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class FailedAttributeServiceException : Xeption
    {
        public FailedAttributeServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}