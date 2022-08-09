# EmployeesCensus
## Description
The company decided to conduct a census of employees, in order to determine how many people are employees

Your task is to implement a web application that will automate this process

## Basic Entities
- Employee (First Name, Last Name, Age, Gender, Department)
- Department (Name, floor)
- Programming language (Name)
- Work experience (Employee, Programming language)

For the entities "Department" and "Programming Language" pre-fill the database with test values

## Main application pages
- List of already added employees with search (url `/`)
- Adding an employee (url `/add`), the fields "department" and "programming language" are select boxes, implement an autocomplete for the name field (selection prompt).
- Editing an employee (url `/edit`)
- Deleting an employee (`/delete`), make "soft" delete

## Extras
- Implement Http Basic authentication
- Make it possible to add `/users/add` user
- Username and password and timestamp of the last action should be stored in the database.

## Stack
C#, ASP.NET MVC, EF, SQL Server