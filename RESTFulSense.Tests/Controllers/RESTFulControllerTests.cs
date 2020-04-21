// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using RESTFulSense.Controllers;
using RESTFulSense.Models;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
    public class RESTFulControllerTests
    {
        private readonly IRESTFulController restfulController;

        public RESTFulControllerTests() => 
            this.restfulController = new RESTFulController();

        [Fact]
        public void ShouldReturnLockedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LockedObjectResult(inputMessage);

            // when
            LockedObjectResult actualResult = 
                this.restfulController.Locked(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnBadGatewayObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new BadGatewayObjectResult(inputMessage);

            // when
            BadGatewayObjectResult actualResult =
                this.restfulController.BadGateway(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnExpectationFailedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ExpectationFailedObjectResult(inputMessage);

            // when
            ExpectationFailedObjectResult actualResult =
                this.restfulController.ExpectationFailed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnFailedDependencyObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new FailedDependencyObjectResult(inputMessage);

            // when
            FailedDependencyObjectResult actualResult =
                this.restfulController.FailedDependency(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnGatewayTimeoutObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GatewayTimeoutObjectResult(inputMessage);

            // when
            GatewayTimeoutObjectResult actualResult =
                this.restfulController.GatewayTimeout(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnGoneObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GoneObjectResult(inputMessage);

            // when
            GoneObjectResult actualResult =
                this.restfulController.Gone(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnHttpVersionNotSupportedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            
            var expectedResult = 
                new HttpVersionNotSupportedObjectResult(inputMessage);

            // when
            HttpVersionNotSupportedObjectResult actualResult =
                this.restfulController.HttpVersionNotSupported(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnInsufficientStorageObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;

            var expectedResult =
                new InsufficientStorageObjectResult(inputMessage);

            // when
            InsufficientStorageObjectResult actualResult =
                this.restfulController.InsufficientStorage(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        private string GetRandomMessage() => new MnemonicString().GetValue();
    }
}
