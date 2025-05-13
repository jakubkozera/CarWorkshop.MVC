# Practical Exercise: Implementing a Rating System for Car Workshops

## Objective

In this exercise, you'll implement a rating system for car workshops using GitHub Copilot Chat's Ask and Edit modes. Users will be able to rate workshops on a scale of 1-5 stars, and each workshop will display its average rating.

## Current State

Currently, the Car Workshop application displays workshops and their services but lacks a rating system.

## Required Features

1. Add a Rating entity related to CarWorkshop
2. Create functionality for users to submit ratings
3. Calculate and display average ratings on the workshop details page
4. Add rating filtering to workshop listings

## Implementation Steps

### Step 1: Create the Rating Entity and Database Changes

Use GitHub Copilot Chat's **Ask mode** to help you design the Rating class:

1. Open a new chat and type:

   > @workspace I need to create a Rating entity for the CarWorkshop application. It should include a numeric score (1-5), optional comment, timestamp, and reference to both the CarWorkshop and the User who created it. How should I structure this?

2. Based on the response, create the appropriate entity in the Domain project.

3. Use **Edit mode** to update the DbContext:
   - Open [CarWorkshopDbContext.cs](../CarWorkshop.Infrastructure/Persistence/CarWorkshopDbContext.cs)
   - Open chat window, include the newly created Rating class file into the chat context and type:
     > Add DbSet for Ratings and configure the entity relationships in OnModelCreating method

### Step 2: Create Commands and Handlers

Use **Ask mode** to generate the necessary command structure:

1. Ask Copilot:

   > @workspace I need to create a command structure for adding a workshop rating with AJAX call. What files do I need to create and what should they contain?

2. Create the suggested files, by first coping the response from the **Ask mode** and then use **Edit mode** to generate the code. (adjust the response - turn it into a prompt, i.e. change the beginning to _Create the following classes in my app_)

3. Review the edited files and keep or reject specific changes

4. For the command handler, use Copilot to implement validation:

   - Open chat window in the handler file and type:
     > Implement validation to ensure the rating is between 1-5, the workshop exists, and the user hasn't already rated this workshop in the last 24 hours

5. Build the solution and fix any compilation erros with Copilot (if any).
   Run the following command in root folder.

   > dotnet build

   - In case of compilation errors use the **Ask mode** with _@workspace_ and the error message to fix the issues.

### Step 3: Implement the Controller Endpoint

1. Open [CarWorkshopController.cs](../CarWorkshop.MVC/Controllers/CarWorkshopController.cs)

2. Use **Edit mode** to add a new endpoint:
   - Open chat window, attach the appropriate handler file to the chat context and type:
     > Add an HTTP POST endpoint named 'AddRating' that accepts a workshop encoded name and a rating command, then sends it via the mediator

### Step 4: Create the UI Components

1. Modify the workshop details view to display current ratings and the rating form:

   - Open [Details.cshtml](../CarWorkshop.MVC/Views/CarWorkshop/Details.cshtml)
   - Use **Edit mode**:
     > Add a section below the workshop details that shows the current average rating with star icons, and a form that allows authenticated users to submit their own rating

2. Update JavaScript to handle rating submission:

   - Open [site.js](../CarWorkshop.MVC/wwwroot/js/site.js)
   - Use **Ask mode** to generate the necessary code:

     > @workspace How should I implement a JavaScript function that handles rating submission via AJAX, similar to how the existing service functions work?

     Review and apply the suggestions

### Step 5: Finish up the rating feature

At this stage, depending on the previous steps outcome, the rating feature might be completed fully or it still might need some finial adjustments.

Run the app and check if the feature is working as expected

- in case something is missing, try using **Ask mode** with the following prompt

  > @workspace is the car workshop service rating feature completed?

  Then based on the response you might want to ask follow up questions to get the details.

- in case the feature is partially broken (i.e. user can rate, but the rating is not displayed), explaing the issue to Copilot **Ask mode** with the _@workspace_ command.

  Then based on the response try fixing the code as suggested, or provide the reponse and prompt the Copilot in **Edit mode** to fix the issue

## Expected Outcome

After completing this exercise, your application should:

1. Allow authenticated users to rate workshops on a scale of 1-5
2. Display the average rating for each workshop on its details page
3. Show a visual representation of ratings using star icons

This exercise demonstrates how to use GitHub Copilot Chat's Ask and Edit modes to implement a complete feature from database changes to UI components.

If you want to continue with the exercise, try using Copilot to implement the following

> _Let users filter workshops by minimum rating_
