// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Forms.Exceptions
{
    public class InvalidFormArgumentException : Xeption
    {
        public InvalidFormArgumentException()
            : base(message: "Invalid form arguments. Please fix the errors and try again.")
        { }
        
        public InvalidFormArgumentException(string message)
            : base(message)
        { }
    }
}