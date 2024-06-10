// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FormCoordinationDependencyException : Xeption
    {
        public FormCoordinationDependencyException(string message, Xeption innerException)
         : base(message, innerException)
        { }
    }
}