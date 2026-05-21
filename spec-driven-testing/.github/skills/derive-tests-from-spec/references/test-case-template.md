### Test case `TC-<NN>`

- **Covers:** AC #<n> (and/or `METHOD /path` from OpenAPI)
- **Name:** `Verb_Condition_ExpectedResult`
- **Type:** integration | unit
- **Arrange:** Preconditions to set up (seeded books, request body, headers).
- **Act:** The single HTTP call or method invocation under test.
- **Assert:**
  - Status code: `<code>`
  - Body shape: `<json schema or specific field assertions>`
  - Side effects: `<what should now be true of the system, e.g. "GET /books/{id} returns 404">`
- **Notes:** anything ambiguous in the source, or boundary cases this represents.
