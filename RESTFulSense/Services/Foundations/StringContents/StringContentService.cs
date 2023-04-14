// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.StringContents
{
    internal class StringContentService : IStringContentService
    {
        private readonly IReflectionBroker reflectionBroker;

        public StringContentService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public RESTFulStringContentAttribute RetrieveStringContent(PropertyInfo propertyInfo) =>
            throw new System.NotImplementedException();
    }
}
