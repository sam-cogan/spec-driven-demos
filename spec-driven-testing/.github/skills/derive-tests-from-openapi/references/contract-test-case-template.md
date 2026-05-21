### Contract test `CT-<NN>`

- **Operation:** `METHOD /path` (`operationId` if available)
- **Source:** OpenAPI response `<code>` / schema `<name>` / required field `<field>` / constraint `<rule>`
- **Also covers:** AC #<n> (if applicable)
- **Name:** `Verb_Condition_ExpectedResult`
- **Arrange:** Request body / path params / headers — including the *specific* constraint-violating or constraint-satisfying value.
- **Act:** The single HTTP call under test.
- **Assert:**
  - Status code: `<code>`
  - Response body conforms to schema: `<schema name>`
  - For error responses, any `problem+json` shape expected.
- **Notes:** boundary value, equivalence class, or pattern example used.
