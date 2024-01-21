using System.Net;
using TestTask.BLL.Enums;

namespace TestTask.BLL.Exceptions.Abstract;

public class RequestException: Exception
{
    public ErrorType ErrorType { get; }
    public HttpStatusCode StatusCode { get; }

    public RequestException(string message, ErrorType errorType, HttpStatusCode statusCode) : base(message)
    {
        ErrorType = errorType;
        StatusCode = statusCode;
    }
}