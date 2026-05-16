# Clean Architecture Minimal API Template

A reusable .NET Clean Architecture template built with Minimal APIs, modular architecture, and AI-guided development conventions.

The template focuses on simplicity, scalability, maintainability, and AI-friendly architecture guidance.

---

# Features

- Clean Architecture
- .NET Minimal APIs
- Service Layer Pattern
- Repository Pattern
- Explicit DTO Mapping
- Modular Dependency Injection
- Centralized Endpoint Registration
- Centralized Endpoint Route and Tag Constants
- AI-ready architecture documentation
- Installable .NET Template
- GitHub Actions CI Pipeline

---

# Architecture

## Application Flow

```plaintext
API -> App -> Infrastructure
```

---

## Request Flow

```plaintext
Endpoint -> Service -> Repository -> Entity
                 ↓
               Mapper
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
- Swagger configuration
- Application startup
- Endpoint registration
- HTTP response handling

Contains:
- Endpoints
- Endpoint constants
- Extension methods
- Program.cs

---

## App

Responsible for:
- Services
- Interfaces
- DTOs and response models
- Business orchestration
- DTO mapping

Contains:
- Services
- Interfaces
- Mappers
- Models
- ServiceCollectionExtensions

---

## Domain

Responsible for:
- Entities
- Base entities
- Core business models

Contains:
- Entities

---

## Infrastructure

Responsible for:
- Repository implementations
- Data access logic
- External integrations

Contains:
- Repositories
- ServiceCollectionExtensions

---

## Common

Responsible for:
- Shared reusable models
- Shared utilities
- Shared API response models

Contains:
- Shared models
- Shared utilities

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

# Patterns Used

- Clean Architecture
- Minimal APIs
- Service Layer Pattern
- Repository Pattern
- Dependency Injection
- Explicit DTO Mapping
- Modular Endpoint Registration

---

# AI Architecture Support

This repository includes AI instruction files to help AI tools generate code following the existing architecture conventions and dependency rules.

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

generate code consistently following the project architecture.

---

# Installation

Install the template locally:

```bash
dotnet new install .
```

Install directly from GitHub:

```bash
dotnet new install https://github.com/HamzaAl-Asal/CleanArchitectureTemplate
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

# Getting Started

## 1. Install the Template

Install directly from GitHub:

```bash
dotnet new install https://github.com/HamzaAl-Asal/CleanArchitectureTemplate
```

---

## 2. Create a New Project

Generate a new solution using the template:

```bash
dotnet new cleanarch -n MyProject
```

---

## 3. Open the Generated Solution

```bash
cd MyProject
```

Open the solution using:
- Visual Studio
- Rider
- VS Code

---

## 4. Build the Project

```bash
dotnet build
```

---

## 5. Run the API

```bash
dotnet run --project MyProject.Api
```

---

## 6. Open Swagger

After running the API, open Swagger using the URL shown in the terminal:

```plaintext
https://localhost:{port}/swagger
```

---

## 7. Start Building Features

Follow the existing architecture conventions:

```plaintext
Endpoint -> Service -> Repository -> Entity
                 ↓
               Mapper
```

Use:
- thin endpoints,
- services for orchestration,
- repositories for data access,
- mapper helpers for DTO transformations.
---

# Current Features

- WeatherForecast GetAll endpoint
- WeatherForecast GetById endpoint
- Explicit DTO mapping using mapper helpers
- Centralized endpoint route constants
- Centralized endpoint tag constants
- Modular dependency injection registration
- Centralized endpoint registration
- Swagger integration
- AI-guided architecture documentation

---

# Design Goals

This project aims to provide:

- A reusable Clean Architecture starter template
- AI-friendly architecture guidance
- Consistent project structure
- Scalable Minimal API foundation
- Explicit and maintainable architecture patterns
- Minimal complexity during early phases

---

# Future Improvements

Planned future improvements:

- Global exception handling
- ProblemDetails support
- Serilog logging module
- Configurable logging sinks
- Entity Framework Core integration
- FluentValidation integration
- Docker support
- Azure deployment support
- Architecture analyzers
- cspell integration
- SonarCloud integration
- Interactive template configuration
- JSON-based architecture specifications

---

# License

Licensed under the MIT License.