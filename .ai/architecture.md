# Clean Architecture Template - Phase 1

## Overview

This project follows Clean Architecture using .NET Minimal APIs.

Architecture flow:

API -> App -> Infrastructure

## Project Structure

### API

Responsible for:
- Minimal API endpoints
- Swagger/OpenAPI
- Dependency injection registrations
- Application startup

Contains:
- Endpoints
- Program.cs

---

### App

Responsible for:
- Service interfaces
- Service implementations
- DTOs and response models
- Business orchestration

Contains:
- Interfaces
- Services
- ServiceCollectionExtensions

---

### Domain

Responsible for:
- Entities
- Core business models

Contains:
- Entities

---

### Infrastructure

Responsible for:
- Repository implementations
- Data access logic

Contains:
- Repositories
- ServiceCollectionExtensions

---

### Common

Responsible for:
- Shared reusable models
- Shared utilities

Contains:
- Shared models

## Architecture Patterns

The project currently uses:

- Clean Architecture
- Minimal APIs
- Service Layer Pattern
- Repository Pattern
- Dependency Injection
- DTO Mapping

## Dependency Rules

- API references App and Infrastructure
- App references Domain and Common
- Infrastructure references App and Domain
- Domain does not reference any project

## Request Flow

Endpoint -> Service -> Repository -> Entity

## Current Features

- WeatherForecast GetAll endpoint
- WeatherForecast GetById endpoint
- DTO mapping inside services
- Modular dependency injection registration