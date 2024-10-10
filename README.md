# To-Do List API

This project is a simple RESTful API that allows users to manage a to-do list. It was built using .NET C# and ASP.NET Core. The API supports basic CRUD operations for managing to-do items, along with bonus features like filtering, sorting, and marking items as completed. Additionally, it includes **basic authentication** and **input validation**.

The API will be running on **http://localhost:5199**

This API uses Basic Authentication and credentials are below
- **Username:** testuser
- **Password:** password123

## Features

### Core Features:
- **Create a To-Do Item:**  
  Create a new to-do item by providing at least a `title`, `dueDate`, `status`. Optionally, you can add a `description`.
- **Retrieve All To-Do Items:**  
  Fetch all the to-do items in the system.
- **Retrieve a Single To-Do Item:**  
  Get the details of a specific to-do item by its unique ID.
- **Update a To-Do Item:**  
  Update the fields of an existing to-do item.
- **Delete a To-Do Item:**  
  Remove a to-do item from the system.
  
### Bonus Features:
- **Filtering:**  
  Filter to-do items by `dueDate` or `status`.
- **Sorting:**  
  Sort the to-do items by `title`, `dueDate`.
- **Authentication:**  
  Basic authentication using a static username and password for access control.
- **Input Validation:**  
  Ensure that to-do item data is valid before processing. For example, the `title` field is required and has a character limit.
- **Mark as Completed:**  
  Mark a specific to-do item as completed by updating the status to `true` for completed or `false` for pending.

## API Endpoints

### Core Endpoints:
- **POST** `/todos`  
  Create a new to-do item.  
  **Body Example:**
  ```json
  {
    "title": "Grocery Shopping",
    "description": "Buy milk, eggs, and bread",
    "dueDate": "2024-10-15",
    "completed": false
  }

- **Get** `/todos`  
  Retrieve all to-do items

- **Get** `/todos/{id}`  
  Retrieves a specific to-do item by its unique ID

- **PUT** `/todo/{id}`  
  Updates an existing to-do item.

- **Delete** `/todo/{id}`  
  Deletes a specific to-do item

### Bonus Endpoints:
- **GET** `/todos?status={completed|pending}`
  Filter to-do items by completion status

- **GET** `/todos?dueDate=2024-01-01`
  Filter to-do items by dueDate

- **GET** `/todos?sortBy=title`
  Sort to-do items by title

- **GET** `/todos?sortBy=dueDate`
  Sort to-do items by dueDate

- **Implemented Basic Authentication and Input Validation**