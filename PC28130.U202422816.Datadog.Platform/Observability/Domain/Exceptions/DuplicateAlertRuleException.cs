namespace PC28130.U202422816.Datadog.Platform.Observability.Domain.Exceptions;

/// <summary>
/// Indicates that an alert rule identifier is already registered.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public class DuplicateAlertRuleException : Exception
{
    /// <summary>
    /// Creates an exception for a duplicate identifier.
    /// </summary>
    public DuplicateAlertRuleException()
        : base("An alert rule with this identifier already exists.")
    {
    }
}