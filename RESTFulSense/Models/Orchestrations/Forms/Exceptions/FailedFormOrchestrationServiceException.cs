// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FailedFormOrchestrationServiceException : Xeption
    {
        public FailedFormOrchestrationServiceException(Exception innerException)
            : base(
                  message: "Failed form orchestration service occurred, please contact support",
                  innerException)
        { }
    }
}
