namespace PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Resources;

/// <summary>
/// Represents an alert rule in an API response.
/// </summary>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public record AlertRuleResource(
    int Id,
    string RuleId,
    string ServiceId,
    string EvaluationStartDate,
    string EvaluationEndDate,
    decimal BudgetCapValue,
    string BudgetCapCurrency);