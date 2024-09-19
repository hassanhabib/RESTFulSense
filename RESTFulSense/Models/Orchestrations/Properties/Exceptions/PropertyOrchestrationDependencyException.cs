// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    internal class PropertyOrchestrationDependencyException : Xeption
    {
        public PropertyOrchestrationDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}