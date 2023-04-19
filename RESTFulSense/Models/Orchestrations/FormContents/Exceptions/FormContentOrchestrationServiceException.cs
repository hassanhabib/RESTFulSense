// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.FormContents.Exceptions
{
    public class FormContentOrchestrationServiceException : Xeption
    {
        public FormContentOrchestrationServiceException(Exception innerException)
            : base(message: "Form content service error occurred, contact support.", innerException)
        { }
    }
}
