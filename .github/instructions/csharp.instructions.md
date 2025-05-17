---
applyTo: "**/*.cs"
---

# C# Coding Standards for CarWorkshop

## General Guidelines

- Use C# 11+ features when applicable
- Follow Microsoft's C# Coding Conventions
- Use nullable reference types
- Use file-scoped namespaces

## Naming Conventions

- Use PascalCase for class names, interfaces, and public members
- Use camelCase for private fields, prefixed with underscore (\_)
- Interface names should start with "I"
- Abstract class names should start with "Base" or "Abstract"
- Exception class names should end with "Exception"

## Code Style

- Use expression-bodied members for simple methods
- Use pattern matching where appropriate
- Use var only when the type is obvious
- Remove unnecessary using statements
- Keep methods short and focused on a single responsibility
- Use proper XML documentation comments for public APIs

## Performance Guidelines

- Use StringBuilder for complex string concatenation
- Use async/await for I/O operations
- Use IEnumerable<T> for returning sequences that will be iterated once
- Use IReadOnlyCollection<T> or IReadOnlyList<T> for read-only collections
- Use proper cancellation token support
