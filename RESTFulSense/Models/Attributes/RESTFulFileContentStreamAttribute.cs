// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Models.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Property)]
    public class RESTFulFileContentStreamAttribute : Attribute
    {
        public RESTFulFileContentStreamAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}
