// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.FileNames
{
    internal partial class FileNameService : IFileNameService
    {
        private readonly IReflectionBroker reflectionBroker;

        public FileNameService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public RESTFulFileContentNameAttribute RetrieveFileName(PropertyInfo propertyInfo) =>
        TryCatch(() =>
        {
            ValidatePropertyInfo(propertyInfo);

            return this.reflectionBroker.GetFileContentNameAttribute(propertyInfo);
        });
    }
}
