// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.StreamContents.Exceptions
{
    public class FailedStreamContentProcessingServiceException : Xeption
    {
        public FailedStreamContentProcessingServiceException(Exception innerException)
            : base(message: "Failed stream content service error occurred, contact support.", innerException)
        { }
    }
}
