---
mode: "edit"
description: "Apply Clean Architecture patterns and SOLID principles to refactor code"
---

# Clean Architecture Refactoring

I'll help you refactor the selected code to better follow Clean Architecture principles and SOLID design principles.

## Analysis approach:

1. First, I'll analyze the selected code for:

   - Proper separation of concerns
   - Dependency direction (dependencies should point inward)
   - Use of interfaces for abstraction
   - Single Responsibility Principle violations
   - Other SOLID principle violations

2. Then I'll suggest refactoring to:
   - Move domain logic to Domain layer
   - Move application logic to Application layer
   - Use proper abstractions and interfaces
   - Implement dependency injection
   - Follow CQRS pattern where appropriate
   - Ensure testability

## CarWorkshop layers:

- **Domain Layer**: Core business entities and logic
- **Application Layer**: Use cases, commands, queries, interfaces
- **Infrastructure Layer**: Implementation of interfaces, external concerns
- **MVC Layer**: UI concerns, controllers, views

${selection}
