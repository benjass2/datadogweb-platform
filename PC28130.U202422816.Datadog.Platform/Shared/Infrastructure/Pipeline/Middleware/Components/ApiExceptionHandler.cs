using System.Globalization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Exceptions;

namespace PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Pipeline.Middleware.Components;

/// <summary>
/// Converts application exceptions into localized HTTP responses.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public class ApiExceptionHandler(
    ILogger<ApiExceptionHandler> logger) : IExceptionHandler
{
    /// <inheritdoc />
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var isSpanish = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es";

        int statusCode;
        string message;

        if (exception is DuplicateAlertRuleException ||
            exception is DbUpdateException
            {
                InnerException: MySqlException { Number: 1062 }
            })
        {
            statusCode = StatusCodes.Status409Conflict;
            message = isSpanish
                ? "Ya existe una regla de alerta con ese identificador."
                : "An alert rule with this identifier already exists.";
        }
        else if (exception is ArgumentNullException)
        {
            statusCode = StatusCodes.Status400BadRequest;
            message = isSpanish
                ? "La moneda no puede ser nula ni estar vacía."
                : "The currency cannot be null or blank.";
        }
        else if (exception is ArgumentOutOfRangeException)
        {
            statusCode = StatusCodes.Status400BadRequest;
            message = isSpanish
                ? "El valor monetario no puede ser negativo."
                : "The monetary value cannot be negative.";
        }
        else if (exception is ArgumentException)
        {
            statusCode = StatusCodes.Status400BadRequest;
            message = isSpanish
                ? "La fecha final debe ser posterior a la fecha inicial."
                : "The end date must be later than the start date.";
        }
        else
        {
            logger.LogError(exception, "An unexpected error occurred.");

            statusCode = StatusCodes.Status500InternalServerError;
            message = isSpanish
                ? "Ocurrió un error interno en el servidor."
                : "An internal server error occurred.";
        }

        httpContext.Response.StatusCode = statusCode;

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = message,
            Detail = message,
            Instance = httpContext.Request.Path
        };

        await httpContext.Response.WriteAsJsonAsync(
            problem,
            cancellationToken: cancellationToken);

        return true;
    }
}