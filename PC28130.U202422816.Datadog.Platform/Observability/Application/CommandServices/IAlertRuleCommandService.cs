using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Commands;

namespace PC28130.U202422816.Datadog.Platform.Observability.Application.CommandServices;

/// <summary>
/// Defines operations that change alert rules.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public interface IAlertRuleCommandService
{
    /// <summary>
    /// Creates and persists an alert rule.
    /// </summary>
    /// <param name="command">The information for the new alert rule.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The newly created alert rule.</returns>
    Task<AlertRule> HandleAsync(CreateAlertRuleCommand command, CancellationToken cancellationToken = default);
}