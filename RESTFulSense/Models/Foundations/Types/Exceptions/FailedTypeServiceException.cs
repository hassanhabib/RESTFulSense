// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    public class FailedTypeServiceException : Xeption
    {
        public FailedTypeServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}