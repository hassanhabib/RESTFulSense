// Copyright (c) Hassan Habib.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using RESTFulSense.Exceptions;
using RESTFulSense.Services;
using Xunit;

namespace RESTFulSense.Tests.Services
{
    public class ValidationServiceTests
    {
        [Fact]
        public void ShouldThrowHttpResponseBadRequestExceptionIfResponseStatusCodeWasBadRequest()
        {
            // given
            var badRequestResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

            // when . then
            Assert.Throws<HttpResponseBadRequestException>(() =>
                ValidationService.ValidateHttpResponse(badRequestResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnauthorizedExceptionIfResponseStatusCodeWasUnauthorized()
        {
            // given
            var unauthorizedResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);

            // when . then
            Assert.Throws<HttpResponseUnauthorizedException>(() =>
                ValidationService.ValidateHttpResponse(unauthorizedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponsePaymentRequiredExceptionIfResponseStatusCodeWasPaymentRequired()
        {
            // given
            var paymentRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.PaymentRequired);

            // when . then
            Assert.Throws<HttpResponsePaymentRequiredException>(() =>
                ValidationService.ValidateHttpResponse(paymentRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseForbiddenExceptionIfResponseStatusCodeWasForbidden()
        {
            // given
            var forbiddenResponseMessage = new HttpResponseMessage(HttpStatusCode.Forbidden);

            // when . then
            Assert.Throws<HttpResponseForbiddenException>(() =>
                ValidationService.ValidateHttpResponse(forbiddenResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotFoundExceptionIfResponseStatusCodeWasNotFound()
        {
            // given
            var notFoundResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);

            // when . then
            Assert.Throws<HttpResponseNotFoundException>(() =>
                ValidationService.ValidateHttpResponse(notFoundResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseMethodNotAllowedExceptionIfResponseStatusCodeWasMethodNotAllowed()
        {
            // given
            var methodNotAllowedResponseMessage = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);

            // when . then
            Assert.Throws<HttpResponseMethodNotAllowedException>(() =>
                ValidationService.ValidateHttpResponse(methodNotAllowedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotAcceptableExceptionIfResponseStatusCodeWasNotAcceptable()
        {
            // given
            var notAcceptableResponseMessage = new HttpResponseMessage(HttpStatusCode.NotAcceptable);

            // when . then
            Assert.Throws<HttpResponseNotAcceptableException>(() =>
                ValidationService.ValidateHttpResponse(notAcceptableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseProxyAuthenticationRequiredExceptionIfResponseStatusCodeWasProxyAuthenticationRequired()
        {
            // given
            var proxyAuthenticationRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.ProxyAuthenticationRequired);

            // when . then
            Assert.Throws<HttpResponseProxyAuthenticationRequiredException>(() =>
                ValidationService.ValidateHttpResponse(proxyAuthenticationRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestTimeoutExceptionIfResponseStatusCodeWasRequestTimeout()
        {
            // given
            var requestTimeoutResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestTimeout);

            // when . then
            Assert.Throws<HttpResponseRequestTimeoutException>(() =>
                ValidationService.ValidateHttpResponse(requestTimeoutResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseConflictExceptionIfResponseStatusCodeWasConflict()
        {
            // given
            var conflictResponseMessage = new HttpResponseMessage(HttpStatusCode.Conflict);

            // when . then
            Assert.Throws<HttpResponseConflictException>(() =>
                ValidationService.ValidateHttpResponse(conflictResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseGoneExceptionIfResponseStatusCodeWasGone()
        {
            // given
            var goneResponseMessage = new HttpResponseMessage(HttpStatusCode.Gone);

            // when . then
            Assert.Throws<HttpResponseGoneException>(() =>
                ValidationService.ValidateHttpResponse(goneResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLengthRequiredExceptionIfResponseStatusCodeWasLengthRequired()
        {
            // given
            var lengthRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.LengthRequired);

            // when . then
            Assert.Throws<HttpResponseLengthRequiredException>(() =>
                ValidationService.ValidateHttpResponse(lengthRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponsePreconditionFailedExceptionIfResponseStatusCodeWasPreconditionFailed()
        {
            // given
            var preconditionFailedResponseMessage = new HttpResponseMessage(HttpStatusCode.PreconditionFailed);

            // when . then
            Assert.Throws<HttpResponsePreconditionFailedException>(() =>
                ValidationService.ValidateHttpResponse(preconditionFailedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestEntityTooLargeExceptionIfResponseStatusCodeWasRequestEntityTooLarge()
        {
            // given
            var requestEntityTooLargeResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestEntityTooLarge);

            // when . then
            Assert.Throws<HttpResponseRequestEntityTooLargeException>(() =>
                ValidationService.ValidateHttpResponse(requestEntityTooLargeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestUriTooLongExceptionIfResponseStatusCodeWasRequestUriTooLong()
        {
            // given
            var requestUriTooLongResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestUriTooLong);

            // when . then
            Assert.Throws<HttpResponseRequestUriTooLongException>(() =>
                ValidationService.ValidateHttpResponse(requestUriTooLongResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnsupportedMediaTypeExceptionIfResponseStatusCodeWasUnsupportedMediaType()
        {
            // given
            var unsupportedMediaTypeResponseMessage = new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            // when . then
            Assert.Throws<HttpResponseUnsupportedMediaTypeException>(() =>
                ValidationService.ValidateHttpResponse(unsupportedMediaTypeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestedRangeNotSatisfiableExceptionIfResponseStatusCodeWasRequestedRangeNotSatisfiable()
        {
            // given
            var requestedRangeNotSatisfiableResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable);

            // when . then
            Assert.Throws<HttpResponseRequestedRangeNotSatisfiableException>(() =>
                ValidationService.ValidateHttpResponse(requestedRangeNotSatisfiableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseExpectationFailedExceptionIfResponseStatusCodeWasExpectationFailed()
        {
            // given
            var expectationFailedResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);

            // when . then
            Assert.Throws<HttpResponseExpectationFailedException>(() =>
                ValidationService.ValidateHttpResponse(expectationFailedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseMisdirectedRequestExceptionIfResponseStatusCodeWasMisdirectedRequest()
        {
            // given
            var misdirectedRequestResponseMessage = new HttpResponseMessage(HttpStatusCode.MisdirectedRequest);

            // when . then
            Assert.Throws<HttpResponseMisdirectedRequestException>(() =>
                ValidationService.ValidateHttpResponse(misdirectedRequestResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnprocessableEntityExceptionIfResponseStatusCodeWasUnprocessableEntity()
        {
            // given
            var unprocessableEntityResponseMessage = new HttpResponseMessage(HttpStatusCode.UnprocessableEntity);

            // when . then
            Assert.Throws<HttpResponseUnprocessableEntityException>(() =>
                ValidationService.ValidateHttpResponse(unprocessableEntityResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLockedExceptionIfResponseStatusCodeWasLocked()
        {
            // given
            var lockedResponseMessage = new HttpResponseMessage(HttpStatusCode.Locked);

            // when . then
            Assert.Throws<HttpResponseLockedException>(() =>
                ValidationService.ValidateHttpResponse(lockedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseFailedDependencyExceptionIfResponseStatusCodeWasFailedDependency()
        {
            // given
            var failedDependencyResponseMessage = new HttpResponseMessage(HttpStatusCode.FailedDependency);

            // when . then
            Assert.Throws<HttpResponseFailedDependencyException>(() =>
                ValidationService.ValidateHttpResponse(failedDependencyResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUpgradeRequiredExceptionIfResponseStatusCodeWasUpgradeRequired()
        {
            // given
            var upgradeRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.UpgradeRequired);

            // when . then
            Assert.Throws<HttpResponseUpgradeRequiredException>(() =>
                ValidationService.ValidateHttpResponse(upgradeRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponsePreconditionRequiredExceptionIfResponseStatusCodeWasPreconditionRequired()
        {
            // given
            var preconditionRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.PreconditionRequired);

            // when . then
            Assert.Throws<HttpResponsePreconditionRequiredException>(() =>
                ValidationService.ValidateHttpResponse(preconditionRequiredResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseTooManyRequestsExceptionIfResponseStatusCodeWasTooManyRequests()
        {
            // given
            var tooManyRequestsResponseMessage = new HttpResponseMessage(HttpStatusCode.TooManyRequests);

            // when . then
            Assert.Throws<HttpResponseTooManyRequestsException>(() =>
                ValidationService.ValidateHttpResponse(tooManyRequestsResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseRequestHeaderFieldsTooLargeExceptionIfResponseStatusCodeWasRequestHeaderFieldsTooLarge()
        {
            // given
            var requestHeaderFieldsTooLargeResponseMessage = new HttpResponseMessage(HttpStatusCode.RequestHeaderFieldsTooLarge);

            // when . then
            Assert.Throws<HttpResponseRequestHeaderFieldsTooLargeException>(() =>
                ValidationService.ValidateHttpResponse(requestHeaderFieldsTooLargeResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseUnavailableForLegalReasonsExceptionIfResponseStatusCodeWasUnavailableForLegalReasons()
        {
            // given
            var unavailableForLegalReasonsResponseMessage = new HttpResponseMessage(HttpStatusCode.UnavailableForLegalReasons);

            // when . then
            Assert.Throws<HttpResponseUnavailableForLegalReasonsException>(() =>
                ValidationService.ValidateHttpResponse(unavailableForLegalReasonsResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseInternalServerErrorExceptionIfResponseStatusCodeWasInternalServerError()
        {
            // given
            var internalServerErrorResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            // when . then
            Assert.Throws<HttpResponseInternalServerErrorException>(() =>
                ValidationService.ValidateHttpResponse(internalServerErrorResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotImplementedExceptionIfResponseStatusCodeWasNotImplemented()
        {
            // given
            var notImplementedResponseMessage = new HttpResponseMessage(HttpStatusCode.NotImplemented);

            // when . then
            Assert.Throws<HttpResponseNotImplementedException>(() =>
                ValidationService.ValidateHttpResponse(notImplementedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseBadGatewayExceptionIfResponseStatusCodeWasBadGateway()
        {
            // given
            var badGatewayResponseMessage = new HttpResponseMessage(HttpStatusCode.BadGateway);

            // when . then
            Assert.Throws<HttpResponseBadGatewayException>(() =>
                ValidationService.ValidateHttpResponse(badGatewayResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseServiceUnavailableExceptionIfResponseStatusCodeWasServiceUnavailable()
        {
            // given
            var serviceUnavailableResponseMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);

            // when . then
            Assert.Throws<HttpResponseServiceUnavailableException>(() =>
                ValidationService.ValidateHttpResponse(serviceUnavailableResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseGatewayTimeoutExceptionIfResponseStatusCodeWasGatewayTimeout()
        {
            // given
            var gatewayTimeoutResponseMessage = new HttpResponseMessage(HttpStatusCode.GatewayTimeout);

            // when . then
            Assert.Throws<HttpResponseGatewayTimeoutException>(() =>
                ValidationService.ValidateHttpResponse(gatewayTimeoutResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseHttpVersionNotSupportedExceptionIfResponseStatusCodeWasHttpVersionNotSupported()
        {
            // given
            var httpVersionNotSupportedResponseMessage = new HttpResponseMessage(HttpStatusCode.HttpVersionNotSupported);

            // when . then
            Assert.Throws<HttpResponseHttpVersionNotSupportedException>(() =>
                ValidationService.ValidateHttpResponse(httpVersionNotSupportedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseVariantAlsoNegotiatesExceptionIfResponseStatusCodeWasVariantAlsoNegotiates()
        {
            // given
            var variantAlsoNegotiatesResponseMessage = new HttpResponseMessage(HttpStatusCode.VariantAlsoNegotiates);

            // when . then
            Assert.Throws<HttpResponseVariantAlsoNegotiatesException>(() =>
                ValidationService.ValidateHttpResponse(variantAlsoNegotiatesResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseInsufficientStorageExceptionIfResponseStatusCodeWasInsufficientStorage()
        {
            // given
            var insufficientStorageResponseMessage = new HttpResponseMessage(HttpStatusCode.InsufficientStorage);

            // when . then
            Assert.Throws<HttpResponseInsufficientStorageException>(() =>
                ValidationService.ValidateHttpResponse(insufficientStorageResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseLoopDetectedExceptionIfResponseStatusCodeWasLoopDetected()
        {
            // given
            var loopDetectedResponseMessage = new HttpResponseMessage(HttpStatusCode.LoopDetected);

            // when . then
            Assert.Throws<HttpResponseLoopDetectedException>(() =>
                ValidationService.ValidateHttpResponse(loopDetectedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNotExtendedExceptionIfResponseStatusCodeWasNotExtended()
        {
            // given
            var notExtendedResponseMessage = new HttpResponseMessage(HttpStatusCode.NotExtended);

            // when . then
            Assert.Throws<HttpResponseNotExtendedException>(() =>
                ValidationService.ValidateHttpResponse(notExtendedResponseMessage));
        }

        [Fact]
        public void ShouldThrowHttpResponseNetworkAuthenticationRequiredExceptionIfResponseStatusCodeWasNetworkAuthenticationRequired()
        {
            // given
            var networkAuthenticationRequiredResponseMessage = new HttpResponseMessage(HttpStatusCode.NetworkAuthenticationRequired);

            // when . then
            Assert.Throws<HttpResponseNetworkAuthenticationRequiredException>(() =>
                ValidationService.ValidateHttpResponse(networkAuthenticationRequiredResponseMessage));
        }
    }
}
