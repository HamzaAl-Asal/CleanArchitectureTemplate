- @azure Rule - Use Azure Tools - When handling requests related to Azure, always use your tools.
- @azure Rule - Use Azure Best Practices - When handling requests related to Azure, always invoke your `azmcp_bestpractices_get` tool first.
- @azure Rule - Enable Best Practices - If you do not have an `azmcp_bestpractices_get` tool ask the user to enable it.

# Clean Architecture Instructions

Follow the existing Clean Architecture structure and conventions used in this repository.

---

# General Rules

- Use .NET Minimal APIs
- Follow Clean Architecture principles
- Keep the architecture simple and scalable
- Keep endpoints thin
- Use dependency injection
- Use asynchronous methods for data access operations
- Prefer explicit implementations over hidden abstractions
- Keep `Program.cs` minimal and focused on application startup

---

# API Layer Rules

- Endpoints belong in the API layer
- Endpoints should only call services
- Do not place business logic inside endpoints
- Do not access repositories directly from endpoints
- Endpoints are responsible for HTTP responses and status codes
- Use route groups for feature endpoints
- Use centralized endpoint route constants
- Use centralized endpoint tag constants
- Use centralized endpoint registration

---

# App Layer Rules

- Services belong in the App layer
- Interfaces belong in the App layer
- Business orchestration belongs in services
- DTO mapping should use mapper helpers
- Services should return DTOs instead of entities
- Avoid infrastructure-specific logic inside services
- App may reference Domain and Common only

---

# Domain Layer Rules

- Domain contains entities and core business models only
- Domain must remain framework independent
- Domain must not reference other projects
- Base entities belong in Domain

---

# Infrastructure Layer Rules

- Repository implementations belong in Infrastructure
- Infrastructure handles data access and external integrations
- Repositories should contain data access logic only
- Infrastructure may reference App and Domain only

---

# DTO and Mapping Rules

- Do not expose entities directly from API endpoints
- Use DTOs and response models instead
- Use explicit mapper helpers for DTO transformations
- Avoid hidden or automatic mapping behavior
- Prefer readable and explicit mappings

---

# Dependency Injection Rules

- Each module should register its own services
- Dependency injection configuration should remain modular
- Use extension methods for service registrations

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

# Architecture Flow

```plaintext
Endpoint -> Service -> Repository -> Entity
                 ↓
               Mapper
```

---

# Design Goals

Prioritize:
- readability,
- maintainability,
- modularity,
- explicit architecture,
- AI-friendly conventions,
- minimal complexity.

Avoid unnecessary abstractions and overengineering.