// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    internal class FailedTypeDependencyException : Xeption
    {
        public FailedTypeDependencyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}