# To-Do List API

This project is a simple RESTful API that allows users to manage a to-do list. It was built using .NET C# and ASP.NET Core. The API supports basic CRUD operations for managing to-do items, along with bonus features like filtering, sorting, and marking items as completed. Additionally, it includes basic token-based authentication and input validation.

## Features

### Core Features:
- **Create a To-Do Item:**  
  Create a new to-do item by providing at least a `title`. Optionally, you can add a description, due date, and mark it as completed.
- **Retrieve All To-Do Items:**  
  Fetch all the to-do items in the system.
- **Retrieve a Single To-Do Item:**  
  Get the details of a specific to-do item by its unique ID.
- **Update a To-Do Item:**  
  Update the fields of an existing to-do item.
- **Delete a To-Do Item:**  
  Remove a to-do item from the system.
  
### Bonus Features:
- **Mark as Completed:**  
  Mark a specific to-do item as completed using a dedicated endpoint.
- **Filtering:**  
  Filter to-do items by `dueDate` or completion status.
- **Sorting:**  
  Sort the to-do items by `title`, `dueDate`, or completion status.
- **Authentication:**  
  Basic token-based authentication using a static token for access control.
- **Input Validation:**  
  Ensure that to-do item data is valid before processing. For example, the `title` field is required and has a character limit.

## API Endpoints

### Core Endpoints:
- **POST** `/todo`  
  Create a new to-do item.  
  **Body Example:**
  ```json
  {
    "title": "Grocery Shopping",
    "description": "Buy milk, eggs, and bread",
    "dueDate": "2024-10-15",
    "completed": false
  }
