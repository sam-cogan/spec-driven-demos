# Feature idea — Book Reservations

> This is the only input you need before running Spec Kit. It is deliberately
> high-level. Spec Kit's `/speckit.specify` command will turn it into a full
> specification, ask clarifying questions, and create a feature branch and
> `specs/<NNN>-book-reservations/` directory.

## What

Let library members place a reservation on a book in the catalogue so that a
copy is held for them when one becomes available.

## Why

Today the API only tracks how many copies exist and how many are available, but
there is no way for a member to express interest in a book that is currently out
on loan. Librarians end up keeping a paper list. We want that workflow inside
the API so it can be exposed to a future self-service front end.

## Rough shape (intentionally vague)

- A member can reserve a book by id.
- Reservations form a FIFO queue per book.
- When a copy is returned (i.e. `copiesAvailable` increases), the reservation at
  the head of the queue is fulfilled.
- A member can cancel their own reservation.
- A librarian can see the queue for any book.

## Out of scope (for this feature)

- Notifications (email/SMS) — assume that's a future feature.
- Loan tracking (who has each copy) — covered separately.
- Authentication of members — for now assume a `memberId` string is passed in.

## Open questions to surface

These are the kinds of things Spec Kit's clarification step should flag:

- Can the same member reserve the same book twice?
- How long does a fulfilled reservation stay "held" before it expires?
- What happens to existing reservations if a book is deleted?
