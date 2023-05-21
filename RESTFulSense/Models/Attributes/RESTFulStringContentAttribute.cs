// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Models.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Property)]
    public sealed class RESTFulStringContentAttribute : Attribute
    {
        public RESTFulStringContentAttribute(string name, string mediaType = "text/plain", bool ignoreDefaultValues = false)
        {
            Name = name;
            MediaType = mediaType;
            IgnoreDefaultValues = ignoreDefaultValues;
        }

        public string Name { get; }

        public string MediaType { get; }

        public bool IgnoreDefaultValues { get; set; }
    }
}
