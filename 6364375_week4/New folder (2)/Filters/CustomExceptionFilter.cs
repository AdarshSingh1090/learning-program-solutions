
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var logPath = Path.Combine(AppContext.BaseDirectory, "error.log");

        File.AppendAllText(logPath, $"[{DateTime.Now}] {exception.Message}\n{exception.StackTrace}\n\n");

        context.Result = new ObjectResult("An unexpected error occurred.")
        {
            StatusCode = 500
        };
    }
}
