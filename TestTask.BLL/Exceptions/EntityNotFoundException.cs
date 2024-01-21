using System.Net;
using TestTask.BLL.Enums;
using TestTask.BLL.Exceptions.Abstract;

namespace TestTask.BLL.Exceptions;

public sealed class EntityNotFoundException: RequestException
{
    public EntityNotFoundException() : base(
        "Entity not found.",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }
    
    public EntityNotFoundException(string entityName) : base(
        $"Entity '{entityName}' not found",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }

    public EntityNotFoundException(string entityName, int id) : base(
        $"Entity '{entityName}' with id '{id}' not found",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }
}