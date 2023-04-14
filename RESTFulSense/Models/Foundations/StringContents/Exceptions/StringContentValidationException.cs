// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.StringContents.Exceptions
{
    public class StringContentValidationException : Xeption
    {
        public StringContentValidationException(Xeption innerException)
            : base(message: "StringContent validation error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
