// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.FileNames.Exceptions
{
    public class FileNameProcessingDependencyException : Xeption
    {
        public FileNameProcessingDependencyException(Xeption innerException)
            : base(message: "File name dependency error occurred, contact support.", innerException)
        { }
    }
}
