// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.FormContents.Exceptions
{
    public class FormContentOrchestrationDependencyValidationException : Xeption
    {
        public FormContentOrchestrationDependencyValidationException(Xeption innerException)
            : base(message: "Form content validation error occurred, contact support.", innerException)
        { }
    }
}
