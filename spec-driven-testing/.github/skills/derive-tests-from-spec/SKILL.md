---
name: derive-tests-from-spec
description: Read a markdown spec and turn every numbered acceptance criterion into one or more concrete test cases written into a test plan document.
argument-hint: <path-to-spec.md>
---

# Skill: derive-tests-from-spec

Treat the spec as a source of testable behaviours. Every acceptance criterion is at least one test.

## Process

1. **Load** the spec at the path given (default: `docs/specs/<slug>/spec.md`).
2. **Enumerate** every entry in the "## 3. Acceptance criteria" section. Keep their numbers.
3. **For each AC**, decide how many test cases it needs:
   - One happy path per AC.
   - One test per distinct failure mode the AC names ("empty title, empty author, malformed isbn, copiesTotal < 1" = 4 tests, not 1).
   - One test per boundary value the AC implies (e.g. `copiesTotal = 0` and `copiesTotal = 1` if the rule is "must be >= 1").
4. **Write** each test case using the structure in [`references/test-case-template.md`](./references/test-case-template.md).
5. **Append** all cases to the test plan at `docs/specs/<slug>/test-plan.md`, using the section "## Tests derived from spec".
6. **Cross-reference** every test case back to the AC number it covers, so missing coverage is visible.

## Quality bar

- Every AC is referenced by at least one test.
- No test references "the implementation" — only the spec and observable HTTP behaviour.
- Boundary, error, and happy paths are all listed explicitly.
