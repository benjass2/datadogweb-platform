# Datadog Telemetry API

## Overview

Datadog Telemetry API is a RESTful backend application for managing alert
rules. It provides an endpoint to register alert rules and persist them in a
MySQL database.

The application is built with C# 14, .NET 10 and ASP.NET Core. It applies
Domain-Driven Design, layered architecture, CQRS and Entity Framework Core.

## Authorship

- **Author:** <Your full name>
- **Student code:** U202422816
- **Course:** Aplicaciones Web
- **NRC:** 8130
- **GitHub repository:** <Your private repository URL>

## Bounded Contexts

- **Observability:** Manages alert rules and their business rules.
- **Shared:** Contains reusable domain and infrastructure components,
  including effective windows and monetary amounts.

## Technologies

- C# 14
- .NET 10
- ASP.NET Core
- Entity Framework Core
- MySQL
- OpenAPI and Scalar

## Configuration

Configure the `DefaultConnection` connection string in `appsettings.json`
or through environment variables. The database name must be
`datadog_telemetry`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=datadog_telemetry;user=root;password=YOUR_PASSWORD"
  }
}