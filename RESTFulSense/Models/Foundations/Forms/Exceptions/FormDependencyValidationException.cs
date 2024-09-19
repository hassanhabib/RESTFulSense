// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FormDependencyValidationException : Xeption
    {
        public FormDependencyValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}