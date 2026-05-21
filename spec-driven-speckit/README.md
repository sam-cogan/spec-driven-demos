# spec-driven-speckit

Demonstrates **GitHub Spec Kit** applied to an **existing** application — the
same `BookLibrary.Api` from the other demos in this repo, but with no spec
artefacts yet. We will install Spec Kit *into* the existing project and use it
to add a new feature (book reservations).

The point of this demo: Spec Kit is not just for greenfield. It can be dropped
into an existing codebase to drive a single new feature through the full
spec → plan → tasks → implement loop.

## What's already here

- `src/BookLibrary.Api/` — the implemented book library Minimal API (CRUD on
  `/books`). Untouched from the original demo.
- `feature-ideas/book-reservations.md` — a deliberately high-level description
  of the new feature we want Spec Kit to build.

## What is **not** here (Spec Kit will create it)

- `.specify/`, `memory/constitution.md`, `.github/prompts/` — created by
  `specify init`.
- `specs/NNN-book-reservations/` and the feature branch — created by
  `/speckit.specify`.

## Prerequisites

- macOS / Linux / Windows
- [`uv`](https://docs.astral.sh/uv/) (Python package manager)
- Python 3.11+
- Git
- .NET 9 SDK
- VS Code with the GitHub Copilot extension

## How to run the demo

Open this folder (`spec-driven-speckit/`) directly in VS Code — not the repo
root — so Spec Kit's generated agent files land in the right place.

Then follow [`demo-script.md`](./demo-script.md).

## Quick sanity check before the demo

```bash
dotnet build
dotnet run --project src/BookLibrary.Api   # http://localhost:5211
```
