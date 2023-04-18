// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.FileNames.Exceptions
{
    public class FileNameProcessingDependencyValidationException : Xeption
    {
        public FileNameProcessingDependencyValidationException(Xeption innerException)
            : base(message: "File name validation error occurred, contact support.", innerException)
        { }
    }
}
