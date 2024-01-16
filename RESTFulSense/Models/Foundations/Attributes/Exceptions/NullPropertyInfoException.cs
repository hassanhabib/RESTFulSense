// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Foundations.Attributes.Exceptions
{
    public class NullPropertyInfoException : Xeption
    {
        public NullPropertyInfoException(Exception innerException)
            : base(
                message: "PropertyInfo is null, fix errors and try again.",
                innerException: innerException)
        { }
        
        public NullPropertyInfoException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}