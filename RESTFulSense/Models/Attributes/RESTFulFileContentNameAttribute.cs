// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RESTFulFileContentNameAttribute : Attribute
    {
        public RESTFulFileContentNameAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}