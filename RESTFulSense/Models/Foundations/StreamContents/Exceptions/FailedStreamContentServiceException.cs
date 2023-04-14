// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.StreamContents.Exceptions
{
    public class FailedStreamContentServiceException : Xeption
    {
        public FailedStreamContentServiceException(Exception innerException)
            : base(message: "Failed stream content error occurred, contact support.",
                  innerException)
        { }
    }
}
