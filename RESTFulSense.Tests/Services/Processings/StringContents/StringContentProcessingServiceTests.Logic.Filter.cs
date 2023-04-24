// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Moq;
using Moq.Language;
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

            dynamic[] randomProperties = ShuffleRandomProperties(
                randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            IEnumerable<dynamic> randomPropertiesWithAttributesSequence =
                randomProperties.Where(property => property.Attribute != null);

            IEnumerable<dynamic> expectedPropertiesWithAttributesSequence =
                randomPropertiesWithAttributesSequence;

            List<NamedStringContent> expectedNamedStringContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(ConvertToPropertyValue).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulStringContentAttribute> randomRESTFulStringContentAttributes =
                randomProperties.Select(property => (RESTFulStringContentAttribute)property.Attribute)
                    .ToList();

            List<RESTFulStringContentAttribute> expectedRESTFulStringContentAttributes =
                randomRESTFulStringContentAttributes;

            ISetupSequentialResult<RESTFulStringContentAttribute> attributeSequence =
                this.stringContentServiceMock.SetupSequence(service =>
                    service.RetrieveStringContent(It.IsAny<PropertyInfo>()));

            attributeSequence = expectedPropertiesWithAttributesSequence.Aggregate(
                seed: attributeSequence,
                func: (sequence, property) => sequence.Returns(property.Attribute));

            // when
            IEnumerable<NamedStringContent> actualNamedStringContent =
                this.stringContentProcessingService.FilterStringContents(inputPropertyValues)
                    .ToList();

            // then
            actualNamedStringContent.Should().BeEquivalentTo(expectedNamedStringContents);

            foreach (dynamic property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);

                this.stringContentServiceMock.Verify(service =>
                    service.RetrieveStringContent(propertyInfo), Times.Once);
            }

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
