// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Moq.Language;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
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

            IEnumerable<dynamic> randomPropertiesWithAttributesSequence =
                randomProperties.Where(property => property.Attribute != null);

            IEnumerable<dynamic> expectedPropertiesWithAttributesSequence =
                randomPropertiesWithAttributesSequence;

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            List<NamedStreamContent> outNamedStreamContents =
                expectedNamedStreamContents.DeepClone();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentNameAttribute> expectedRESTFulFileContentNameAttributes =
                randomProperties.Select(property => (RESTFulFileContentNameAttribute)property.Attribute)
                    .ToList();

            ISetupSequentialResult<RESTFulFileContentNameAttribute> attributeSequence =
                this.fileNameServiceMock.SetupSequence(service =>
                    service.RetrieveFileName(It.IsAny<PropertyInfo>()));

            attributeSequence = expectedPropertiesWithAttributesSequence.Aggregate(
               seed: attributeSequence,
               func: (sequence, property) => sequence.Returns(property.Attribute));

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
