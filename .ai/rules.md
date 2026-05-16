# Architecture Rules

## General Rules

- Follow Clean Architecture principles
- Use .NET Minimal APIs
- Keep the architecture simple and scalable
- Prefer explicit implementations over hidden abstractions
- Use dependency injection
- Use asynchronous methods for data access operations
- Keep `Program.cs` minimal and focused on application startup

---

# API Layer Rules

- API is the composition root
- Endpoints must remain thin
- Endpoints must only call services
- Endpoints must never access repositories directly
- Endpoints must not contain business logic
- Endpoints are responsible for HTTP responses and status codes
- Endpoint routes should use centralized route constants
- Endpoint tags should use centralized tag constants
- Endpoint registration should be centralized

---

# App Layer Rules

- Services belong in the App layer
- Business orchestration belongs in services
- DTO mapping should use mapper helpers
- Services should return DTOs instead of entities
- Services must not contain infrastructure-specific logic
- App can reference Domain and Common only

---

# Domain Layer Rules

- Domain contains entities and core business models only
- Domain must remain framework independent
- Domain must not reference any external project
- Domain must not contain infrastructure concerns
- Base entities and shared abstractions belong in Domain

---

# Infrastructure Layer Rules

- Repository implementations belong in Infrastructure
- Infrastructure handles data access and external integrations
- Infrastructure can reference App and Domain only
- Repositories should contain data access logic only
- Infrastructure must not contain HTTP concerns

---

# DTO and Mapping Rules

- Do not expose entities directly from API endpoints
- Use DTOs and response models instead
- DTO mapping should use explicit mapper helpers
- Avoid hidden or automatic mapping behavior
- Prefer readability and explicit transformations

---

# Dependency Injection Rules

- Each module should register its own services
- Service registrations should use extension methods
- Dependency injection configuration should remain modular

Example:

```csharp
builder.Services
    .RegisterAppModuleServices()
    .RegisterInfrastructureModuleServices();
```

---

# Dependency Rules

Allowed references:

```plaintext
API -> App
API -> Infrastructure

App -> Domain
App -> Common

Infrastructure -> App
Infrastructure -> Domain
```

Forbidden references:

```plaintext
Domain -> Any project

App -> API
App -> Infrastructure

Domain -> Infrastructure
```

---

# Design Principles

This template prioritizes:
- readability,
- maintainability,
- explicit architecture,
- modularity,
- AI-friendly conventions,
- minimal complexity.

Avoid unnecessary abstractions and overengineering during early phases.