using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Shared.Domain.Repositories;

namespace PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Repositories;

/// <summary>
/// Defines persistence operations for alert rules.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public interface IAlertRuleRepository : IBaseRepository<AlertRule>
{
    /// <summary>
    /// Checks whether a rule identifier is already registered.
    /// </summary>
    /// <param name="ruleIdentifier">The external rule identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>True if the identifier already exists.</returns>
    Task<bool> ExistsByRuleIdentifierAsync(Guid ruleIdentifier, CancellationToken cancellationToken = default);
}