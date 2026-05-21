# Test Results: <Feature title>

- **Test plan:** [test-plan.md](./test-plan.md)
- **Run at:** <YYYY-MM-DD HH:MM>
- **Command:** `dotnet test --nologo -v minimal`
- **Result:** PASS | FAIL
- **Totals:** Passed: N, Failed: N, Skipped: N

## Coverage map

| AC # / Operation | Test(s) | Result |
|------------------|---------|--------|
| AC #1 | `GetBooks_WhenCatalogueHasBooks_Returns200WithArray` | ✅ |
| AC #5 (empty title) | `Post_WithEmptyTitle_Returns400` | ❌ — got 201, expected 400 |
| AC #11 | _none_ | ⚠️ MISSING COVERAGE |

## Failure details

### `Post_WithEmptyTitle_Returns400`

- **Covers:** AC #5
- **Expected:** `400 Bad Request`, body unchanged
- **Actual:** `201 Created`, book persisted with empty title
- **Hypothesis:** Implementation does not validate `CreateBookRequest.Title`. Hand back to test-analyst / developer triage.
