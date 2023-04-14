// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class FailedPropertyServiceException : Xeption
    {
        public FailedPropertyServiceException(Exception innerException)
            : base(message: "Failed property error occurred, contact support.",
                  innerException)
        { }
    }
}
