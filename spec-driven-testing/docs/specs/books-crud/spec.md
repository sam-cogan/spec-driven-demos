# Spec: Books CRUD

- **Issue:** n/a (retrospective spec)
- **Status:** implemented
- **Owner:** product-analyst
- **Created:** 2026-05-10

## 1. Problem statement

Librarians need a small HTTP API to manage the catalogue of books the library lends out. The system must let staff list, view, add, update, and remove books, while preventing bad data (missing title, malformed ISBN, zero copies) from entering the catalogue.

## 2. User stories

- As a librarian, I want to list all books, so that I can see the catalogue.
- As a librarian, I want to look up a book by id, so that I can see its details.
- As a librarian, I want to add a new book, so that it becomes part of the catalogue.
- As a librarian, I want to update a book's details, so that I can correct mistakes.
- As a librarian, I want to remove a book, so that retired stock leaves the catalogue.

## 3. Acceptance criteria

1. **Given** the catalogue contains at least one book, **when** `GET /books` is called, **then** the response is `200 OK` and contains a JSON array of every book.
2. **Given** a book with id `X` exists, **when** `GET /books/{X}` is called, **then** the response is `200 OK` with that book's full record (`id`, `title`, `author`, `isbn`, `copiesTotal`, `copiesAvailable`).
3. **Given** no book with id `X` exists, **when** `GET /books/{X}` is called, **then** the response is `404 Not Found`.
4. **Given** a valid `CreateBookRequest`, **when** `POST /books` is called, **then** the response is `201 Created`, the `Location` header points to `/books/{newId}`, and the body contains the new book with `copiesAvailable == copiesTotal`.
5. **Given** a `CreateBookRequest` with an empty `title`, empty `author`, malformed `isbn`, or `copiesTotal < 1`, **when** `POST /books` is called, **then** the response is `400 Bad Request` and the book is not persisted.
6. **Given** a book with id `X` exists, **when** `PUT /books/{X}` is called with a valid `UpdateBookRequest`, **then** the response is `200 OK` with the updated book; `copiesAvailable` must never exceed the new `copiesTotal`.
7. **Given** no book with id `X` exists, **when** `PUT /books/{X}` is called, **then** the response is `404 Not Found`.
8. **Given** a `PUT /books/{X}` request body fails validation (same rules as AC #5), **then** the response is `400 Bad Request` and the existing record is unchanged.
9. **Given** a book with id `X` exists, **when** `DELETE /books/{X}` is called, **then** the response is `204 No Content` and a subsequent `GET /books/{X}` returns `404 Not Found`.
10. **Given** no book with id `X` exists, **when** `DELETE /books/{X}` is called, **then** the response is `404 Not Found`.
11. **Given** a book with `isbn = I` already exists, **when** `POST /books` is called with the same `isbn`, **then** the response is `409 Conflict` and no duplicate is created.

## 4. In scope

- HTTP CRUD endpoints under `/books`.
- In-memory storage seeded with three sample books at startup.
- Input validation as described in AC #5, #8, #11.

## 5. Out of scope / non-goals

- Persistence to a database.
- Authentication and authorisation.
- Pagination, filtering, sorting.
- Reservations or lending (covered by a future feature).

## 6. Open questions

- _(none — spec is retrospective)_

## 7. Success metrics

- All acceptance criteria covered by automated tests.
- Zero `500` responses for any input shape the validation rules can describe.
