// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Moq;
using RESTFulSense.Brokers.Types;
using RESTFulSense.Services.Types;
using Tynamix.ObjectFiller;
using Xeptions;

namespace RESTFulSense.Tests.Services.Foundations.Types
{
    public partial class TypeServiceTests
    {
        private readonly Mock<ITypeBroker> typeBrokerMock;
        private readonly ITypeService typeService;

        public TypeServiceTests()
        {
            this.typeBrokerMock = new Mock<ITypeBroker>();
            this.typeService = new TypeService(this.typeBrokerMock.Object);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { null };
            yield return new object[] { typeof(DateTime) };
            yield return new object[] { typeof(int) };
            yield return new object[] { typeof(long) };
            yield return new object[] { typeof(object) };
            yield return new object[] { typeof(Stream) };
            yield return new object[] { typeof(string) };
            yield return new object[] { typeof(TestClass) };
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        public static IEnumerable<object[]> GetDependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            yield return new object[] { new ArgumentNullException(message: randomMessage, innerException) };
        }

        public static IEnumerable<object[]> GetDependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            yield return new object[] { new MethodAccessException(message: randomMessage, innerException) };
            yield return new object[] { new TargetInvocationException(message: randomMessage, innerException) };
            yield return new object[] { new TypeLoadException(message: randomMessage, innerException) };
            yield return new object[] { new NotSupportedException(message: randomMessage, innerException) };
            yield return new object[] { new MissingMethodException(message: randomMessage, innerException) };
        }

        public class TestClass
        { }
    }
}
