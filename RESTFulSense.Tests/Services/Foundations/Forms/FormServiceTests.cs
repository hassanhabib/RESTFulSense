// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Moq;
using RESTFulSense.Brokers.MultipartFormDataContents;
using RESTFulSense.Services.Foundations.Forms;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        private readonly Mock<IMultipartFormDataContentBroker> multipartFormDataContentBroker;
        private readonly IFormService formService;

        public FormServiceTests()
        {
            this.multipartFormDataContentBroker = new Mock<IMultipartFormDataContentBroker>();
            this.formService = new FormService(multipartFormDataContentBroker.Object);
        }
        private static MultipartFormDataContent CreateNullMultipartFormDataContent() => null;

        private static byte[] CreateSomeByteArrayContent() =>
            Encoding.UTF8.GetBytes(CreateRandomString());

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static MemoryStream CreateSomeStreamContent() =>
            new MemoryStream();

        private static MemoryStream CreateSomeStream() =>
            new MemoryStream();

        public static TheoryData GetAddExceptions()
        {
            return new TheoryData<Exception>()
            {
                new ArgumentException(),
                new ArgumentNullException(),
                new ArgumentOutOfRangeException()
            };
        }
    }
}
