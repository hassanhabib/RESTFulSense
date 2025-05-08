// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Forms.Exceptions;
using RESTFulSense.Models.Foundations.Values.Exceptions;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Services.Foundations.Attributes;
using RESTFulSense.Services.Foundations.Forms;
using RESTFulSense.Services.Foundations.Values;
using RESTFulSense.Services.Orchestrations.Forms;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Forms
{
    public partial class FormOrchestrationServiceTests
    {
        private readonly Mock<IAttributeService> attributeServiceMock;
        private readonly Mock<IValueService> valueServiceMock;
        private readonly Mock<IFormService> formServiceMock;
        private readonly IFormOrchestrationService formOrchestrationService;

        public FormOrchestrationServiceTests()
        {
            this.attributeServiceMock = new Mock<IAttributeService>();
            this.valueServiceMock = new Mock<IValueService>();
            this.formServiceMock = new Mock<IFormService>();
            this.formOrchestrationService = new FormOrchestrationService(
                this.attributeServiceMock.Object,
                this.valueServiceMock.Object,
                this.formServiceMock.Object);
        }

        private static FormModel CreateRandomFormModel()
        {
            return new FormModel
            {
                Object = new object(),
                MultipartFormDataContent = new MultipartFormDataContent(),
            };
        }

        private static Attribute[] CreateRandomAttributes() =>
            Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(i => CreateRandomAttribute()).ToArray();

        private static Attribute CreateRandomAttribute() =>
            Shuffle(GetContentAttributes())
                .First();

        private static int GetBigRangeRandomNumber() =>
            new IntRange().GetValue();

        private static IEnumerable<T> Shuffle<T>(IEnumerable<T> source) =>
            source.OrderBy(a => GetBigRangeRandomNumber());

        private static IEnumerable<Attribute> GetContentAttributes()
        {
            yield return new RESTFulByteArrayContentAttribute(CreateRandomString());
            yield return new RESTFulStreamContentAttribute(CreateRandomString());
            yield return new RESTFulStringContentAttribute(CreateRandomString());
        }

        private static dynamic[] CreateTestData()
        {
            Attribute[] randomAttributes = CreateRandomAttributes();
            dynamic[] testData = randomAttributes.Select(attribute => new
            {
                Attribute = attribute,
                Content = CreateRandomContent(attribute)
            }).ToArray();

            return testData;
        }

        private static PropertyInfo[] CreateRandomProperties(dynamic[] testData) =>
            testData.Select(a => new Mock<PropertyInfo>().Object).ToArray();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 3, max: 10).GetValue();

        private static byte[] CreateRandomByteArray() =>
            Encoding.UTF8.GetBytes(CreateRandomString());

        private static object CreateRandomContent(Attribute attribute) =>
            attribute switch
            {
                RESTFulByteArrayContentAttribute => CreateRandomByteArray(),
                RESTFulStreamContentAttribute => new Mock<Stream>().Object,
                RESTFulStringContentAttribute => CreateRandomString(),
                _ => throw new NotImplementedException(),
            };

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        public static TheoryData DependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new AttributeValidationException(randomMessage,innerException),
                new AttributeDependencyValidationException(randomMessage,innerException),
                new ValueValidationException(randomMessage, innerException),
                new ValueDependencyValidationException(randomMessage, innerException),
                new FormValidationException(randomMessage,innerException),
                new FormDependencyValidationException(randomMessage, innerException)
            };
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new AttributeDependencyException(randomMessage, innerException),
                new AttributeServiceException(randomMessage,innerException),
                new ValueDependencyException(randomMessage, innerException),
                new ValueServiceException(randomMessage, innerException),
                new FormDependencyException(randomMessage,innerException),
                new FormServiceException(randomMessage, innerException)
            };
        }
    }
}
