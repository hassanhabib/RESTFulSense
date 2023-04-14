// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace RESTFulSense.Models.Foundations.Properties
{
    internal class PropertyValue
    {
        public PropertyInfo PropertyInfo { get; set; }
        public object Value { get; set; }
    }
}
