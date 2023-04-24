// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.StringContents.Exceptions
{
    public class StringContentProcessingDependencyValidationException : Xeption
    {
        public StringContentProcessingDependencyValidationException(Xeption innerException)
            : base(message: "String content validation error occurred, contact support.", innerException)
        { }
    }
}
