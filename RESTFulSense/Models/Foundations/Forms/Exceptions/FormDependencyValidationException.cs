// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormDependencyValidationException : Xeption
    {
        public FormDependencyValidationException(Exception innerException)
            : base(
                message: "Form dependency validation error occurred, fix errors and try again.",
                innerException: innerException)
        { }

        public FormDependencyValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}