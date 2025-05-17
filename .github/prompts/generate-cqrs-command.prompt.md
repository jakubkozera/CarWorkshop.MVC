---
mode: "agent"
tools: ["codebase", "terminal"]
description: "Generate a new CQRS Command with handler for CarWorkshop"
---

# Generate CQRS Command for CarWorkshop

Your goal is to generate a new CQRS Command with handler for the CarWorkshop project following the established patterns.

## Steps:

1. Ask for the feature name (e.g., CarWorkshop, CarWorkshopService, Appointment)
2. Ask for the command name (e.g., CreateCarWorkshop, UpdateCarWorkshopService)
3. Ask for command parameters and what they represent
4. Create the command class in the appropriate location
5. Create the command handler class
6. Update MediatR registrations if needed

## Follow these conventions:

- Place commands in `{Feature}/Commands/{CommandName}/{CommandName}Command.cs`
- Place handlers in `{Feature}/Commands/{CommandName}/{CommandName}Handler.cs`
- Commands should implement `IRequest` or `IRequest<TResponse>`
- Handlers should implement `IRequestHandler<TCommand>` or `IRequestHandler<TCommand, TResponse>`
- Add validation using FluentValidation where appropriate
- Add appropriate authorization checks
- Follow existing patterns in the codebase

If you have any questions about the command logic or structure, please ask before generating the code.
