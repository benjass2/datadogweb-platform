namespace PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.ValueObjects;
/// <summary>
/// Identifies an alert rule using an identifier from another bounded context.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public record DatadogIdentifier(Guid Value);