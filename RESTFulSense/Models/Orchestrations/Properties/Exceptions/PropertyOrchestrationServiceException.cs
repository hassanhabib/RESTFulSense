﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    public class PropertyOrchestrationServiceException : Xeption
    {
        public PropertyOrchestrationServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}