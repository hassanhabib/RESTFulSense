using System;

namespace RESTFulSense.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RESTFulFileContentNameAttribute : Attribute
    {
        public RESTFulFileContentNameAttribute()
            : this(name: null)
        { }

        public RESTFulFileContentNameAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}