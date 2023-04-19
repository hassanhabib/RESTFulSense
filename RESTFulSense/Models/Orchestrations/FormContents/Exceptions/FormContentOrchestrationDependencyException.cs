// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.FormContents.Exceptions
{
    public class FormContentOrchestrationDependencyException : Xeption
    {
        public FormContentOrchestrationDependencyException(Xeption innerException)
            : base(message: "Form content dependency error occurred, contact support.", innerException)
        { }
    }
}
