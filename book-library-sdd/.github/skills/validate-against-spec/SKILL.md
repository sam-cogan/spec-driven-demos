---
name: validate-against-spec
description: Verify that an implemented feature satisfies every acceptance criterion in its spec by running the API, exercising endpoints, and inspecting behaviour. Produces a validation report in the spec folder. Use as the final gate before closing a feature.
argument-hint: <slug>
---

# Validate Against Spec

Confirm the work is actually done — by running it, not by reading it.

## Steps

1. **Read** `docs/specs/<slug>/spec.md` and extract every numbered acceptance criterion.
2. **Confirm the plan is fully checked off** in `plan.md`. If not, stop and report.
3. **Build** the project. Must succeed cleanly.
4. **Run** the API locally (`dotnet run --project src/BookLibrary.Api`) or run the integration test suite if one exists.
5. **Exercise each acceptance criterion.** Use `curl`, the `.http` file, or tests. For each AC, record: command/test used, expected, actual, pass/fail.
6. **Write the validation report** at `docs/specs/<slug>/validation.md` using the structure in [`references/validation-template.md`](./references/validation-template.md).
7. **Update statuses.** If all AC pass, set `Status:` in `spec.md` to `implemented`. Otherwise list failures and hand back to the `developer`.

## Bar

- A criterion is only ✅ if you actually executed something that proves it.
- Don't infer success from "the code looks right".
