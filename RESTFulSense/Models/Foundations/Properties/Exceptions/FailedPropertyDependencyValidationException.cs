// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class FailedPropertyDependencyValidationException : Xeption
    {
        public FailedPropertyDependencyValidationException(Exception innerException)
            : base(
                message: "Failed property dependency validation error occurred, fix errors and try again.",
                innerException: innerException)
        { }
        
        public FailedPropertyDependencyValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}