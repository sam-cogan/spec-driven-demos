# Copilot instructions — spec-driven-testing demo

This repo demonstrates **spec-driven testing**: the spec is the test plan. The application (`BookLibrary.Api`) is already implemented; what is *not* yet done is the test suite.

## The workflow

```
spec.md / openapi.json  ─►  test-analyst  ─►  test-plan.md  ─►  test-engineer  ─►  xUnit tests  ─►  test-results.md
```

1. The `test-analyst` derives a test plan from `spec.md` and/or `openapi.json` using the `derive-tests-from-spec` and `derive-tests-from-openapi` skills.
2. The `test-engineer` implements the plan as xUnit tests using `write-integration-tests`, then runs the suite with `run-and-report-tests`.

## Rules every agent must follow

- **The spec and the OpenAPI are the source of truth.** Tests verify them. Never modify either to make a test pass.
- **The implementation under `src/` is read-only for testing agents.** If a test fails because the implementation does not satisfy the spec, hand back to triage — the production fix is somebody else's job.
- **One acceptance criterion = at least one test.** Boundaries, error paths, and the happy path are all separate tests.
- **Coverage gaps must be visible.** If an AC has no test, the test plan and the test results must both flag it as missing coverage.
- **Spec artefacts live under `docs/specs/<slug>/`.** Use kebab-case slugs. Files: `spec.md`, `architecture.md`, `plan.md`, `test-plan.md`, `test-results.md`.

## Project layout

- `src/BookLibrary.Api/` — the already-implemented Minimal API.
- `tests/BookLibrary.Api.Tests/` — xUnit project using `WebApplicationFactory<Program>`. Empty by design — the demo fills it in.
- `docs/specs/books-crud/` — `spec.md`, `architecture.md`, `plan.md` (all marked `implemented`).
- `docs/openapi.json` — machine-readable contract for the same API.

## Code conventions

- .NET 9, C# 12, nullable enabled.
- xUnit + `Microsoft.AspNetCore.Mvc.Testing` + `FluentAssertions`.
- One test class per HTTP verb on a resource, e.g. `Books/PostBooksTests.cs`.
- Test method names follow `Verb_Condition_ExpectedResult`.

## Where to look

- Agents: `.github/agents/*.agent.md`
- Skills: `.github/skills/*/SKILL.md` (templates live in each skill's `references/` folder).
