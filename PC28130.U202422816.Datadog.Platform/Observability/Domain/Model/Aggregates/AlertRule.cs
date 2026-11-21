using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Commands;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.ValueObjects;
using PC28130.U202422816.Datadog.Platform.Shared.Domain.Model.Entities;
using PC28130.U202422816.Datadog.Platform.Shared.Domain.Model.ValueObjects;

namespace PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;


/// <summary>
/// Represents an alert rule monitored by Datadog.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public class AlertRule : IAuditableEntity
{
    public int Id { get; private set; }

    public DatadogIdentifier RuleIdentifier { get; private set; }

    public WorkspaceId ServiceId { get; private set; }

    public EffectiveWindow EvaluationWindow { get; private set; }

    public MonetaryAmount BudgetCap { get; private set; }

    public RuleStatus Status { get; private set; }

    public string? Description { get; private set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes an alert rule from a creation command.
    /// </summary>
    /// <param name="command">The command containing the rule information.</param>
    public AlertRule(CreateAlertRuleCommand command)
    {
        RuleIdentifier = new DatadogIdentifier(command.RuleIdentifier);
        ServiceId = new WorkspaceId(command.ServiceId);

        EvaluationWindow = new EffectiveWindow(
            command.EvaluationStartDate,
            command.EvaluationEndDate);

        BudgetCap = new MonetaryAmount(
            command.BudgetCapValue,
            command.BudgetCapCurrency);

        Status = RuleStatus.Draft;
        Description = command.Description;
    }

    // Required by Entity Framework Core when materializing the aggregate.
    private AlertRule()
    {
        RuleIdentifier = null!;
        ServiceId = null!;
        EvaluationWindow = null!;
        BudgetCap = null!;
    }
}