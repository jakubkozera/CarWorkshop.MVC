# CarWorkshop Solution - Coding Standards

## General Guidelines

- Follow Clean Architecture principles with layers: Domain, Application, Infrastructure, and MVC
- Use C# 11+ features when applicable
- Use Entity Framework Core for database operations
- Follow CQRS pattern (Command Query Responsibility Segregation) for application logic
- Follow dependency injection principles
- Write unit tests for all business logic

## Naming Conventions

- Use PascalCase for class names, interfaces, and public members
- Use camelCase for private fields, prefixed with underscore (\_)
- Use descriptive and meaningful names for all identifiers
- Use verb prefixes for methods that perform actions (Get, Create, Update, Delete)

## Code Structure

- Place DTOs in the corresponding feature folder
- Place Commands and Queries in separate folders under each feature
- Follow MediatR pattern for commands and queries
- Create extension methods for services registration

## Testing

- Use xUnit for testing framework
- Use FluentAssertions for assertions
- Use Moq for mocking dependencies
- Test naming pattern: MethodName_Scenario_ExpectedResult

## Security

- Use ASP.NET Core Identity for authentication
- Validate all user inputs
- Apply proper authorization attributes
- Use HTTPS for all communications

## Performance

- Use async/await for I/O operations
- Avoid N+1 query problems by using Include() or projection
- Use pagination for large data sets
