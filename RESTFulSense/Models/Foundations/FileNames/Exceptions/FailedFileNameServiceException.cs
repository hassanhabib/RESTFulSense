// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.FileNames.Exceptions
{
    public class FailedFileNameServiceException : Xeption
    {
        public FailedFileNameServiceException(Exception innerException)
            : base(message: "Failed file name error occurred, contact support.",
                  innerException)
        { }
    }
}
