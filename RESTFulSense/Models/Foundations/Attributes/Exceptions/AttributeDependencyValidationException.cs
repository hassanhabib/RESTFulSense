// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Attributes.Exceptions
{
    public class AttributeDependencyValidationException : Xeption
    {
        public AttributeDependencyValidationException(Exception innerException)
            : base(
                message: "Attribute dependency validation error occurred, fix errors and try again.",
                innerException: innerException)
        { }

        public AttributeDependencyValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}