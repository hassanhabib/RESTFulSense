// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Attributes.Exceptions
{
    public class AttributeDependencyValidationException : Xeption
    {
        public AttributeDependencyValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}