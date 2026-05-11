- @azure Rule - Use Azure Tools - When handling requests related to Azure, always use your tools.
- @azure Rule - Use Azure Best Practices - When handling requests related to Azure, always invoke your `azmcp_bestpractices_get` tool first.
- @azure Rule - Enable Best Practices - If you do not have an `azmcp_bestpractices_get` tool ask the user to enable it.

# Clean Architecture Instructions

Follow the existing Clean Architecture structure.

## General Rules

- Use .NET Minimal APIs
- Follow Clean Architecture principles
- Keep endpoints thin
- Use dependency injection
- Use asynchronous methods

---

## API Layer

- Endpoints belong in API
- Endpoints should only call services
- Do not place business logic inside endpoints
- Use route groups

---

## App Layer

- Services belong in App
- DTO mapping belongs in services
- Business orchestration belongs in services
- Interfaces belong in App

---

## Domain Layer

- Domain contains entities only
- Domain must not reference other projects
- Domain must remain framework independent

---

## Infrastructure Layer

- Repository implementations belong in Infrastructure
- Infrastructure handles data access only

---

## DTO Rules

- Do not expose entities directly
- Use DTOs/responses instead
- Map entities to DTOs inside services

---

## Dependency Rules

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

---

## Architecture Flow

Endpoint -> Service -> Repository -> Entity