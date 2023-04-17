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
using RESTFulSense.Models.Processings.StringContents;
using Xunit;

namespace RESTFulSense.Tests.Services.Processings.StringContents
{
    public partial class StringContentProcessingServiceTests
    {
        [Fact]
        public void ShouldFilterStringContents()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            List<PropertyInfo> randomPropertyInfos =
                randomProperties.Select(GetPropertyInfo).ToList();

            List<NamedStringContent> expectedNamedStringContents =
                randomProperties.Where(a => a.Attribute != null)
                    .Select(GetAttribute).ToList();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(property => new PropertyValue
                {
                    PropertyInfo = property.PropertyInfo,
                    Value = property.Value
                }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;
            List<RESTFulStringContentAttribute> expectedRESTFulStringContentAttributes =
                randomProperties.Select(a => (RESTFulStringContentAttribute)a.Attribute)
                    .ToList();

            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.stringContentServiceMock.Setup(service =>
                    service.RetrieveStringContent(propertyInfo))
                        .Returns((RESTFulStringContentAttribute)property.Attribute);
            }

            // when
            IEnumerable<NamedStringContent> actualNamedStringContent =
                this.stringContentProcessingService.FilterStringContents(inputPropertyValues)
                    .ToList();

            // then
            actualNamedStringContent.Should().BeEquivalentTo(expectedNamedStringContents);

            foreach (var property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);
                this.stringContentServiceMock.Verify(service =>
                    service.RetrieveStringContent(propertyInfo), Times.Once);
            }

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
