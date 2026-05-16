# Architecture Examples

## Feature Flow

```plaintext
Endpoint -> Service -> Repository -> Entity
                 ↓
               Mapper
```

---

# Endpoint Example

Endpoints must remain thin and focused.

Responsibilities:
- Receive requests
- Call services
- Return HTTP responses
- Handle HTTP status codes

Example:

```csharp
var group = app
    .MapGroup(EndpointRoutes.WeatherForecast)
    .WithTags(EndpointTags.WeatherForecast);

group.MapGet("/", HandleGetAll);

private static async Task<IResult> HandleGetAll(
    [FromServices] IWeatherForecastService weatherForecastService)
{
    var response =
        await weatherForecastService.GetAllAsync();

    return Results.Ok(new ApiResponse<IEnumerable<WeatherForecastResponse>>
    {
        Success = true,
        Data = response
    });
}
```

---

# Service Example

Services contain:
- Business orchestration
- DTO mapping
- Application flow coordination

Example:

```csharp
public async Task<IEnumerable<WeatherForecastResponse>> GetAllAsync()
{
    var weatherForecasts =
        await weatherForecastRepository.GetAllAsync();

    var mappedWeatherForecasts = weatherForecasts
        .Select(WeatherForecastMapper.MapToResponse)
        .ToList();

    return mappedWeatherForecasts;
}
```

---

# Mapper Example

Mappers are responsible for DTO transformations.

Example:

```csharp
public static class WeatherForecastMapper
{
    public static WeatherForecastResponse MapToResponse(
        WeatherForecastEntity weatherForecast)
    {
        return new WeatherForecastResponse
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
            Summary = weatherForecast.Summary
        };
    }
}
```

---

# Repository Example

Repositories handle data access only.

Example:

```csharp
private static readonly IReadOnlyList<string> Summaries =
[
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
];

private static readonly List<WeatherForecastEntity> WeatherForecasts =
[
    .. Enumerable.Range(1, 5)
    .Select(index => new WeatherForecastEntity
    {
        Id = Guid.NewGuid(),
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Count)]
    })
];

public Task<IEnumerable<WeatherForecastEntity>> GetAllAsync()
{
    return Task.FromResult<IEnumerable<WeatherForecastEntity>>(
        WeatherForecasts);
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

# Endpoint Registration Example

Endpoints should be registered centrally.

Example:

```csharp
app.RegisterApiEndpoints();
```

Extension example:

```csharp
public static class WebApplicationExtensions
{
    public static WebApplication RegisterApiEndpoints(
        this WebApplication app)
    {
        app.MapWeatherForecastEndpoints();

        return app;
    }
}
```

---

# Endpoint Constants Example

Endpoint routes and tags should be centralized.

Example:

```csharp
public static class EndpointRoutes
{
    public const string WeatherForecast =
        "api/weatherforecasts";
}

public static class EndpointTags
{
    public const string WeatherForecast =
        "Weather Forecast";
}
```

---

# DTO Rules

- Use DTOs instead of exposing entities directly
- DTO mapping should use mapper helpers
- Services should return DTOs, not entities
- Endpoints should never access repositories directly

---

# Dependency Direction

Allowed dependencies:

```plaintext
API -> App
API -> Infrastructure

App -> Domain
App -> Common

Infrastructure -> App
Infrastructure -> Domain
```

Forbidden dependencies:

```plaintext
Domain -> Any project

App -> API
App -> Infrastructure

Domain -> Infrastructure
```