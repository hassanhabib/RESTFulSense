// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FormCoordinationDependencyValidationException : Xeption
    {
        public FormCoordinationDependencyValidationException(string message, Xeption innerException)
         : base(message, innerException)
        { }
    }
}