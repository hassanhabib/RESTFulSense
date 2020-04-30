// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Models;

namespace RESTFulSense.Controllers
{
    public class RESTFulController : ControllerBase, IRESTFulController
    {
        public BadGatewayObjectResult BadGateway(object value) =>
            new BadGatewayObjectResult(value);

        public ExpectationFailedObjectResult ExpectationFailed(object value) =>
            new ExpectationFailedObjectResult(value);

        public FailedDependencyObjectResult FailedDependency(object value) =>
            new FailedDependencyObjectResult(value);

        public GatewayTimeoutObjectResult GatewayTimeout(object value) =>
            new GatewayTimeoutObjectResult(value);

        public GoneObjectResult Gone(object value) =>
            new GoneObjectResult(value);

        public HttpVersionNotSupportedObjectResult HttpVersionNotSupported(object value) =>
            new HttpVersionNotSupportedObjectResult(value);

        public InsufficientStorageObjectResult InsufficientStorage(object value) =>
            new InsufficientStorageObjectResult(value);

        public InternalServerErrorObjectResult InternalServerError(object value) =>
            new InternalServerErrorObjectResult(value);

        public LengthRequiredObjectResult LengthRequired(object value) =>
            new LengthRequiredObjectResult(value);

        public LockedObjectResult Locked(object value) =>
            new LockedObjectResult(value);

        public LoopDetectedObjectResult LoopDetected(object value) =>
            new LoopDetectedObjectResult(value);

        public MethodNotAllowedObjectResult MethodNotAllowed(object value) =>
            new MethodNotAllowedObjectResult(value);

        public MisdirectedRequestObjectResult MisdirectedRequest(object value) =>
            new MisdirectedRequestObjectResult(value);

        public NetworkAuthenticationRequiredObjectResult NetworkAuthenticationRequired(object value) =>
            new NetworkAuthenticationRequiredObjectResult(value);

        public NotAcceptableObjectResult NotAcceptable(object value) =>
            new NotAcceptableObjectResult(value);

        public NotExtendedObjectResult NotExtended(object value) =>
            new NotExtendedObjectResult(value);

        public NotImplementedObjectResult NotImplemented(object value) =>
            new NotImplementedObjectResult(value);

        public PaymentRequiredObjectResult PaymentRequired(object value) =>
            new PaymentRequiredObjectResult(value);

        public PreconditionFailedObjectResult PreconditionFailed(object value) =>
            new PreconditionFailedObjectResult(value);

        public PreconditionRequiredObjectResult PreconditionRequired(object value) =>
            new PreconditionRequiredObjectResult(value);

        public ProxyAuthenticationRequiredObjectResult ProxyAuthenticationRequired(object value) =>
            new ProxyAuthenticationRequiredObjectResult(value);

        public RequestedRangeNotSatisfiableObjectResult RequestedRangeNotSatisfiable(object value) =>
            new RequestedRangeNotSatisfiableObjectResult(value);

        public RequestEntityTooLargeObjectResult RequestEntityTooLarge(object value) =>
            new RequestEntityTooLargeObjectResult(value);

        public RequestHeaderFieldsTooLargeObjectResult RequestHeaderFieldsTooLarge(object value) =>
            new RequestHeaderFieldsTooLargeObjectResult(value);

        public RequestTimeoutObjectResult RequestTimeout(object value) =>
            new RequestTimeoutObjectResult(value);

        public RequestUriTooLongObjectResult RequestUriTooLong(object value) =>
            new RequestUriTooLongObjectResult(value);

        public ServiceUnavailableObjectResult ServiceUnavailable(object value) =>
            new ServiceUnavailableObjectResult(value);
    }
}