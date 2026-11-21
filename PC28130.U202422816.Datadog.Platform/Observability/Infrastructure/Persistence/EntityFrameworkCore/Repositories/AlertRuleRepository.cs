using Microsoft.EntityFrameworkCore;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Repositories;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.ValueObjects;
using PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace PC28130.U202422816.Datadog.Platform.Observability.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
/// <summary>
/// Entity Framework repository for alert rules.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public class AlertRuleRepository(AppDbContext context)
    : BaseRepository<AlertRule>(context), IAlertRuleRepository
{
    /// <inheritdoc />
    public Task<bool> ExistsByRuleIdentifierAsync(
        Guid ruleIdentifier,
        CancellationToken cancellationToken = default)
    {
        var identifier = new DatadogIdentifier(ruleIdentifier);

        return Context.Set<AlertRule>()
            .AnyAsync(rule => rule.RuleIdentifier == identifier, cancellationToken);
    }
}