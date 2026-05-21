# Implementation Plan: Books CRUD

- **Architecture:** [architecture.md](./architecture.md)
- **Status:** implemented
- **Owner:** tech-lead
- **Created:** 2026-05-10

## Tasks

- [x] **1. Book record + request DTOs** — define `Book`, `CreateBookRequest`, `UpdateBookRequest`.
  - Files: `src/BookLibrary.Api/Books/Book.cs`
  - Done when: project builds.
- [x] **2. `IBookStore` interface** — define `GetAll/GetById/Add/Update/Delete`.
  - Files: `src/BookLibrary.Api/Books/IBookStore.cs`
- [x] **3. `InMemoryBookStore`** — thread-safe implementation, seeds 3 books.
  - Files: `src/BookLibrary.Api/Books/InMemoryBookStore.cs`
- [x] **4. `BookEndpoints`** — map all 5 verbs to the store.
  - Files: `src/BookLibrary.Api/Books/BookEndpoints.cs`
- [x] **5. Wire-up in `Program.cs`** — register `IBookStore`, call `MapBookEndpoints`.
  - Files: `src/BookLibrary.Api/Program.cs`

## Out-of-plan changes

- _(none)_
