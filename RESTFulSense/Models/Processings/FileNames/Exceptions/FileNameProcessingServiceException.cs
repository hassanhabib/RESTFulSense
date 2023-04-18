// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.FileNames.Exceptions
{
    public class FileNameProcessingServiceException : Xeption
    {
        public FileNameProcessingServiceException(Exception innerException)
            : base(message: "File name service error occurred, contact support.",
                  innerException)
        { }
    }
}
