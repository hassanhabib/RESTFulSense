// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.StreamContents.Exceptions
{
    public class StreamContentProcessingServiceException : Xeption
    {
        public StreamContentProcessingServiceException(Exception innerException)
            : base(message: "String stream service error occurred, contact support.",
                  innerException)
        { }
    }
}
