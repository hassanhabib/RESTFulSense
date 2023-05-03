// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    internal class PropertyOrchestrationDependencyException : Xeption
    {
        public PropertyOrchestrationDependencyException(Exception innerException)
            : base(
                  message: "Property orchestration dependency error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
