// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormValidationException : Xeption
    {
        public FormValidationException(Xeption innerException)
            : base(message: "Form validation error occurred, fix errors and try again.", innerException)
        { }
    }
}
