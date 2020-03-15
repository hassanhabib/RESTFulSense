# RESTFulSense 
I designed & developed this library as a wrapper around the existing .NET Core ```HttpClient``` implementation to provide the following values:

<ol>
	<li>Meaningful Exceptions for APIs response status codes.</li>
	<li>Simplified API communications.</li>
	<li>Test-friendly implementation.</li>
</ol>

<br />

### 1. Meaningful Exceptions
RESTFulSense provide the following exceptions for erroring HTTP Status Codes as follows:

<table>
<th>Status</th>
<th>Code</th>
<th>Exception</th>
<tr>
    <td>
        BadRequest
    </td>
    <td>
        400
    </td>
    <td>
        HttpResponseBadRequestException
    </td>
</tr>

<tr>
    <td>
        Unauthorized
    </td>
    <td>
        401
    </td>
    <td>
        HttpResponseUnauthorizedException
    </td>
</tr>

<tr>
    <td>
        PaymentRequired
    </td>
    <td>
        402
    </td>
    <td>
        HttpResponsePaymentRequiredException
    </td>
</tr>

<tr>
    <td>
        Forbidden
    </td>
    <td>
        403
    </td>
    <td>
        HttpResponseForbiddenException
    </td>
</tr>

<tr>
    <td>
        NotFound
    </td>
    <td>
        404
    </td>
    <td>
        HttpResponseNotFoundException
    </td>
</tr>

<tr>
    <td>
        MethodNotAllowed
    </td>
    <td>
        405
    </td>
    <td>
        HttpResponseMethodNotAllowedException
    </td>
</tr>

<tr>
    <td>
        NotAcceptable
    </td>
    <td>
        406
    </td>
    <td>
        HttpResponseNotAcceptableException
    </td>
</tr>

<tr>
    <td>
        ProxyAuthenticationRequired
    </td>
    <td>
        407
    </td>
    <td>
        HttpResponseProxyAuthenticationRequiredException
    </td>
</tr>

<tr>
    <td>
        RequestTimeout
    </td>
    <td>
        408
    </td>
    <td>
        HttpResponseRequestTimeoutException
    </td>
</tr>

<tr>
    <td>
        Conflict
    </td>
    <td>
        409
    </td>
    <td>
        HttpResponseConflictException
    </td>
</tr>

<tr>
    <td>
        Gone
    </td>
    <td>
        410
    </td>
    <td>
        HttpResponseGoneException
    </td>
</tr>

<tr>
    <td>
        LengthRequired
    </td>
    <td>
        411
    </td>
    <td>
        HttpResponseLengthRequiredException
    </td>
</tr>

<tr>
    <td>
        PreconditionFailed
    </td>
    <td>
        412
    </td>
    <td>
        HttpResponsePreconditionFailedException
    </td>
</tr>

<tr>
    <td>
        RequestEntityTooLarge
    </td>
    <td>
        413
    </td>
    <td>
        HttpResponseRequestEntityTooLargeException
    </td>
</tr>

<tr>
    <td>
        RequestUriTooLong
    </td>
    <td>
        414
    </td>
    <td>
        HttpResponseRequestUriTooLongException
    </td>
</tr>

<tr>
    <td>
        UnsupportedMediaType
    </td>
    <td>
        415
    </td>
    <td>
        HttpResponseUnsupportedMediaTypeException
    </td>
</tr>

<tr>
    <td>
        RequestedRangeNotSatisfiable
    </td>
    <td>
        416
    </td>
    <td>
        HttpResponseRequestedRangeNotSatisfiableException
    </td>
</tr>

<tr>
    <td>
        ExpectationFailed
    </td>
    <td>
        417
    </td>
    <td>
        HttpResponseExpectationFailedException
    </td>
</tr>

<tr>
    <td>
        MisdirectedRequest
    </td>
    <td>
        421
    </td>
    <td>
        HttpResponseMisdirectedRequestException
    </td>
</tr>

<tr>
    <td>
        UnprocessableEntity
    </td>
    <td>
        422
    </td>
    <td>
        HttpResponseUnprocessableEntityException
    </td>
</tr>

<tr>
    <td>
        Locked
    </td>
    <td>
        423
    </td>
    <td>
        HttpResponseLockedException
    </td>
</tr>

<tr>
    <td>
        FailedDependency
    </td>
    <td>
        424
    </td>
    <td>
        HttpResponseFailedDependencyException
    </td>
</tr>

<tr>
    <td>
        UpgradeRequired
    </td>
    <td>
        426
    </td>
    <td>
        HttpResponseUpgradeRequiredException
    </td>
</tr>

<tr>
    <td>
        PreconditionRequired
    </td>
    <td>
        428
    </td>
    <td>
        HttpResponsePreconditionRequiredException
    </td>
</tr>

<tr>
    <td>
        TooManyRequests
    </td>
    <td>
        429
    </td>
    <td>
        HttpResponseTooManyRequestsException
    </td>
</tr>

<tr>
    <td>
        RequestHeaderFieldsTooLarge
    </td>
    <td>
        431
    </td>
    <td>
        HttpResponseRequestHeaderFieldsTooLargeException
    </td>
</tr>

<tr>
    <td>
        UnavailableForLegalReasons
    </td>
    <td>
        451
    </td>
    <td>
        HttpResponseUnavailableForLegalReasonsException
    </td>
</tr>

<tr>
    <td>
        InternalServerError
    </td>
    <td>
        500
    </td>
    <td>
        HttpResponseInternalServerErrorException
    </td>
</tr>

<tr>
    <td>
        NotImplemented
    </td>
    <td>
        501
    </td>
    <td>
        HttpResponseNotImplementedException
    </td>
</tr>

<tr>
    <td>
        BadGateway
    </td>
    <td>
        502
    </td>
    <td>
        HttpResponseBadGatewayException
    </td>
</tr>

<tr>
    <td>
        ServiceUnavailable
    </td>
    <td>
        503
    </td>
    <td>
        HttpResponseServiceUnavailableException
    </td>
</tr>

<tr>
    <td>
        GatewayTimeout
    </td>
    <td>
        504
    </td>
    <td>
        HttpResponseGatewayTimeoutException
    </td>
</tr>

<tr>
    <td>
        HttpVersionNotSupported
    </td>
    <td>
        505
    </td>
    <td>
        HttpResponseHttpVersionNotSupportedException
    </td>
</tr>

<tr>
    <td>
        VariantAlsoNegotiates
    </td>
    <td>
        506
    </td>
    <td>
        HttpResponseVariantAlsoNegotiatesException
    </td>
</tr>

<tr>
    <td>
        InsufficientStorage
    </td>
    <td>
        507
    </td>
    <td>
        HttpResponseInsufficientStorageException
    </td>
</tr>

<tr>
    <td>
        LoopDetected
    </td>
    <td>
        508
    </td>
    <td>
        HttpResponseLoopDetectedException
    </td>
</tr>

<tr>
    <td>
        NotExtended
    </td>
    <td>
        510
    </td>
    <td>
        HttpResponseNotExtendedException
    </td>
</tr>

<tr>
    <td>
        NetworkAuthenticationRequired
    </td>
    <td>
        511
    </td>
    <td>
        HttpResponseNetworkAuthenticationRequiredException
    </td>
</tr>
</table>

<br />

### 2. Simplified API communications
Passing or retrieving objects from an API should be as simple as one method call, for RESTFulSense, you don't have to worry about how to serialize your input or deserialize the API output, here's how simple it works:

#### 2.1 Deserialization
```csharp
List<Student> students = 
    await restfulApiClient.GetContentAsync<List<Student>>(relativeUrl: "api/students");

```

#### 2.2 Serialization
```csharp
Student student = 
    await restfulApiClient.PostContentAsync<Student>(relativeUrl: "api/students", content: inputStudent); 
```
<br />

In addition to the wrappers around API calls and serialziation/deserialization, this library alos provides a simplified way to execute communications without any workarounds.
<br />
For instance, to execute a ```PUT``` API call without a body, to update a status for instance, you don't have to fake a ```PUT``` body to execute a successful call, you can just do the follows:
```csharp
Account activatedAccount = 
    await restfulApiClient.PutContentAsync(relativeUrl: $"api/accounts/{accountId}/activate");
```

<br />

### 3. Testing-Friendly Implementation
RESTFulSense provides an interface to the API client class, to make it easier to mock and leverage dependency injection for the testability of the client consumers, here's an example:
 
```csharp
var restfulApiClientMock = new Mock<IRestfulApiClient>();

restfulApiClient.Setup(client =>
    client.GetContentAsync<Student>(relativeUrl: $"api/students/{studentId}")
        .ReturnsAsync(student);
```

<br />

If you have any suggestions, comments or questions, please feel free to contact me on:
<br />
Twitter: @hassanrezkhabib
<br />
LinkedIn: hassanrezkhabib
<br />
E-Mail: hassanhabib@live.com
<br />