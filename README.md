# Task Management RESTful API

This project is a RESTful API built with ASP.NET Core that provides task management functionalities. It allows users to create, update, and delete tasks, as well as assign tasks to themselves, set due dates, and mark tasks as completed. Basic user authentication is implemented using ASP.NET Core Identity to ensure secure interaction with the tasks.

## Features

1. **Create Task:** This API endpoint enables users to create new tasks. Each task requires a title, description, due date, and completion status indicator.

2. **Update Task:** Users can update existing tasks using this API endpoint. They can modify the title, description, due date, and completion status of a task.

3. **Delete Task:** Tasks that are no longer needed can be deleted using this API endpoint. The tasks will be removed from the system.

4. **Assign Task:** Tasks can be assigned to users who created them. Each task is associated with the user who created it.

5. **Authentication:** The project implements basic user authentication using ASP.NET Core Identity. Users can register, log in, and interact only with tasks they've created.

## Getting Started

These instructions will help you get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET Core SDK (version X.X or later)
-  Microsoft visual stdio

### Installation

1. Clone the repository to your local machine:
   ```sh
   git clone https://github.com/Hassan-oladipupo/TaskFlowAPI

 
