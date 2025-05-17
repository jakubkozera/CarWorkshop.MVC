# Exercise 4: GitHub Copilot Customization

In this exercise, you will learn how to customize GitHub Copilot's behavior in your workspace using three different methods: global workspace instructions, targeted instruction files, and reusable prompt files.

## Task 1: Create and Enable Workspace-wide Instructions

**1.1 Create a Global Instructions File**

- Create a file at `.github/copilot-instructions.md` in the root of your workspace
- Add coding standards and best practices for your C# Clean Architecture project
- Include naming conventions, code organization, and architectural principles

**1.2 Enable Workspace Instructions**

- Open VS Code Settings (Ctrl+,)
- Search for "copilot instruction"
- Check the box for "github.copilot.chat.codeGeneration.useInstructionFiles"

## Task 2: Create Targeted Instruction Files

**2.1 Create C# Specific Instructions**

- Create a file at `.github/instructions/csharp.instructions.md`
- Add the following front matter to the top of the file:
  ```yaml
  ---
  applyTo: "**/*.cs"
  ---
  ```
- Include C#-specific coding guidelines and best practices

**2.2 Create Testing Instructions**

- Create a file at `.github/instructions/testing.instructions.md`
- Set the `applyTo` property to target test files
- Include guidelines for writing and organizing tests

**2.3 Test the Instructions**

- Open a C# file and a test file in your workspace
- Ask Copilot specific questions about each file
- Observe how responses differ based on the file context

## Task 3: Create Reusable Prompt Files

**3.1 Create a CQRS Command Generator**

- Create a file at `.github/prompts/generate-cqrs-command.prompt.md`
- Add the following front matter:
  ```yaml
  ---
  mode: "agent"
  tools: ["codebase", "terminal"]
  description: "Generate a new CQRS Command with handler"
  ---
  ```
- Write instructions for generating a command and handler that follow your project's patterns

**3.2 Create a Unit Test Generator**

- Create a file at `.github/prompts/create-unit-test.prompt.md`
- Configure it to help generate comprehensive unit tests
- Include guidance on using your preferred testing frameworks and patterns

**3.3 Test Your Prompts**

- Open GitHub Copilot Chat
- Type `/generate-cqrs-command` or use the Command Palette > "Chat: Run Prompt"
- Follow the guidance to create a new command and handler
- Use the unit test generator to create tests for your new code

## Tips

- Make your instructions concise and well-structured
- Use Markdown formatting to organize content
- Be specific about naming conventions and patterns
- Reference existing code examples to maintain consistency
- For agent-mode prompts, specify the tools that should be made available
