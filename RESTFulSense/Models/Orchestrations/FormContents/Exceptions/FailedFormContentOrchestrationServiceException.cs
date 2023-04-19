// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.FormContents.Exceptions
{
    public class FailedFormContentOrchestrationServiceException : Xeption
    {
        public FailedFormContentOrchestrationServiceException(Exception innerException)
            : base(message: "Failed form content service error occurred, contact support.", innerException)
        { }
    }
}
