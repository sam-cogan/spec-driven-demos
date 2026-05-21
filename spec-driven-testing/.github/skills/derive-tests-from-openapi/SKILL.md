---
name: derive-tests-from-openapi
description: Read an OpenAPI document and turn every documented path × method × response (including error responses) and every schema constraint into a concrete contract test case.
argument-hint: <path-to-openapi.json-or-yaml>
---

# Skill: derive-tests-from-openapi

Use the OpenAPI document as the contract source. Every documented response is a behaviour the API promises — that promise must be tested.

## Process

1. **Load** the OpenAPI document at the given path (default: `docs/openapi.json`).
2. **Enumerate** every operation as `METHOD path`. For each operation:
   - List every documented response code (`200`, `201`, `400`, `404`, `409`, ...).
   - List every required request property and every schema constraint (`minLength`, `pattern`, `minimum`, `enum`).
3. **For each row, derive test cases**:
   - One test per documented response code.
   - One test per `required` property → omit it → expect the documented validation response (usually `400`).
   - One test per schema constraint boundary (e.g. `minimum: 1` → test with `0` and with `1`).
   - One test per `pattern` → both a matching and a non-matching example.
4. **Write** each test case using the structure in [`references/contract-test-case-template.md`](./references/contract-test-case-template.md).
5. **Append** to `docs/specs/<slug>/test-plan.md` under the section "## Tests derived from OpenAPI".
6. **De-duplicate.** If a test case already exists from the markdown spec for the same behaviour, link to it rather than duplicating — note it with `(also covers AC #n)`.

## Quality bar

- Every operation has at least one test per documented response code.
- Every `required` field and every constraint is exercised both in the satisfying and violating direction.
- Tests reference the OpenAPI operation id or `METHOD path` so traceability is preserved.
