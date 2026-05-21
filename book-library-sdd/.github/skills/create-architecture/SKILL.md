---
name: create-architecture
description: Produce a technical architecture document for an approved spec, including components, data model, API contract, and Mermaid diagrams. Use after a spec is approved and before an implementation plan is created.
argument-hint: <slug or path to spec.md>
---

# Create Architecture

Translate an approved spec into a concrete, buildable design that fits this codebase.

## Steps

1. **Read the spec** at `docs/specs/<slug>/spec.md`. Confirm `Status:` is `reviewed` or `approved`. If not, stop and notify the user.
2. **Explore the codebase** for existing components/interfaces the design must integrate with (use `search` and `usages`).
3. **Write** `docs/specs/<slug>/architecture.md` using the structure in [`references/architecture-template.md`](./references/architecture-template.md) — keep every section heading, replace the placeholders.
4. **Self-check against the review checklist** in [`review-spec`](../review-spec/SKILL.md).
5. Offer the "Create implementation plan" handoff.

## Anti-patterns to avoid

- Introducing a database when the rest of the app is in-memory (unless the spec demands persistence).
- Adding layers (services, mappers, repositories) that wrap a single call.
- Speculative interfaces "for future extensibility".
