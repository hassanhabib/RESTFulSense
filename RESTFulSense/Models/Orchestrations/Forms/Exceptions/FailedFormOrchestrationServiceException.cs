// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FailedFormOrchestrationServiceException : Xeption
    {
        public FailedFormOrchestrationServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}