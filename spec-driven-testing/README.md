# spec-driven-testing

A demo that uses an existing specification — both a written markdown spec **and** an OpenAPI document — to drive the creation of a complete test suite.

> **Premise:** A good spec is already a test plan.

## What's in here

- `src/BookLibrary.Api/` — A small .NET 9 Minimal API for managing books. Already implemented.
- `tests/BookLibrary.Api.Tests/` — Empty xUnit project, ready for the demo to fill in.
- `docs/specs/books-crud/`
  - `spec.md` — Written specification with 11 numbered acceptance criteria.
  - `architecture.md`, `plan.md` — Supporting artefacts.
- `docs/openapi.json` — Machine-readable contract for the same API.
- `.github/agents/` — `test-analyst` (derives test plans) and `test-engineer` (implements tests).
- `.github/skills/` — `derive-tests-from-spec`, `derive-tests-from-openapi`, `write-integration-tests`, `run-and-report-tests`. Each skill ships its templates under `references/`.
- `.github/copilot-instructions.md` — Repo-wide rules every agent must follow.

## How to run the demo

Open this folder (`spec-driven-testing/`) directly in VS Code — not the repo root — so the `.github/` agents, skills, and instructions are picked up.

Then follow [`docs/demo-script.md`](./docs/demo-script.md).

## Quick local sanity check

```bash
dotnet build
dotnet test       # passes (no tests yet) — the suite is what the demo creates
dotnet run --project src/BookLibrary.Api   # http://localhost:5211
```

## Why two specification sources?

The markdown spec describes *intent* in human terms. The OpenAPI document describes the *wire contract* with machine-readable constraints (`pattern`, `minimum`, required fields, response codes). Each catches behaviours the other misses — derive tests from both.
