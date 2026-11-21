using Microsoft.EntityFrameworkCore;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Aggregates;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.ValueObjects;

namespace PC28130.U202422816.Datadog.Platform.Observability.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
/// Configures the persistence model for the Observability context.
/// </summary>
/// <remarks>Author: Your full name.</remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies the Observability mappings.
    /// </summary>
    /// <param name="builder">The Entity Framework model builder.</param>
    public static void ApplyObservabilityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<AlertRule>(entity =>
        {
            entity.ToTable("alert_rules");

            entity.HasKey(rule => rule.Id);

            entity.Property(rule => rule.Id)
                .ValueGeneratedOnAdd();

            entity.Property(rule => rule.RuleIdentifier)
                .HasConversion(
                    identifier => identifier.Value,
                    value => new DatadogIdentifier(value))
                .HasColumnName("rule_identifier")
                .IsRequired();

            entity.HasIndex(rule => rule.RuleIdentifier)
                .IsUnique();

            entity.Property(rule => rule.ServiceId)
                .HasConversion(
                    workspaceId => workspaceId.Value,
                    value => new WorkspaceId(value))
                .HasColumnName("service_id")
                .IsRequired();

            entity.OwnsOne(rule => rule.EvaluationWindow, window =>
            {
                window.Property(value => value.StartDate)
                    .HasColumnName("evaluation_start_date")
                    .IsRequired();

                window.Property(value => value.EndDate)
                    .HasColumnName("evaluation_end_date")
                    .IsRequired();
            });

            entity.Navigation(rule => rule.EvaluationWindow)
                .IsRequired();

            entity.OwnsOne(rule => rule.BudgetCap, amount =>
            {
                amount.Property(value => value.Value)
                    .HasColumnName("budget_cap_value")
                    .HasPrecision(18, 2)
                    .IsRequired();

                amount.Property(value => value.Currency)
                    .HasColumnName("budget_cap_currency")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            entity.Navigation(rule => rule.BudgetCap)
                .IsRequired();

            entity.Property(rule => rule.Status)
                .IsRequired();

            entity.Property(rule => rule.Description)
                .IsRequired(false);
        });
    }
}