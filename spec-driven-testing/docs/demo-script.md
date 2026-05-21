# Demo script — spec-driven-testing

**Setup:** Open the `spec-driven-testing` folder directly in VS Code (not the repo root) so the `.github/` agents/skills/copilot-instructions are picked up.

**Premise:** "A good spec is already a test plan." The `BookLibrary.Api` is already implemented. We have a markdown spec *and* an OpenAPI document. We are going to drive the test suite from both, in parallel.

---

## Act 1 — Show the state of play (~2 min)

1. Show the tree: implementation under `src/`, spec under `docs/specs/books-crud/spec.md`, contract at `docs/openapi.json`, empty test project under `tests/`.
2. Open `spec.md` and point at section 3: 11 numbered acceptance criteria — these are the test cases waiting to be written.
3. Open `docs/openapi.json` and point at the documented `400`, `404`, `409` responses and the schema constraints (`pattern`, `minimum: 1`).

## Act 2 — Derive a test plan from the spec (~3 min)

1. Invoke `@test-analyst` and ask: *"Use the markdown spec at `docs/specs/books-crud/spec.md` to produce a test plan."*
2. The agent uses the [`derive-tests-from-spec`](.github/skills/derive-tests-from-spec/SKILL.md) skill and writes `docs/specs/books-crud/test-plan.md` with one or more test cases per AC.
3. Read out the test plan together. Highlight that AC #5 ("empty title, empty author, malformed isbn, copiesTotal < 1") produces *four* test cases, not one.

## Act 3 — Add coverage from the OpenAPI doc (~3 min)

1. Ask `@test-analyst`: *"Now extend the test plan with contract tests derived from `docs/openapi.json`. De-duplicate against the existing spec-derived tests."*
2. The agent uses [`derive-tests-from-openapi`](.github/skills/derive-tests-from-openapi/SKILL.md) and appends a new section to the same `test-plan.md`.
3. Talking point: the OpenAPI doc gives us boundary tests (`copiesTotal: 0` vs `1`) that the prose spec did not spell out. The two sources are *complementary*, not redundant.

## Act 4 — Implement the tests (~4 min)

1. Hand off (or invoke directly): `@test-engineer` — *"Implement the test plan."*
2. The agent uses [`write-integration-tests`](.github/skills/write-integration-tests/SKILL.md) to add `[Fact]`s to `tests/BookLibrary.Api.Tests/Books/*.cs`, one file per HTTP verb.
3. Show one of the files. Point out the consistent `Verb_Condition_ExpectedResult` naming and the AC reference in the comment above each test.

## Act 5 — Run and report (~3 min)

1. Run `dotnet test` (or ask `@test-engineer` to do it via [`run-and-report-tests`](.github/skills/run-and-report-tests/SKILL.md)).
2. **Expect some failures**: the current implementation does not validate input (AC #5, #8) and does not reject duplicate ISBNs (AC #11). The tests caught a real gap.
3. Open `docs/specs/books-crud/test-results.md` and show:
   - Coverage map (AC → test → ✅/❌).
   - Failure details that point straight at AC #5 and AC #11.
4. Punchline: *the spec wrote the test plan, the tests revealed the missing behaviour, and the report tells the developer exactly which AC to satisfy.*

---

## Talking points

- The spec-driven workflow lets a junior engineer or an AI agent produce comprehensive coverage that mirrors the requirements 1:1, without guessing.
- Two sources of specification (prose + OpenAPI) are better than one. Each catches what the other misses.
- The agents enforce separation of concerns: the test-analyst never writes code, the test-engineer never touches production code.
