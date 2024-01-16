// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException(Exception innerException)
            : base(
                message: "Object is null, fix errors and try again.",
                innerException: innerException)
        { }
        
        public NullObjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}