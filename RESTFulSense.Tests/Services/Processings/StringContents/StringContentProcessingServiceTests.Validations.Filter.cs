// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using RESTFulSense.Models.Foundations.Properties;
using System.Collections.Generic;
using System;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using Xunit;
using System.Reflection;
using System.Linq;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Models.Processings.StringContents.Exceptions;
using FluentAssertions;

namespace RESTFulSense.Tests.Services.Processings.StringContents
{
    public partial class StringContentProcessingServiceTests
    {
        [Fact]
        public void ShouldThrowStringContentProcessingDependencyValidationExceptionIfStringContentValidationExceptionOccurs()
        {
            // given
            dynamic[] randomPropertiesNoAttribute = CreateRandomProperties();
            dynamic[] randomPropertiesWithAttribute = CreateRandomPropertiesWithAttributes();
            dynamic[] randomProperties =
                ShuffleRandomProperties(randomPropertiesNoAttribute.Union(randomPropertiesWithAttribute));

            PropertyInfo somePropertyInfo = CreateMockPropertyInfo();
            PropertyInfo inputPropertyInfo = somePropertyInfo;

            List<PropertyValue> randomPropertyValues =
                 randomProperties.Select(property => new PropertyValue
                 {
                     PropertyInfo = property.PropertyInfo,
                     Value = property.Value
                 }).ToList();

            List<PropertyValue> inputPropertyValues = randomPropertyValues;

            var nullPropertyInfoException = new NullPropertyInfoException();
            
            var stringContentValidationException =
                new StringContentValidationException(nullPropertyInfoException);
            
            var expectedStringContentProcessingDependencyValidationException =
                new StringContentProcessingDependencyValidationException(stringContentValidationException);
            
            this.stringContentServiceMock.Setup(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()))
                    .Throws(stringContentValidationException);

            // when
            Func<IEnumerable<NamedStringContent>> filterStringContentsFunction = () =>
               this.stringContentProcessingService.FilterStringContents(inputPropertyValues).ToList();

            StringContentProcessingDependencyValidationException actualStringContentProcessingDependencyValidationException =
               Assert.Throws<StringContentProcessingDependencyValidationException>(filterStringContentsFunction);

            // then
            actualStringContentProcessingDependencyValidationException.Should()
                .BeEquivalentTo(expectedStringContentProcessingDependencyValidationException);

            this.stringContentServiceMock.Verify(service =>
                service.RetrieveStringContent(It.IsAny<PropertyInfo>()), Times.Once);

            this.stringContentServiceMock.VerifyNoOtherCalls();
        }
    }
}
