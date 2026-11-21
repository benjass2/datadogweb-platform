using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Commands;
using PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Resources;

namespace PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Transform;

/// <summary>
/// Converts a create resource into a command.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public static class CreateAlertRuleCommandFromResourceAssembler
{
    /// <summary>
    /// Creates a command from a request resource.
    /// </summary>
    /// <param name="resource">The request resource.</param>
    /// <returns>The creation command.</returns>
    public static CreateAlertRuleCommand ToCommandFromResource(
        CreateAlertRuleResource resource)
    {
        return new CreateAlertRuleCommand(
            resource.RuleIdentifier,
            resource.ServiceId,
            resource.EvaluationStartDate,
            resource.EvaluationEndDate,
            resource.BudgetCapValue,
            resource.BudgetCapCurrency,
            resource.Description);
    }
}