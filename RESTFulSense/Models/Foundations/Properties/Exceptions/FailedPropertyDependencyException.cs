// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    internal class FailedPropertyDependencyException : Xeption
    {
        public FailedPropertyDependencyException(Exception innerException)
            : base(message: "Property dependency error occurred, contact support.", innerException)
        { }
    }
}
