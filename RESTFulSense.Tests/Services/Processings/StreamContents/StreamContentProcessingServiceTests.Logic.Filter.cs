// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.StreamContents
{
    public partial class StreamContentProcessingServiceTests
    {
        [Fact]
        public void ShouldFilterStreamContents()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(a => a.Attribute != null)
                    .Select(GetAttribute).ToList();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Object
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;
            List<RESTFulFileContentStreamAttribute> expectedRESTFulFileContentStreamAttributes =
                randomProperties.Select(a => (RESTFulFileContentStreamAttribute)a.Attribute)
                    .ToList();

            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.streamContentServiceMock.Setup(service =>
                    service.RetrieveStreamContent(propertyInfo))
                        .Returns((RESTFulFileContentStreamAttribute)property.Attribute);
            }

            // when
            IEnumerable<NamedStreamContent> actualNamedStreamContents =
                this.streamContentProcessingService.FilterStringContents(inputPropertyValues)
                    .ToList();

            // then
            actualNamedStreamContents.Should().BeEquivalentTo(expectedNamedStreamContents);

            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.streamContentServiceMock.Verify(service =>
                    service.RetrieveStreamContent(propertyInfo), Times.Once);
            }

            this.streamContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
