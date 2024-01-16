// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException()
            : base(message: "Object is null.")
        { }
        
        public NullObjectException(string message)
            : base(message)
        { }
    }
}