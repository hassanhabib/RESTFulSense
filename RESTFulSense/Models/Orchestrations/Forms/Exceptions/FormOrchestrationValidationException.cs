// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Forms.Exceptions
{
    internal class FormOrchestrationValidationException : Xeption
    {
        public FormOrchestrationValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}