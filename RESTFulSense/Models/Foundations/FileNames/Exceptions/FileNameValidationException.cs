// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.FileNames.Exceptions
{
    public class FileNameValidationException : Xeption
    {
        public FileNameValidationException(Xeption innerException)
            : base(message: "FileName validation error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
