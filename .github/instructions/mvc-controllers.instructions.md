---
applyTo: "**/Controllers/*.cs"
---

# MVC Controller Standards for CarWorkshop

## General Guidelines

- Use attribute routing
- Keep controllers thin by delegating to MediatR commands and queries
- Use action filters for cross-cutting concerns
- Return appropriate status codes for AJAX requests (200, 201, 400, 404, etc.)

## Input Validation

- Use ModelState validation for simple validations
- Use FluentValidation for complex validations
- Return proper validation error responses

## Authorization

- Apply authorization attributes at the controller or action level
- Use policy-based authorization for complex rules
- Always check user permissions before modifying data

## Action Methods

- Use async/await for all database operations
- Use action method naming conventions:
  - GET: Get, List, Index
  - POST: Create, Add
  - PUT: Update, Edit
  - DELETE: Delete, Remove
- Return appropriate ActionResults (View, PartialView, JsonResult, etc.)

## View Data

- Use ViewModels for passing data to views
- Avoid using ViewBag or ViewData except for simple values
- Use strongly typed views
