// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormServiceException : Xeption
    {
        public FormServiceException(Xeption innerException)
            : base(
                message: "Form service error occurred, contact support.",
                innerException: innerException)
        { }
        
        public FormServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}