---
name: create-implementation-plan
description: Break an approved architecture document into an ordered checklist of small, independently verifiable implementation tasks stored at docs/specs/<slug>/plan.md. Use after architecture is approved and before any code is written.
argument-hint: <slug or path to architecture.md>
---

# Create Implementation Plan

Produce a task list a developer can execute top-to-bottom without rethinking the design.

## Steps

1. Read `docs/specs/<slug>/architecture.md` (and the underlying `spec.md`).
2. Decompose the work into tasks. Each task must:
   - Touch a small, coherent slice (one file or a tight cluster).
   - Be independently buildable — the project compiles after each task.
   - Have a clear "done" check (file exists, endpoint returns 200, test passes).
3. Order tasks so that each one can rely on the previous ones being merged.
4. Write `docs/specs/<slug>/plan.md` using the template below.
5. Offer the "Start implementation" handoff.

## Ordering heuristic

1. Domain model / DTOs first.
2. Storage / interface and in-memory implementation next.
3. Endpoints / API surface.
4. Wire-up in `Program.cs`.
5. Tests (integration first, then unit).
6. Docs / README updates.

## Template

```markdown
# Implementation Plan: <Feature title>

- **Architecture:** [architecture.md](./architecture.md)
- **Status:** draft
- **Owner:** tech-lead
- **Created:** <YYYY-MM-DD>

## Tasks

> Check off each item only when the project builds and any associated tests pass.

- [ ] **1. <Task title>** — <one-sentence description>
  - Files: `path/to/file.cs`
  - Done when: <observable check>
- [ ] **2. ...**
  - Files: ...
  - Done when: ...

## Out-of-plan changes

Anything required that we discover during implementation goes here as a new checkbox — never edit existing tasks silently.
```

## Quality bar

- [ ] No task takes more than ~20 minutes of focused work.
- [ ] No task says "implement the feature" — that's not a task.
- [ ] Every acceptance criterion in the spec has at least one task that contributes to it.
- [ ] The last task is a validation step (run the API, hit the endpoint, confirm AC).
