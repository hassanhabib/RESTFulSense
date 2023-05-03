// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    public class FailedTypeServiceException : Xeption
    {
        public FailedTypeServiceException(Exception innerException)
            : base(message: "Failed Type Service Exception occurred, please contact support for assistance.",
                  innerException)
        { }
    }
}
