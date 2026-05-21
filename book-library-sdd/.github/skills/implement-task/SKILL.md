---
name: implement-task
description: Execute the next unchecked task from a feature's implementation plan, build the project, run tests, and check the task off. Use repeatedly during the implementation phase until all tasks are complete.
argument-hint: <slug or path to plan.md>
---

# Implement Task

Work the plan, one task at a time, keeping the build green.

## Steps

1. **Locate the plan.** Open `docs/specs/<slug>/plan.md`.
2. **Pick the next unchecked task.** Do not skip tasks. If the next task is unclear or wrong, stop and ask.
3. **Re-read the relevant section of `architecture.md`** for that task only.
4. **Implement.** Touch only the files listed for that task, plus any obviously needed wire-up. Follow the conventions in `.github/copilot-instructions.md`.
5. **Build.** `dotnet build src/BookLibrary.Api/BookLibrary.Api.csproj`. Fix any errors before continuing.
6. **Test.** If there are tests, run them. If the task is to add a test, run it and confirm it passes (or fails as expected for TDD).
7. **Verify the "Done when" check** listed under the task.
8. **Check the task off** in `plan.md` (change `[ ]` to `[x]`).
9. **Stop and report.** Tell the user what was done, what file(s) changed, and what the next task is. Do **not** start the next task unless explicitly asked.

## Rules

- **Build must pass.** A red build means the task isn't done.
- **No scope expansion.** If you spot something else worth fixing, add it as a new checkbox at the bottom of the plan under "Out-of-plan changes", don't fix it inline.
- **No silent edits to the spec or architecture.** If you find a real design problem, surface it and hand back to the `tech-lead` or `solution-architect`.
- **Match existing code style.** Records, file-scoped namespaces, minimal APIs, feature folders.
