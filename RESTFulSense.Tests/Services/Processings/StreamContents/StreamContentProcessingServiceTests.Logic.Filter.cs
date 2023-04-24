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
            IEnumerable<dynamic> allProperties = randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute);
            dynamic[] randomProperties = ShuffleRandomProperties(allProperties);

            IEnumerable<dynamic> randomPropertiesWithAttributesSequence =
                randomProperties.Where(property => property.Attribute != null);

            IEnumerable<dynamic> expectedPropertiesWithAttributesSequence =
                randomPropertiesWithAttributesSequence;

            List<NamedStreamContent> expectedNamedStreamContents =
                randomProperties.Where(property => property.Attribute != null)
                    .Select(GetAttribute).ToList();

            List<PropertyValue> randomPropertyValues =
                randomProperties.Select(ConvertToPropertyValue).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            List<RESTFulFileContentStreamAttribute> randomRESTFulStringContentAttributes =
                randomProperties.Select(property => (RESTFulFileContentStreamAttribute)property.Attribute)
                    .ToList();

            List<RESTFulFileContentStreamAttribute> expectedRESTFulStringContentAttributes =
                randomRESTFulStringContentAttributes;

            ISetupSequentialResult<RESTFulFileContentStreamAttribute> attributeSequence =
                this.streamContentServiceMock.SetupSequence(service =>
                    service.RetrieveStreamContent(It.IsAny<PropertyInfo>()));

            attributeSequence = expectedPropertiesWithAttributesSequence.Aggregate(
                seed: attributeSequence,
                func: (sequence, property) => sequence.Returns(property.Attribute));

            // when
            IEnumerable<NamedStreamContent> actualNamedStreamContent =
                this.streamContentProcessingService.FilterStreamContents(inputPropertyValues)
                    .ToList();

            // then
            actualNamedStreamContent.Should().BeEquivalentTo(expectedNamedStreamContents);

            foreach (dynamic property in randomProperties)
            {
                PropertyInfo propertyInfo = GetPropertyInfo(property);

                this.streamContentServiceMock.Verify(service =>
                    service.RetrieveStreamContent(propertyInfo), Times.Once);
            }

            this.streamContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
