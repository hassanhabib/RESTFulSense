// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormValidationException : Xeption
    {
        public FormValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}