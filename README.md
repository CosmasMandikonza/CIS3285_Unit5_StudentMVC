# CIS 3285 Unit 5 - Interfaces and Null Object Pattern

This repository is my Unit 5 Student MVC implementation based on the class example.

## What I changed

- Added **IStudentInterface** as the common contract for student objects.
- `StudentModel` implements `IStudentInterface`.
- Added **IStudentCRUDInterface** so the controller works through an interface instead of depending directly on a concrete repository type.
- `StudentRepository` implements the CRUD interface and stores `IStudentInterface` objects.
- Added a **NullStudent** implementation of `IStudentInterface`.
- `getStudentById` returns `NullStudent` when an ID is missing instead of returning `null`.
- Updated delete and update operations so an invalid student ID does not cause an index error.

## Null Object Pattern

The main idea of the Null Object Pattern is to return a safe object that follows the same interface as a normal object.

In this project:

```text
IStudentInterface
      |
      +-- StudentModel
      |
      +-- NullStudent
```

A controller can therefore ask the repository for an `IStudentInterface` and use the returned object without first checking for a null reference.

## Interface flow

```text
StudentController
       |
       v
IStudentCRUDInterface
       |
       v
StudentRepository
       |
       v
List<IStudentInterface>
       |
       +-- StudentModel
       +-- NullStudent
```

This keeps the controller less dependent on the concrete model and repository classes.
