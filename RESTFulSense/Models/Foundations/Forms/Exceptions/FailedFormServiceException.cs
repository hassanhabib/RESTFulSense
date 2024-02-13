// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class FailedFormServiceException : Xeption
    {
        public FailedFormServiceException(Exception innerException)
            : base(
                message: "Failed Form Service Exception occurred, please contact support for assistance.",
                innerException: innerException)
        { }
        
        public FailedFormServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}