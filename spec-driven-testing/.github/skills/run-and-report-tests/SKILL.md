---
name: run-and-report-tests
description: Run dotnet test, parse the result, and produce a short report mapping each failure back to the spec acceptance criterion (or OpenAPI operation) it covers.
---

# Skill: run-and-report-tests

## Process

1. Run `dotnet test --nologo -v minimal` from the repo root.
2. Capture the summary line (`Passed: N, Failed: N, Skipped: N`).
3. For each failing test, locate it in `docs/specs/<slug>/test-plan.md` (test name = case `Name`). Read its `Covers:` line to determine which AC or OpenAPI operation it represents.
4. Write a report at `docs/specs/<slug>/test-results.md` using the structure in [`references/test-results-template.md`](./references/test-results-template.md).
5. Do **not** modify product code or tests in response to failures — that is the developer's or test-analyst's call.

## Reporting bar

- Each failing AC is listed once with the failing test(s) and the assertion that failed.
- Coverage gap (AC with no passing or failing test) is flagged as `MISSING COVERAGE`.
- A green run still produces a report so the trail is reproducible.
