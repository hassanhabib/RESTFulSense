// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using RESTFulSense.WebAssembly.Models;
using RESTFulSense.WebAssembly.Models.Exceptions;

namespace RESTFulSense.WebAssembly.Services
{
    public static class ValidationService
    {
        public static async ValueTask ValidateHttpResponseAsync(HttpResponseMessage httpResponseMessage)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            bool isProblemDetailContent = IsProblemDetail(content);

            switch (isProblemDetailContent)
            {
                case true when httpResponseMessage.StatusCode == HttpStatusCode.BadRequest:
                    ValidationProblemDetails badRequestDetails = MapToProblemDetails(content);
                    throw new HttpResponseBadRequestException(httpResponseMessage, badRequestDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.BadRequest:
                    throw new HttpResponseBadRequestException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized:
                    ValidationProblemDetails UnauthorizedDetails = MapToProblemDetails(content);
                    throw new HttpResponseUnauthorizedException(httpResponseMessage, UnauthorizedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized:
                    throw new HttpResponseUnauthorizedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.PaymentRequired:
                    ValidationProblemDetails PaymentRequiredDetails = MapToProblemDetails(content);
                    throw new HttpResponsePaymentRequiredException(httpResponseMessage, PaymentRequiredDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PaymentRequired:
                    throw new HttpResponsePaymentRequiredException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.Forbidden:
                    ValidationProblemDetails ForbiddenDetails = MapToProblemDetails(content);
                    throw new HttpResponseForbiddenException(httpResponseMessage, ForbiddenDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Forbidden:
                    throw new HttpResponseForbiddenException(httpResponseMessage, content);

                case false when NotFoundWithNoContent(httpResponseMessage):
                    throw new HttpResponseUrlNotFoundException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NotFound:
                    ValidationProblemDetails NotFoundDetails = MapToProblemDetails(content);
                    throw new HttpResponseNotFoundException(httpResponseMessage, NotFoundDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotFound:
                    throw new HttpResponseNotFoundException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed:
                    ValidationProblemDetails MethodNotAllowedDetails = MapToProblemDetails(content);
                    throw new HttpResponseMethodNotAllowedException(httpResponseMessage, MethodNotAllowedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed:
                    throw new HttpResponseMethodNotAllowedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NotAcceptable:
                    ValidationProblemDetails NotAcceptableDetails = MapToProblemDetails(content);
                    throw new HttpResponseNotAcceptableException(httpResponseMessage, NotAcceptableDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotAcceptable:
                    throw new HttpResponseNotAcceptableException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired:
                    ValidationProblemDetails ProxyAuthDetails = MapToProblemDetails(content);
                    throw new HttpResponseProxyAuthenticationRequiredException(httpResponseMessage, ProxyAuthDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired:
                    throw new HttpResponseProxyAuthenticationRequiredException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout:
                    ValidationProblemDetails RequestTimeoutDetails = MapToProblemDetails(content);
                    throw new HttpResponseRequestTimeoutException(httpResponseMessage, RequestTimeoutDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout:
                    throw new HttpResponseRequestTimeoutException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.Conflict:
                    ValidationProblemDetails ConflictDetails = MapToProblemDetails(content);
                    throw new HttpResponseConflictException(httpResponseMessage, ConflictDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Conflict:
                    throw new HttpResponseConflictException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.Gone:
                    ValidationProblemDetails GoneDetails = MapToProblemDetails(content);
                    throw new HttpResponseGoneException(httpResponseMessage, GoneDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Gone:
                    throw new HttpResponseGoneException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.LengthRequired:
                    ValidationProblemDetails LengthRequiredDetails = MapToProblemDetails(content);
                    throw new HttpResponseLengthRequiredException(httpResponseMessage, LengthRequiredDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.LengthRequired:
                    throw new HttpResponseLengthRequiredException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionFailed:
                    ValidationProblemDetails PreconditionFailedDetails = MapToProblemDetails(content);
                    throw new HttpResponsePreconditionFailedException(httpResponseMessage, PreconditionFailedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionFailed:
                    throw new HttpResponsePreconditionFailedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.RequestEntityTooLarge:
                    ValidationProblemDetails RequestEntityTooLargeDetails = MapToProblemDetails(content);
                    throw new HttpResponseRequestEntityTooLargeException(httpResponseMessage, RequestEntityTooLargeDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestEntityTooLarge:
                    throw new HttpResponseRequestEntityTooLargeException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.RequestUriTooLong:
                    ValidationProblemDetails RequestUriTooLongDetails = MapToProblemDetails(content);
                    throw new HttpResponseRequestUriTooLongException(httpResponseMessage, RequestUriTooLongDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestUriTooLong:
                    throw new HttpResponseRequestUriTooLongException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType:
                    ValidationProblemDetails UnsupportedMediaTypeDetails = MapToProblemDetails(content);
                    throw new HttpResponseUnsupportedMediaTypeException(httpResponseMessage, UnsupportedMediaTypeDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType:
                    throw new HttpResponseUnsupportedMediaTypeException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable:
                    ValidationProblemDetails RequestedRangeDetails = MapToProblemDetails(content);
                    throw new HttpResponseRequestedRangeNotSatisfiableException(httpResponseMessage, RequestedRangeDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new HttpResponseRequestedRangeNotSatisfiableException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.ExpectationFailed:
                    ValidationProblemDetails ExpectationFailedDetails = MapToProblemDetails(content);
                    throw new HttpResponseExpectationFailedException(httpResponseMessage, ExpectationFailedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ExpectationFailed:
                    throw new HttpResponseExpectationFailedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.MisdirectedRequest:
                    ValidationProblemDetails MisdirectedRequestDetails = MapToProblemDetails(content);
                    throw new HttpResponseMisdirectedRequestException(httpResponseMessage, MisdirectedRequestDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.MisdirectedRequest:
                    throw new HttpResponseMisdirectedRequestException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.UnprocessableEntity:
                    ValidationProblemDetails UnprocessableEntityDetails = MapToProblemDetails(content);
                    throw new HttpResponseUnprocessableEntityException(httpResponseMessage, UnprocessableEntityDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnprocessableEntity:
                    throw new HttpResponseUnprocessableEntityException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.Locked:
                    ValidationProblemDetails LockedDetails = MapToProblemDetails(content);
                    throw new HttpResponseLockedException(httpResponseMessage, LockedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Locked:
                    throw new HttpResponseLockedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.FailedDependency:
                    ValidationProblemDetails FailedDependencyDetails = MapToProblemDetails(content);
                    throw new HttpResponseFailedDependencyException(httpResponseMessage, FailedDependencyDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.FailedDependency:
                    throw new HttpResponseFailedDependencyException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.UpgradeRequired:
                    ValidationProblemDetails UpgradeRequiredDetails = MapToProblemDetails(content);
                    throw new HttpResponseUpgradeRequiredException(httpResponseMessage, UpgradeRequiredDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UpgradeRequired:
                    throw new HttpResponseUpgradeRequiredException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionRequired:
                    ValidationProblemDetails PreconditionRequiredDetails = MapToProblemDetails(content);
                    throw new HttpResponsePreconditionRequiredException(httpResponseMessage, PreconditionRequiredDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionRequired:
                    throw new HttpResponsePreconditionRequiredException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests:
                    ValidationProblemDetails TooManyRequestsDetails = MapToProblemDetails(content);
                    throw new HttpResponseTooManyRequestsException(httpResponseMessage, TooManyRequestsDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests:
                    throw new HttpResponseTooManyRequestsException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.RequestHeaderFieldsTooLarge:
                    ValidationProblemDetails RequestHeaderFieldsTooLargeDetails = MapToProblemDetails(content);
                    throw new HttpResponseRequestHeaderFieldsTooLargeException(httpResponseMessage, RequestHeaderFieldsTooLargeDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestHeaderFieldsTooLarge:
                    throw new HttpResponseRequestHeaderFieldsTooLargeException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.UnavailableForLegalReasons:
                    ValidationProblemDetails UnavailableForLegalReasonsDetails = MapToProblemDetails(content);
                    throw new HttpResponseUnavailableForLegalReasonsException(httpResponseMessage, UnavailableForLegalReasonsDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnavailableForLegalReasons:
                    throw new HttpResponseUnavailableForLegalReasonsException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError:
                    ValidationProblemDetails InternalServerErrorDetails = MapToProblemDetails(content);
                    throw new HttpResponseInternalServerErrorException(httpResponseMessage, InternalServerErrorDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError:
                    throw new HttpResponseInternalServerErrorException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NotImplemented:
                    ValidationProblemDetails NotImplementedDetails = MapToProblemDetails(content);
                    throw new HttpResponseNotImplementedException(httpResponseMessage, NotImplementedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotImplemented:
                    throw new HttpResponseNotImplementedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.BadGateway:
                    ValidationProblemDetails BadGatewayDetails = MapToProblemDetails(content);
                    throw new HttpResponseBadGatewayException(httpResponseMessage, BadGatewayDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.BadGateway:
                    throw new HttpResponseBadGatewayException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable:
                    ValidationProblemDetails ServiceUnavailableDetails = MapToProblemDetails(content);
                    throw new HttpResponseServiceUnavailableException(httpResponseMessage, ServiceUnavailableDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable:
                    throw new HttpResponseServiceUnavailableException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout:
                    ValidationProblemDetails gatewayDetails = MapToProblemDetails(content);
                    throw new HttpResponseGatewayTimeoutException(httpResponseMessage, gatewayDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout:
                    throw new HttpResponseGatewayTimeoutException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.HttpVersionNotSupported:
                    ValidationProblemDetails httpVersionDetails = MapToProblemDetails(content);
                    throw new HttpResponseHttpVersionNotSupportedException(httpResponseMessage, httpVersionDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.HttpVersionNotSupported:
                    throw new HttpResponseHttpVersionNotSupportedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.VariantAlsoNegotiates:
                    ValidationProblemDetails variantAlsoNegotiates = MapToProblemDetails(content);
                    throw new HttpResponseVariantAlsoNegotiatesException(httpResponseMessage, variantAlsoNegotiates);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.VariantAlsoNegotiates:
                    throw new HttpResponseVariantAlsoNegotiatesException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.InsufficientStorage:
                    ValidationProblemDetails insufficientStorageDetails = MapToProblemDetails(content);
                    throw new HttpResponseInsufficientStorageException(httpResponseMessage, insufficientStorageDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.InsufficientStorage:
                    throw new HttpResponseInsufficientStorageException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.LoopDetected:
                    ValidationProblemDetails loopDetails = MapToProblemDetails(content);
                    throw new HttpResponseLoopDetectedException(httpResponseMessage, loopDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.LoopDetected:
                    throw new HttpResponseLoopDetectedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NotExtended:
                    ValidationProblemDetails notExtendedDetails = MapToProblemDetails(content);
                    throw new HttpResponseNotExtendedException(httpResponseMessage, notExtendedDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotExtended:
                    throw new HttpResponseNotExtendedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    ValidationProblemDetails networkAuthDetails = MapToProblemDetails(content);
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage, networkAuthDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage, content);
            }
        }

        private static bool NotFoundWithNoContent(HttpResponseMessage httpResponseMessage) =>
            httpResponseMessage.Content.Headers.Contains(name: "Content-Type") == false
            && httpResponseMessage.StatusCode == HttpStatusCode.NotFound;

        private static ValidationProblemDetails MapToProblemDetails(string content) =>
            JsonSerializer.Deserialize<ValidationProblemDetails>(content);

        private static bool IsProblemDetail(string content) =>
            content.Contains(value: "\"title\":", StringComparison.OrdinalIgnoreCase) &&
            content.Contains(value: "\"type\":", StringComparison.OrdinalIgnoreCase);
    }
}