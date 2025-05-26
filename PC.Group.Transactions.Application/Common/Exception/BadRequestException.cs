namespace PC.Group.Transactions.Application.Common.Exception;

using System;

public class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message) { }

    public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}
