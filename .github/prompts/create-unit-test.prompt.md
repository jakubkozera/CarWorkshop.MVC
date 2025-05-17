---
mode: "agent"
tools: ["codebase", "terminal"]
description: "Create a new unit test for a CarWorkshop component"
---

# Generate Unit Test for CarWorkshop Component

Your goal is to create a comprehensive unit test for a component in the CarWorkshop solution.

## Steps:

1. Ask which component needs to be tested (e.g., command handler, query handler, service)
2. Analyze the component's dependencies and behaviors
3. Create a new test class in the appropriate test project
4. Set up test fixtures and mocks for dependencies
5. Create test cases for:
   - Happy path
   - Error conditions
   - Edge cases
   - Validation failures (if applicable)
   - Authorization failures (if applicable)
6. Follow the AAA pattern (Arrange-Act-Assert) for each test
7. Use FluentAssertions for assertions
8. Use Moq for mocking dependencies

## Follow these conventions:

- Test class name: `{ComponentName}Tests`
- Test method naming: `{MethodName}_{Scenario}_{ExpectedResult}`
- Place test classes in the same relative path as the component being tested
- Use the existing test helper methods and fixtures where applicable
- Mock only direct dependencies of the system under test
- Create separate test methods for each distinct behavior
- Use meaningful test data that illustrates the test case

Please add XML comments to describe what each test is verifying.
