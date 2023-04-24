// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.StringContents.Exceptions
{
    public class StringContentProcessingServiceException : Xeption
    {
        public StringContentProcessingServiceException(Exception innerException)
            : base(message: "String content service error occurred, contact support.",
                  innerException)
        { }
    }
}
