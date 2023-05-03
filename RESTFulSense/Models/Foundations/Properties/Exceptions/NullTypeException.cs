// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    internal class NullTypeException : Xeption
    {
        public NullTypeException()
            : base(message: "Type is null.")
        { }
    }
}
