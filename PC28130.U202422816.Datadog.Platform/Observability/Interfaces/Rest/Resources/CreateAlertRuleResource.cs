namespace PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Resources;

/// <summary>
/// Contains the information required to create an alert rule.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public record CreateAlertRuleResource(
    Guid RuleIdentifier,
    Guid ServiceId,
    DateOnly EvaluationStartDate,
    DateOnly EvaluationEndDate,
    decimal BudgetCapValue,
    string BudgetCapCurrency,
    string? Description);