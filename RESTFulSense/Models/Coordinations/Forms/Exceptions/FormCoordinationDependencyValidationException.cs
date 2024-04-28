// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FormCoordinationDependencyValidationException : Xeption
    {
        public FormCoordinationDependencyValidationException(Xeption innerException)
            : base(
                message: "Form coordination dependency validation error occurred, fix the errors and try again.",
                innerException: innerException)
        { }

        public FormCoordinationDependencyValidationException(string message, Xeption innerException)
         : base(message, innerException)
        { }
    }
}