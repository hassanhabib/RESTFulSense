// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.FileNames
{
    internal class FileNameService : IFileNameService
    {
        private readonly IReflectionBroker reflectionBroker;

        public FileNameService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public RESTFulFileContentNameAttribute RetrieveFileName(PropertyInfo somePropertyInfo) =>
            this.reflectionBroker.GetFileContentNameAttribute(somePropertyInfo);
    }
}
