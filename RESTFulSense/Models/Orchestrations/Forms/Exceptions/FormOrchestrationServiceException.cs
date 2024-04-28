// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FormOrchestrationServiceException : Xeption
    {
        public FormOrchestrationServiceException(Xeption innerException)
            : base(
                message: "Form orchestration service error occurred, contact support.",
                innerException: innerException)
        { }

        public FormOrchestrationServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}