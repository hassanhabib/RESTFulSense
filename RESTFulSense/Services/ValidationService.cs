// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RESTFulSense.Exceptions;

namespace RESTFulSense.Services
{
    public class ValidationService
    {
        public async static ValueTask ValidateHttpResponseAsync(HttpResponseMessage httpResponseMessage)
        {
            string message = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage, message)
            {
                case { } when httpResponseMessage.StatusCode == HttpStatusCode.BadRequest:
                    throw new HttpResponseBadRequestException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized:
                    throw new HttpResponseUnauthorizedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PaymentRequired:
                    throw new HttpResponsePaymentRequiredException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Forbidden:
                    throw new HttpResponseForbiddenException(httpResponseMessage, message);

                //case { } when (httpResponseMessage.StatusCode == HttpStatusCode.NotFound && WithNoContentTypeHeader(httpResponseMessage)):
                //    throw new HttpResponseUrlNotFoundException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotFound:
                    throw new HttpResponseNotFoundException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed:
                    throw new HttpResponseMethodNotAllowedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotAcceptable:
                    throw new HttpResponseNotAcceptableException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired:
                    throw new HttpResponseProxyAuthenticationRequiredException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout:
                    throw new HttpResponseRequestTimeoutException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Conflict:
                    throw new HttpResponseConflictException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Gone:
                    throw new HttpResponseGoneException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.LengthRequired:
                    throw new HttpResponseLengthRequiredException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionFailed:
                    throw new HttpResponsePreconditionFailedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestEntityTooLarge:
                    throw new HttpResponseRequestEntityTooLargeException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestUriTooLong:
                    throw new HttpResponseRequestUriTooLongException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType:
                    throw new HttpResponseUnsupportedMediaTypeException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new HttpResponseRequestedRangeNotSatisfiableException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ExpectationFailed:
                    throw new HttpResponseExpectationFailedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.MisdirectedRequest:
                    throw new HttpResponseMisdirectedRequestException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnprocessableEntity:
                    throw new HttpResponseUnprocessableEntityException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.Locked:
                    throw new HttpResponseLockedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.FailedDependency:
                    throw new HttpResponseFailedDependencyException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UpgradeRequired:
                    throw new HttpResponseUpgradeRequiredException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionRequired:
                    throw new HttpResponsePreconditionRequiredException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests:
                    throw new HttpResponseTooManyRequestsException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.RequestHeaderFieldsTooLarge:
                    throw new HttpResponseRequestHeaderFieldsTooLargeException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.UnavailableForLegalReasons:
                    throw new HttpResponseUnavailableForLegalReasonsException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError:
                    throw new HttpResponseInternalServerErrorException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotImplemented:
                    throw new HttpResponseNotImplementedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.BadGateway:
                    throw new HttpResponseBadGatewayException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable:
                    throw new HttpResponseServiceUnavailableException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout:
                    throw new HttpResponseGatewayTimeoutException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.HttpVersionNotSupported:
                    throw new HttpResponseHttpVersionNotSupportedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.VariantAlsoNegotiates:
                    throw new HttpResponseVariantAlsoNegotiatesException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.InsufficientStorage:
                    throw new HttpResponseInsufficientStorageException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.LoopDetected:
                    throw new HttpResponseLoopDetectedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NotExtended:
                    throw new HttpResponseNotExtendedException(httpResponseMessage, message);

                case { } when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage, message);
            }
        }

        private static bool WithNoContentTypeHeader(HttpResponseMessage responseMessage) =>
            responseMessage.Content.Headers.Contains("Content-Type") == false;
    }
}
