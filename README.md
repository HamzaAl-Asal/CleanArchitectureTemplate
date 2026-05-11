# Clean Architecture Minimal API Template

A reusable .NET Clean Architecture template using Minimal APIs and AI-guided architecture documentation.

---

# Features

- Clean Architecture
- Minimal APIs
- Service Layer Pattern
- Repository Pattern
- DTO Mapping
- Modular Dependency Injection
- AI-ready architecture documentation
- Installable .NET Template

---

# Architecture

Application flow:

```plaintext
API -> App -> Infrastructure
```

Request flow:

```plaintext
Endpoint -> Service -> Repository -> Entity
```

---

# Project Structure

```plaintext
CleanArchitectureTemplate
│
├── CleanArchitectureTemplate.Api
│
├── Modules
│   ├── CleanArchitectureTemplate.App
│   ├── CleanArchitectureTemplate.Domain
│   ├── CleanArchitectureTemplate.Infrastructure
│   └── Shared
│
├── .ai
├── .github
└── .template.config
```

---

# Layers

## API

Responsible for:
- Minimal API endpoints
- Swagger/OpenAPI
- Application startup
- Dependency injection registrations

---

## App

Responsible for:
- Services
- Interfaces
- DTOs
- Business orchestration

---

## Domain

Responsible for:
- Entities
- Core business models

---

## Infrastructure

Responsible for:
- Repository implementations
- Data access logic

---

## Common

Responsible for:
- Shared reusable models
- Shared utilities

---

# Dependency Rules

Allowed:

```plaintext
API -> App
API -> Infrastructure

App -> Domain
App -> Common

Infrastructure -> App
Infrastructure -> Domain
```

Forbidden:

```plaintext
Domain -> Any project
App -> API
App -> Infrastructure
Domain -> Infrastructure
```

---

# Patterns Used

- Clean Architecture
- Minimal APIs
- Service Layer
- Repository Pattern
- Dependency Injection
- DTO Mapping

---

# AI Architecture Support

This repository includes AI instruction files to help AI tools generate code following the existing architecture.

Included files:

```plaintext
.ai/
 ├── architecture.md
 ├── rules.md
 └── examples.md

.github/
 └── copilot-instructions.md
```

These files help tools like:
- GitHub Copilot
- OpenAI Codex
- Claude
- Cursor
- Windsurf

follow the architecture rules and patterns consistently.

---

# Installation

Install the template locally:

```bash
dotnet new install .
```

---

# Usage

Generate a new project:

```bash
dotnet new cleanarch -n MyProject
```

Example generated structure:

```plaintext
MyProject.Api
MyProject.App
MyProject.Domain
MyProject.Infrastructure
```

---

# Current Features

- WeatherForecast GetAll endpoint
- WeatherForecast GetById endpoint
- DTO mapping inside services
- Modular service registration
- AI-guided architecture documentation

---

# Goals

This project aims to provide:

- A reusable Clean Architecture starter template
- AI-friendly architecture guidance
- Consistent project structure
- Scalable Minimal API foundation

---

# Future Improvements

Planned future improvements:

- Global exception handling
- ProblemDetails support
- Serilog logging module
- Entity Framework Core
- FluentValidation
- CQRS and MediatR
- Docker support
- Azure deployment support
- Architecture analyzers
- JSON-based architecture specifications

---

# License

MIT