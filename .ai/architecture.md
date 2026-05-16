# Clean Architecture Template - Phase 1

## Overview

This project follows Clean Architecture principles using .NET Minimal APIs.

The template is designed to provide:
- a clean and scalable architecture,
- modular project structure,
- clear dependency boundaries,
- AI-friendly development conventions.

---

# Architecture Flow

```plaintext
API -> App -> Infrastructure
```

---

# Request Flow

```plaintext
Endpoint -> Service -> Repository -> Entity
                 ↓
               Mapper
```

---

# Project Structure

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
- Service interfaces
- Service implementations
- DTOs and response models
- Business orchestration
- DTO mapping

Contains:
- Interfaces
- Services
- Mappers
- Models
- ServiceCollectionExtensions

---

## Domain

Responsible for:
- Entities
- Core business models
- Base entity abstractions

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

# Architecture Patterns

The project currently uses:

- Clean Architecture
- Minimal APIs
- Service Layer Pattern
- Repository Pattern
- Dependency Injection
- Explicit DTO Mapping
- Modular Endpoint Registration

---

# Dependency Rules

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
- AI architecture documentation

---

# Design Goals

This template focuses on:
- simplicity,
- maintainability,
- scalability,
- readability,
- AI-friendly architecture guidance.

The project intentionally avoids unnecessary complexity during the early phases.