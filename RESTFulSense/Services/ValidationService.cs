// Copyright (c) Hassan Habib.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using RESTFulSense.Exceptions;

namespace RESTFulSense.Services
{
    public class ValidationService
    {
        public static void ValidateHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            switch (httpResponseMessage)
            {
                case { } when httpResponseMessage.StatusCode == HttpStatusCode.BadRequest:
                    throw new HttpResponseBadRequestException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized:
                    throw new HttpResponseUnauthorizedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PaymentRequired:
                    throw new HttpResponsePaymentRequiredException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Forbidden:
                    throw new HttpResponseForbiddenException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotFound:
                    throw new HttpResponseNotFoundException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed:
                    throw new HttpResponseMethodNotAllowedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotAcceptable:
                    throw new HttpResponseNotAcceptableException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired:
                    throw new HttpResponseProxyAuthenticationRequiredException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout:
                    throw new HttpResponseRequestTimeoutException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Conflict:
                    throw new HttpResponseConflictException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Gone:
                    throw new HttpResponseGoneException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.LengthRequired:
                    throw new HttpResponseLengthRequiredException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionFailed:
                    throw new HttpResponsePreconditionFailedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestEntityTooLarge:
                    throw new HttpResponseRequestEntityTooLargeException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestUriTooLong:
                    throw new HttpResponseRequestUriTooLongException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType:
                    throw new HttpResponseUnsupportedMediaTypeException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new HttpResponseRequestedRangeNotSatisfiableException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ExpectationFailed:
                    throw new HttpResponseExpectationFailedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.MisdirectedRequest:
                    throw new HttpResponseMisdirectedRequestException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnprocessableEntity:
                    throw new HttpResponseUnprocessableEntityException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Locked:
                    throw new HttpResponseLockedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.FailedDependency:
                    throw new HttpResponseFailedDependencyException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UpgradeRequired:
                    throw new HttpResponseUpgradeRequiredException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionRequired:
                    throw new HttpResponsePreconditionRequiredException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests:
                    throw new HttpResponseTooManyRequestsException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestHeaderFieldsTooLarge:
                    throw new HttpResponseRequestHeaderFieldsTooLargeException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnavailableForLegalReasons:
                    throw new HttpResponseUnavailableForLegalReasonsException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError:
                    throw new HttpResponseInternalServerErrorException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotImplemented:
                    throw new HttpResponseNotImplementedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.BadGateway:
                    throw new HttpResponseBadGatewayException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable:
                    throw new HttpResponseServiceUnavailableException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout:
                    throw new HttpResponseGatewayTimeoutException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.HttpVersionNotSupported:
                    throw new HttpResponseHttpVersionNotSupportedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.VariantAlsoNegotiates:
                    throw new HttpResponseVariantAlsoNegotiatesException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.InsufficientStorage:
                    throw new HttpResponseInsufficientStorageException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.LoopDetected:
                    throw new HttpResponseLoopDetectedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotExtended:
                    throw new HttpResponseNotExtendedException(httpResponseMessage);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage);
            }
        }
    }
}
