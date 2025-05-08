// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Orchestrations.Properties.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}