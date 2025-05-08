// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class FailedValueServiceException : Xeption
    {
        public FailedValueServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}