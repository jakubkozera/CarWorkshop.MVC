---
applyTo: "**/*Tests.cs"
---

# Testing Standards for CarWorkshop

## General Guidelines

- Use xUnit as the testing framework
- Use FluentAssertions for assertions
- Use Moq for mocking dependencies
- Follow AAA pattern (Arrange-Act-Assert)

## Test Naming

- Follow the pattern: MethodName_Scenario_ExpectedResult
  Example: `GetCarService_ForExistingId_ReturnsServiceDto`

## Test Structure

- Each test should focus on a single behavior
- Tests should be independent of each other
- Avoid logic in test methods (use helpers or factory methods)
- Use meaningful test data that clearly illustrates the test case

## Mocking

- Only mock direct dependencies of the system under test
- Use strict mocking when possible
- Verify important interactions with mocks
- Set up only the behaviors needed for the test

## Coverage Guidelines

- All public methods should have tests
- Critical paths and error conditions should be tested
- Edge cases should be tested
- Complex business logic should have extensive tests
