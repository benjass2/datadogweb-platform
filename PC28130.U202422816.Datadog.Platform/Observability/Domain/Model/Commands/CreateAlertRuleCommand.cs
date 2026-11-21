namespace PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Commands;


/// <summary>
/// Contains the information required to create an alert rule.
/// </summary>
/// <param name="RuleIdentifier">The external rule identifier.</param>
/// <param name="ServiceId">The external workspace identifier.</param>
/// <param name="EvaluationStartDate">The start date of the evaluation window.</param>
/// <param name="EvaluationEndDate">The end date of the evaluation window.</param>
/// <param name="BudgetCapValue">The budget cap value.</param>
/// <param name="BudgetCapCurrency">The budget cap currency.</param>
/// <param name="Description">An optional description.</param>
/// <remarks>Author: Benjamin Solorzano.</remarks>
public record CreateAlertRuleCommand(
    Guid RuleIdentifier,
    Guid ServiceId,
    DateOnly EvaluationStartDate,
    DateOnly EvaluationEndDate,
    decimal BudgetCapValue,
    string BudgetCapCurrency,
    string? Description);