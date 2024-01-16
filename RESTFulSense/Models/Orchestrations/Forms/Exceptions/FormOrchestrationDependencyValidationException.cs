// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FormOrchestrationDependencyValidationException : Xeption
    {
        public FormOrchestrationDependencyValidationException(Xeption innerException)
            : base(
                message: "Form orchestration dependency validation error occurred, fix the errors and try again.",
                innerException: innerException)
        { }
        
        public FormOrchestrationDependencyValidationException(string message, Xeption innerException)
         : base(message, innerException)
        { }
    }
}