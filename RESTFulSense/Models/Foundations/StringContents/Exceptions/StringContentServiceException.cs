// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.StringContents.Exceptions
{
    internal class StringContentServiceException : Xeption
    {
        public StringContentServiceException(Xeption innerException)
            : base(message: "StringContent service error occurred, contact support.",
                  innerException)
        { }
    }
}
