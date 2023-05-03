// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    internal class FormCoordinationServiceException : Xeption
    {
        public FormCoordinationServiceException(Xeption innerException)
            : base(message: "Form coordination service error occurred, contact support.", innerException)
        { }
    }
}
