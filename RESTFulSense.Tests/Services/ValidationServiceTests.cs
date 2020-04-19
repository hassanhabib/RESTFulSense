// Copyright (c) Hassan Habib.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using RESTFulSense.Exceptions;
using RESTFulSense.Services;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Services
{
    public class ValidationServiceTests
    {
        [Fact]
        public async Task ShouldThrowHttpResponseBadRequestExceptionIfResponseStatusCodeWasBadRequest()
        {
            // given
            string randomContent = GetrRandomContent();
            string content = randomContent;
            string expectedExceptionMessage = content;
            var badRequestResponseMessage = CreateHttpResponseMessage(HttpStatusCode.BadRequest, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(badRequestResponseMessage);

            // then
            HttpResponseBadRequestException httpResponseBadRequestException =
                await Assert.ThrowsAsync<HttpResponseBadRequestException>(() => 
                    validateHttpResponseTask.AsTask()); ;

            httpResponseBadRequestException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        }

        [Fact]
        public async Task ShouldThrowHttpResponseUnauthorizedExceptionIfResponseStatusCodeWasUnauthorized()
        {
            // given
            string randomContent = GetrRandomContent();
            string content = randomContent;
            string expectedExceptionMessage = content;
            var unauthorizedResponseMessage = CreateHttpResponseMessage(HttpStatusCode.Unauthorized, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(unauthorizedResponseMessage);

            // then
            HttpResponseUnauthorizedException httpResponseUnauthorizedException =
                await Assert.ThrowsAsync<HttpResponseUnauthorizedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUnauthorizedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        }

        [Fact]
        public void ShouldThrowHttpResponsePaymentRequiredExceptionIfResponseStatusCodeWasPaymentRequired()
        {
            // given
            var paymentRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.PaymentRequired);

            // when . then
            Assert.Throws<HttpResponsePaymentRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(paymentRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseForbiddenExceptionIfResponseStatusCodeWasForbidden()
        {
            // given
            var forbiddenResponseMessage = new HttpResponseMessage(HttpStatusCode.Forbidden);

            // when . then
            Assert.Throws<HttpResponseForbiddenException>(() =>
                ValidationService.ValidateHttpResponseAsync(forbiddenResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotFoundExceptionIfResponseStatusCodeWasNotFound()
        {
            // given
            var notFoundResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);

            // when . then
            Assert.Throws<HttpResponseNotFoundException>(() =>
                ValidationService.ValidateHttpResponseAsync(notFoundResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseMethodNotAllowedExceptionIfResponseStatusCodeWasMethodNotAllowed()
        {
            // given
            var methodNotAllowedResponseMessage = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);

            // when . then
            Assert.Throws<HttpResponseMethodNotAllowedException>(() =>
                ValidationService.ValidateHttpResponseAsync(methodNotAllowedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotAcceptableExceptionIfResponseStatusCodeWasNotAcceptable()
        {
            // given
            var notAcceptableResponseMessage = new HttpResponseMessage(HttpStatusCode.NotAcceptable);

            // when . then
            Assert.Throws<HttpResponseNotAcceptableException>(() =>
                ValidationService.ValidateHttpResponseAsync(notAcceptableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseProxyAuthenticationRequiredExceptionIfResponseStatusCodeWasProxyAuthenticationRequired()
        {
            // given
            var proxyAuthenticationRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.ProxyAuthenticationRequired);

            // when . then
            Assert.Throws<HttpResponseProxyAuthenticationRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(proxyAuthenticationRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestTimeoutExceptionIfResponseStatusCodeWasRequestTimeout()
        {
            // given
            var requestTimeoutResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestTimeout);

            // when . then
            Assert.Throws<HttpResponseRequestTimeoutException>(() =>
                ValidationService.ValidateHttpResponseAsync(requestTimeoutResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseConflictExceptionIfResponseStatusCodeWasConflict()
        {
            // given
            var conflictResponseMessage = new HttpResponseMessage(HttpStatusCode.Conflict);

            // when . then
            Assert.Throws<HttpResponseConflictException>(() =>
                ValidationService.ValidateHttpResponseAsync(conflictResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseGoneExceptionIfResponseStatusCodeWasGone()
        {
            // given
            var goneResponseMessage = new HttpResponseMessage(HttpStatusCode.Gone);

            // when . then
            Assert.Throws<HttpResponseGoneException>(() =>
                ValidationService.ValidateHttpResponseAsync(goneResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLengthRequiredExceptionIfResponseStatusCodeWasLengthRequired()
        {
            // given
            var lengthRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.LengthRequired);

            // when . then
            Assert.Throws<HttpResponseLengthRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(lengthRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponsePreconditionFailedExceptionIfResponseStatusCodeWasPreconditionFailed()
        {
            // given
            var preconditionFailedResponseMessage = new HttpResponseMessage(HttpStatusCode.PreconditionFailed);

            // when . then
            Assert.Throws<HttpResponsePreconditionFailedException>(() =>
                ValidationService.ValidateHttpResponseAsync(preconditionFailedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestEntityTooLargeExceptionIfResponseStatusCodeWasRequestEntityTooLarge()
        {
            // given
            var requestEntityTooLargeResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestEntityTooLarge);

            // when . then
            Assert.Throws<HttpResponseRequestEntityTooLargeException>(() =>
                ValidationService.ValidateHttpResponseAsync(requestEntityTooLargeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestUriTooLongExceptionIfResponseStatusCodeWasRequestUriTooLong()
        {
            // given
            var requestUriTooLongResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestUriTooLong);

            // when . then
            Assert.Throws<HttpResponseRequestUriTooLongException>(() =>
                ValidationService.ValidateHttpResponseAsync(requestUriTooLongResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnsupportedMediaTypeExceptionIfResponseStatusCodeWasUnsupportedMediaType()
        {
            // given
            var unsupportedMediaTypeResponseMessage = new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            // when . then
            Assert.Throws<HttpResponseUnsupportedMediaTypeException>(() =>
                ValidationService.ValidateHttpResponseAsync(unsupportedMediaTypeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestedRangeNotSatisfiableExceptionIfResponseStatusCodeWasRequestedRangeNotSatisfiable()
        {
            // given
            var requestedRangeNotSatisfiableResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable);

            // when . then
            Assert.Throws<HttpResponseRequestedRangeNotSatisfiableException>(() =>
                ValidationService.ValidateHttpResponseAsync(requestedRangeNotSatisfiableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseExpectationFailedExceptionIfResponseStatusCodeWasExpectationFailed()
        {
            // given
            var expectationFailedResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);

            // when . then
            Assert.Throws<HttpResponseExpectationFailedException>(() =>
                ValidationService.ValidateHttpResponseAsync(expectationFailedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseMisdirectedRequestExceptionIfResponseStatusCodeWasMisdirectedRequest()
        {
            // given
            var misdirectedRequestResponseMessage = new HttpResponseMessage(HttpStatusCode.MisdirectedRequest);

            // when . then
            Assert.Throws<HttpResponseMisdirectedRequestException>(() =>
                ValidationService.ValidateHttpResponseAsync(misdirectedRequestResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnprocessableEntityExceptionIfResponseStatusCodeWasUnprocessableEntity()
        {
            // given
            var unprocessableEntityResponseMessage = new HttpResponseMessage(HttpStatusCode.UnprocessableEntity);

            // when . then
            Assert.Throws<HttpResponseUnprocessableEntityException>(() =>
                ValidationService.ValidateHttpResponseAsync(unprocessableEntityResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLockedExceptionIfResponseStatusCodeWasLocked()
        {
            // given
            var lockedResponseMessage = new HttpResponseMessage(HttpStatusCode.Locked);

            // when . then
            Assert.Throws<HttpResponseLockedException>(() =>
                ValidationService.ValidateHttpResponseAsync(lockedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseFailedDependencyExceptionIfResponseStatusCodeWasFailedDependency()
        {
            // given
            var failedDependencyResponseMessage = new HttpResponseMessage(HttpStatusCode.FailedDependency);

            // when . then
            Assert.Throws<HttpResponseFailedDependencyException>(() =>
                ValidationService.ValidateHttpResponseAsync(failedDependencyResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUpgradeRequiredExceptionIfResponseStatusCodeWasUpgradeRequired()
        {
            // given
            var upgradeRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.UpgradeRequired);

            // when . then
            Assert.Throws<HttpResponseUpgradeRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(upgradeRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponsePreconditionRequiredExceptionIfResponseStatusCodeWasPreconditionRequired()
        {
            // given
            var preconditionRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.PreconditionRequired);

            // when . then
            Assert.Throws<HttpResponsePreconditionRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(preconditionRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseTooManyRequestsExceptionIfResponseStatusCodeWasTooManyRequests()
        {
            // given
            var tooManyRequestsResponseMessage = new HttpResponseMessage(HttpStatusCode.TooManyRequests);

            // when . then
            Assert.Throws<HttpResponseTooManyRequestsException>(() =>
                ValidationService.ValidateHttpResponseAsync(tooManyRequestsResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestHeaderFieldsTooLargeExceptionIfResponseStatusCodeWasRequestHeaderFieldsTooLarge()
        {
            // given
            var requestHeaderFieldsTooLargeResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestHeaderFieldsTooLarge);

            // when . then
            Assert.Throws<HttpResponseRequestHeaderFieldsTooLargeException>(() =>
                ValidationService.ValidateHttpResponseAsync(requestHeaderFieldsTooLargeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnavailableForLegalReasonsExceptionIfResponseStatusCodeWasUnavailableForLegalReasons()
        {
            // given
            var unavailableForLegalReasonsResponseMessage = new HttpResponseMessage(HttpStatusCode.UnavailableForLegalReasons);

            // when . then
            Assert.Throws<HttpResponseUnavailableForLegalReasonsException>(() =>
                ValidationService.ValidateHttpResponseAsync(unavailableForLegalReasonsResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseInternalServerErrorExceptionIfResponseStatusCodeWasInternalServerError()
        {
            // given
            var internalServerErrorResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            // when . then
            Assert.Throws<HttpResponseInternalServerErrorException>(() =>
                ValidationService.ValidateHttpResponseAsync(internalServerErrorResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotImplementedExceptionIfResponseStatusCodeWasNotImplemented()
        {
            // given
            var notImplementedResponseMessage = new HttpResponseMessage(HttpStatusCode.NotImplemented);

            // when . then
            Assert.Throws<HttpResponseNotImplementedException>(() =>
                ValidationService.ValidateHttpResponseAsync(notImplementedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseBadGatewayExceptionIfResponseStatusCodeWasBadGateway()
        {
            // given
            var badGatewayResponseMessage = new HttpResponseMessage(HttpStatusCode.BadGateway);

            // when . then
            Assert.Throws<HttpResponseBadGatewayException>(() =>
                ValidationService.ValidateHttpResponseAsync(badGatewayResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseServiceUnavailableExceptionIfResponseStatusCodeWasServiceUnavailable()
        {
            // given
            var serviceUnavailableResponseMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);

            // when . then
            Assert.Throws<HttpResponseServiceUnavailableException>(() =>
                ValidationService.ValidateHttpResponseAsync(serviceUnavailableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseGatewayTimeoutExceptionIfResponseStatusCodeWasGatewayTimeout()
        {
            // given
            var gatewayTimeoutResponseMessage = new HttpResponseMessage(HttpStatusCode.GatewayTimeout);

            // when . then
            Assert.Throws<HttpResponseGatewayTimeoutException>(() =>
                ValidationService.ValidateHttpResponseAsync(gatewayTimeoutResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseHttpVersionNotSupportedExceptionIfResponseStatusCodeWasHttpVersionNotSupported()
        {
            // given
            var httpVersionNotSupportedResponseMessage = new HttpResponseMessage(HttpStatusCode.HttpVersionNotSupported);

            // when . then
            Assert.Throws<HttpResponseHttpVersionNotSupportedException>(() =>
                ValidationService.ValidateHttpResponseAsync(httpVersionNotSupportedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseVariantAlsoNegotiatesExceptionIfResponseStatusCodeWasVariantAlsoNegotiates()
        {
            // given
            var variantAlsoNegotiatesResponseMessage = new HttpResponseMessage(HttpStatusCode.VariantAlsoNegotiates);

            // when . then
            Assert.Throws<HttpResponseVariantAlsoNegotiatesException>(() =>
                ValidationService.ValidateHttpResponseAsync(variantAlsoNegotiatesResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseInsufficientStorageExceptionIfResponseStatusCodeWasInsufficientStorage()
        {
            // given
            var insufficientStorageResponseMessage = new HttpResponseMessage(HttpStatusCode.InsufficientStorage);

            // when . then
            Assert.Throws<HttpResponseInsufficientStorageException>(() =>
                ValidationService.ValidateHttpResponseAsync(insufficientStorageResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLoopDetectedExceptionIfResponseStatusCodeWasLoopDetected()
        {
            // given
            var loopDetectedResponseMessage = new HttpResponseMessage(HttpStatusCode.LoopDetected);

            // when . then
            Assert.Throws<HttpResponseLoopDetectedException>(() =>
                ValidationService.ValidateHttpResponseAsync(loopDetectedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotExtendedExceptionIfResponseStatusCodeWasNotExtended()
        {
            // given
            var notExtendedResponseMessage = new HttpResponseMessage(HttpStatusCode.NotExtended);

            // when . then
            Assert.Throws<HttpResponseNotExtendedException>(() =>
                ValidationService.ValidateHttpResponseAsync(notExtendedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNetworkAuthenticationRequiredExceptionIfResponseStatusCodeWasNetworkAuthenticationRequired()
        {
            // given
            var networkAuthenticationRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.NetworkAuthenticationRequired);

            // when . then
            Assert.Throws<HttpResponseNetworkAuthenticationRequiredException>(() =>
                ValidationService.ValidateHttpResponseAsync(networkAuthenticationRequiredResponseMessage));
        }

        private HttpResponseMessage CreateHttpResponseMessage(HttpStatusCode statusCode, string content)
        {
            return new HttpResponseMessage(statusCode)
            {
                Content = CreateStreamContent(content)
            };
        }

        private string GetrRandomContent() => new MnemonicString().GetValue();

        private StreamContent CreateStreamContent(string content)
        {
            byte[] contentBytes = Encoding.ASCII.GetBytes(content);
            var stream = new MemoryStream(contentBytes);

            return new StreamContent(stream);
        }
    }
}
