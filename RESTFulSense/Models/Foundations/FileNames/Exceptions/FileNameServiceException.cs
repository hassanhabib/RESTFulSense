// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.FileNames.Exceptions
{
    public class FileNameServiceException : Xeption
    {
        public FileNameServiceException(Xeption innerException)
            : base(message: "FileName service error occurred, contact support.",
                  innerException)
        { }
    }
}
