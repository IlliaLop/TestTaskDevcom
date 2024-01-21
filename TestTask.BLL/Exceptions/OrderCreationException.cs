using System.Net;
using TestTask.BLL.Enums;
using TestTask.BLL.Exceptions.Abstract;

namespace TestTask.BLL.Exceptions;

public sealed class OrderCreationException : RequestException
{
    public OrderCreationException() : base(
        "Entity cannot be created. Only one order may be created for a user per day.",
        ErrorType.OrderCreationConflict,
        HttpStatusCode.Conflict)
    {
    }
    
    public OrderCreationException(string entityName) : base(
        $"Entity '{entityName}' cannot be created. Only one order may be created for a user per day.",
        ErrorType.OrderCreationConflict,
        HttpStatusCode.Conflict)
    {
    }
}