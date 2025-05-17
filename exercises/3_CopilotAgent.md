# Exercise 3: Using GitHub Copilot Agent Mode

## Overview

In this exercise, you'll learn how to use GitHub Copilot's Agent mode to tackle complex, multi-step development tasks by leveraging its ability to understand, plan, and execute across multiple files in your workspace.

## What is Agent Mode?

Agent mode is an advanced capability of GitHub Copilot Chat that allows it to:

- Take more autonomous actions across your codebase
- Explore and understand the entire solution architecture
- Break down complex tasks into manageable steps
- Execute those steps by making changes to multiple files
- Debug issues by analyzing code and runtime behavior

## Exercise Tasks

### Task 1: Creating a Basic Statistics Feature

Use Agent mode to create a feature that will display basic statistics about car workshops in the application:

1. Open Copilot Chat and trigger Agent mode with the following prompt:

```
Create a statistics feature for our car workshop application that will:
1. Count the total number of workshops in the system
2. Calculate the average rating for all workshops
3. Find the most popular workshop (by rating)
4. Display these statistics on a new page called "Statistics"

The feature should include:
- A new StatisticsService in the Application layer
- A controller action to retrieve the statistics
- A view to display them in a simple dashboard format
```

2. Review the changes suggested by the Agent and let it implement them
3. Test the new statistics feature in the application

### Task 2: Code Analysis and Improvement

Ask the Agent to analyze your codebase for potential improvements:

```
Analyze our car workshop application for:
1. Places where we could improve error handling
2. Any potential performance bottlenecks in our queries
3. Code that might not follow best practices for clean architecture
4. Opportunities to improve unit test coverage

Provide specific examples from our code and suggestions for improvements.
```

### Task 3: Create Your Own Feature

Design a new feature for the car workshop application and use Agent mode to implement it. Some ideas:

- A user profile page showing workshops they've created/rated
- A search and filtering system for workshops
- A reporting feature for workshop owners
- Integration with a simple notification system

Document:

1. Your initial prompt to the Agent
2. How you refined the requirements during the conversation
3. Any challenges faced and how the Agent helped overcome them
4. The final outcome and your evaluation of how well it worked

## Tips for Effective Agent Usage

- Be specific about architecture constraints in your prompts
- Start with a clear overview of what you want to achieve
- Allow the Agent to plan the approach before making changes
- Review suggested changes before approving them
- Break very complex features into multiple Agent sessions

## Wrap-up

After completing these exercises, you should have a good understanding of:

- When to use Agent mode vs. regular Chat mode
- How to craft effective prompts for Agent mode
- The kinds of complex tasks Agent mode can help with
- The limitations of Agent mode and when human intervention is necessary

Share your experience with the group, highlighting what worked well and what could be improved in your interaction with Copilot's Agent mode.
