# Architecture Rules

## General Rules

- Follow Clean Architecture principles
- Use Minimal APIs only
- Keep endpoints thin
- Use dependency injection
- Use asynchronous methods

---

## API Layer Rules

- API is the composition root
- Endpoints must only call services
- Do not place business logic inside endpoints
- Do not access repositories directly from endpoints

---

## App Layer Rules

- Services belong in App
- Business orchestration belongs in services
- DTO mapping should happen inside services
- App can reference Domain and Common only

---

## Domain Layer Rules

- Domain contains entities only
- Domain must not reference any external project
- Domain must remain framework independent

---

## Infrastructure Layer Rules

- Repository implementations belong in Infrastructure
- Infrastructure can reference App and Domain only
- Infrastructure handles data access

---

## DTO Rules

- Do not expose entities directly from API endpoints
- Use DTOs/responses instead
- DTO mapping happens inside services

---

## Dependency Rules

Allowed references:

- API -> App
- API -> Infrastructure
- App -> Domain
- App -> Common
- Infrastructure -> App
- Infrastructure -> Domain

Forbidden references:

- Domain -> Any project
- App -> API
- App -> Infrastructure
- Domain -> Infrastructure