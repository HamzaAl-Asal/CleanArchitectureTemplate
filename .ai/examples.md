# Architecture Examples

## Feature Flow

Endpoint -> Service -> Repository -> Entity

---

# Endpoint Example

Endpoints must stay thin.

Responsibilities:
- Receive requests
- Call services
- Return responses

Example:

```csharp
group.MapGet("/", HandleGetAll);

private static async Task<IResult> HandleGetAll(
    [FromServices] IWeatherForecastService service)
{
    var response = await service.GetAllAsync();

    return Results.Ok(response);
}
```

---

# Service Example

Services contain:

- Business orchestration
- DTO mapping

Example:

```csharp
public async Task<IEnumerable<WeatherForecastResponse>> GetAllAsync()
{
    var entities = await weatherForecastRepository.GetAllAsync();

    return entities.Select(x => new WeatherForecastResponse
    {
        Id = x.Id,
        Date = x.Date,
        TemperatureC = x.TemperatureC,
        Summary = x.Summary
    });
}
```

---

# Repository Example

Repositories handle data access only.

Example:

```csharp
private static readonly string[] Summaries =
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

private static readonly List<WeatherForecastEntity> WeatherForecasts =
    [.. Enumerable.Range(1, 5)
    .Select(index => new WeatherForecastEntity
    {
        Id = Guid.NewGuid(),
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })];

public async Task<IEnumerable<WeatherForecastEntity>> GetAllAsync()
{
    await Task.CompletedTask;

    return WeatherForecasts;
}
```

---

# Dependency Injection Example

Each module should register its own services.

Example:

```csharp
builder.Services
    .RegisterAppModuleServices()
    .RegisterInfrastructureModuleServices();
```

---

# DTO Rules

- Use DTOs instead of exposing entities directly
- DTO mapping should happen inside services

---

# Dependency Direction

Allowed:

- API -> App
- API -> Infrastructure
- App -> Domain
- App -> Common
- Infrastructure -> App
- Infrastructure -> Domain

Forbidden:

- Domain -> Any project
- App -> API
- App -> Infrastructure
- Domain -> Infrastructure