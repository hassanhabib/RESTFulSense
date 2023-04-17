// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.StringContents.Exceptions
{
    public class FailedStringContentProcessingServiceException : Xeption
    {
        public FailedStringContentProcessingServiceException(Exception innerException)
            : base(message: "Failed string content processing service error occurred, contact support.",
                   innerException)
        { }
    }
}
