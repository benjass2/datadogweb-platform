using Microsoft.AspNetCore.Mvc;
using PC28130.U202422816.Datadog.Platform.Observability.Application.CommandServices;
using PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Resources;
using PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest.Transform;

namespace PC28130.U202422816.Datadog.Platform.Observability.Interfaces.Rest;

/// <summary>
/// Provides operations for alert rules.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
[ApiController]
[Route("api/v1/alert-rules")]
[Produces("application/json")]
public class AlertRulesController(
    IAlertRuleCommandService commandService) : ControllerBase
{
    /// <summary>
    /// Creates an alert rule.
    /// </summary>
    /// <param name="resource">The information for the new rule.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created alert rule.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(AlertRuleResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAlertRule(
        [FromBody] CreateAlertRuleResource resource,
        CancellationToken cancellationToken)
    {
        var command = CreateAlertRuleCommandFromResourceAssembler
            .ToCommandFromResource(resource);

        var alertRule = await commandService.HandleAsync(command, cancellationToken);

        var response = AlertRuleResourceFromEntityAssembler
            .ToResourceFromEntity(alertRule);

        return StatusCode(StatusCodes.Status201Created, response);
    }
}