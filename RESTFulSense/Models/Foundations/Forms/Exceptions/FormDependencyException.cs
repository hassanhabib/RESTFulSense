// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormDependencyException : Xeption
    {
        public FormDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}