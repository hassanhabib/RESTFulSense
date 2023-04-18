// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.FileNames.Exceptions
{
    public class FailedFileNameProcessingServiceException : Xeption
    {
        public FailedFileNameProcessingServiceException(Exception innerException)
            : base(message: "Failed file name processing service error occurred, contact support.",
                   innerException)
        { }
    }
}
