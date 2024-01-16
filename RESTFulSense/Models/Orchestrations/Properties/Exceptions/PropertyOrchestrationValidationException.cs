// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    internal class PropertyOrchestrationValidationException : Xeption
    {
        public PropertyOrchestrationValidationException(Exception innerException)
            : base(
                  message: "Property validation error occurred, fix errors and try again.",
                  innerException: innerException)
        { }
        
        public PropertyOrchestrationValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}