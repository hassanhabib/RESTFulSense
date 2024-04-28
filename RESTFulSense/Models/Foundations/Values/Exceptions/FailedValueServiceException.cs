// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class FailedValueServiceException : Xeption
    {
        public FailedValueServiceException(Exception innerException)
            : base(
                message: "Failed Value Service Exception occurred, please contact support for assistance.",
                innerException: innerException)
        { }

        public FailedValueServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}