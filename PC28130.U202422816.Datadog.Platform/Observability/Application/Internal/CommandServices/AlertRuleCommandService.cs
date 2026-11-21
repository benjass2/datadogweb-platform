using PC28130.U202422816.Datadog.Platform.Observability.Application.CommandServices;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Exceptions;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Commands;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Repositories;
using PC28130.U202422816.Datadog.Platform.Shared.Domain.Repositories;

namespace PC28130.U202422816.Datadog.Platform.Observability.Application.Internal.CommandServices;

/// <summary>
/// Handles commands for alert rules.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public class AlertRuleCommandService(
    IAlertRuleRepository alertRuleRepository,
    IUnitOfWork unitOfWork) : IAlertRuleCommandService
{
    /// <inheritdoc />
    public async Task<AlertRule> HandleAsync(
        CreateAlertRuleCommand command,
        CancellationToken cancellationToken = default)
    {
        var exists = await alertRuleRepository.ExistsByRuleIdentifierAsync(
            command.RuleIdentifier,
            cancellationToken);

        if (exists)
            throw new DuplicateAlertRuleException();

        var alertRule = new AlertRule(command);

        await alertRuleRepository.AddAsync(alertRule, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        return alertRule;
    }
}