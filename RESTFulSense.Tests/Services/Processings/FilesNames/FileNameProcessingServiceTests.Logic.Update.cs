// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.FilesNames
{
    public partial class FileNameProcessingServiceTests
    {
        [Fact]
        public void ShouldUpdateFileNames()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();

            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(a => a.Attribute != null)
                    .Select(GetAttribute).ToList();

            var outNamedStreamContents = expectedNamedStreamContents.DeepClone();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentNameAttribute> expectedRESTFulFileContentNameAttributes =
                randomProperties.Select(a => (RESTFulFileContentNameAttribute)a.Attribute)
                    .ToList();

            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.fileNameServiceMock.Setup(service =>
                    service.RetrieveFileName(propertyInfo))
                        .Returns((RESTFulFileContentNameAttribute)property.Attribute);
            }

            // when
            this.fileNameProcessingService.UpdateFileNames(
                namedStreamContents: expectedNamedStreamContents,
                propertyValues: inputPropertyValues);

            // then
            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.fileNameServiceMock.Verify(service =>
                    service.RetrieveFileName(propertyInfo), Times.Once);
            }

            this.fileNameServiceMock.VerifyNoOtherCalls();
        }
    }
}
