// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.StringContents.Exceptions
{
    internal class FailedStringContentServiceException : Xeption
    {
        public FailedStringContentServiceException(Exception innerException)
            : base(message: "Failed string content error occurred, contact support.",
                  innerException)
        { }
    }
}
