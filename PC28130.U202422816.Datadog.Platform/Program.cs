using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC28130.U202422816.Datadog.Platform.Observability.Application.CommandServices;
using PC28130.U202422816.Datadog.Platform.Observability.Application.Internal.CommandServices;
using PC28130.U202422816.Datadog.Platform.Observability.Domain.Model.Repositories;
using PC28130.U202422816.Datadog.Platform.Observability.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using PC28130.U202422816.Datadog.Platform.Shared.Domain.Repositories;
using PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using PC28130.U202422816.Datadog.Platform.Shared.Infrastructure.Pipeline.Middleware.Components;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var isSpanish = System.Globalization.CultureInfo.CurrentUICulture
                .TwoLetterISOLanguageName == "es";

            var message = isSpanish
                ? "La solicitud contiene datos inválidos o incompletos."
                : "The request contains invalid or incomplete data.";

            return new BadRequestObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = message,
                Detail = message,
                Instance = context.HttpContext.Request.Path
            });
        };
    });

builder.Services.AddLocalization();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Database connection string is missing.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAlertRuleRepository, AlertRuleRepository>();
builder.Services.AddScoped<IAlertRuleCommandService, AlertRuleCommandService>();

var app = builder.Build();

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures("en", "en-US", "es", "es-PE")
    .AddSupportedUICultures("en", "en-US", "es", "es-PE");

app.UseRequestLocalization(localizationOptions);
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();