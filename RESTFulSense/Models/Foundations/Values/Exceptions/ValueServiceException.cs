// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Values.Exceptions
{
    public class ValueServiceException : Xeption
    {
        public ValueServiceException(Xeption innerException)
            : base(message: "Value service error occurred, contact support.", innerException)
        { }
    }
}
