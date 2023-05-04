// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FormCoordinationValidationException : Xeption
    {
        public FormCoordinationValidationException(Xeption innerException)
            : base(
                message: "Form coordination validation errors occurred, please try again.",
                innerException)
        { }
    }
}
