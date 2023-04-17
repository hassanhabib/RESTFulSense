// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Processings.StringContents.Exceptions
{
    public class StringContentProcessingDependencyException : Xeption
    {
        public StringContentProcessingDependencyException(Xeption innerException)
            : base(message: "String content dependency error occurred, contact support.", innerException)
        { }
    }
}
