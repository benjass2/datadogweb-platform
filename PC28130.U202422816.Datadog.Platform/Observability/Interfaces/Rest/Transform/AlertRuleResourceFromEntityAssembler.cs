using System.Globalization;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Resources;

namespace PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Transform;

/// <summary>
/// Converts an alert rule into a response resource.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public static class AlertRuleResourceFromEntityAssembler
{
    /// <summary>
    /// Creates a resource from an alert rule.
    /// </summary>
    /// <param name="entity">The alert rule.</param>
    /// <returns>The response resource.</returns>
    public static AlertRuleResource ToResourceFromEntity(AlertRule entity)
    {
        return new AlertRuleResource(
            entity.Id,
            entity.RuleIdentifier.Value.ToString(),
            entity.ServiceId.Value.ToString(),
            entity.EvaluationWindow.StartDate.ToString(
                "yyyy-MM-dd", CultureInfo.InvariantCulture),
            entity.EvaluationWindow.EndDate.ToString(
                "yyyy-MM-dd", CultureInfo.InvariantCulture),
            entity.BudgetCap.Value,
            entity.BudgetCap.Currency);
    }
}