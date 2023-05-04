// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FormCoordinationDependencyException : Xeption
    {
        public FormCoordinationDependencyException(Xeption innerException)
         : base(
                message: "Form coordination dependency error occurred, fix the errors and try again.",
                innerException)
        { }
    }
}
