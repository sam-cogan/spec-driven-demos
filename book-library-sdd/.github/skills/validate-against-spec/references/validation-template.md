# Validation: <Feature title>

- **Spec:** [spec.md](./spec.md)
- **Plan:** [plan.md](./plan.md)
- **Validated:** <YYYY-MM-DD>
- **Result:** PASS | FAIL

## Build & tests

- `dotnet build` — ✅ / ❌
- `dotnet test` — ✅ / ❌ (n passed, n failed)

## Acceptance criteria

| AC # | Description | Method | Result | Notes |
|------|-------------|--------|--------|-------|
| 1 | ... | `curl -X POST ...` | ✅ | 201 Created, body matches |
| 2 | ... | integration test `XxxTests.Should...` | ❌ | Got 500, expected 409 |

## Failures (if any)

- AC #2 — root cause hypothesis, suggested next step.
