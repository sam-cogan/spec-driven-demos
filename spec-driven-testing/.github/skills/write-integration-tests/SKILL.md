---
name: write-integration-tests
description: Implement test cases as runnable xUnit integration tests against the ASP.NET Core API using WebApplicationFactory.
argument-hint: <test-plan-path>
---

# Skill: write-integration-tests

You are turning declarative test cases into runnable code. Follow the structure in [`references/test-class-template.cs`](./references/test-class-template.cs) and the assertion style in [`references/assertion-patterns.md`](./references/assertion-patterns.md).

## Process

1. **Read** the test plan at `docs/specs/<slug>/test-plan.md`.
2. **Group cases by endpoint group** — one file per HTTP verb on the resource, e.g. `Books/PostBooksTests.cs`, `Books/GetBooksTests.cs`.
3. **For each test case in the plan**, add one `[Fact]` to the matching file. Use the case's `Name` field verbatim as the method name.
4. **Use the shared fixture pattern** from the template so each test class spins up its own `WebApplicationFactory<Program>` and HTTP client.
5. **Assert both status code AND body** — never just one. Use `FluentAssertions` for body assertions.
6. **Run** `dotnet test` after writing each file. Do not move on until the file at least compiles.

## What you may NOT do

- Modify product code under `src/` — that is the developer's job, not yours.
- Modify the spec, the OpenAPI document, or the test plan to make a test pass.
- Skip or `[Fact(Skip = "...")]` a failing test without an explicit instruction.
- Share state between tests in the same class via static fields or fixtures.

## Quality bar

- Every test case in the plan is implemented.
- Every test method's name encodes the condition and expected result.
- Test failures point clearly at one production behaviour, not at test plumbing.
