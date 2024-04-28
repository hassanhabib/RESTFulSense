// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FormOrchestrationValidationException : Xeption
    {
        public FormOrchestrationValidationException(Xeption innerException)
            : base(
                message: "Form orchestration validation errors occurred, please try again.",
                innerException: innerException)
        { }

        public FormOrchestrationValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}