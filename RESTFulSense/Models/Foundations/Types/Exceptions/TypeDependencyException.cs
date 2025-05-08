﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Types.Exceptions
{
    internal class TypeDependencyException : Xeption
    {
        public TypeDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}