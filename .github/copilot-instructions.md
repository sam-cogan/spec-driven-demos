# BookLibrary — Spec-Driven Development Demo

Repository-wide guidance for GitHub Copilot. These instructions apply to **all** chat requests in this workspace.

## What this repo is

This repo demonstrates a **spec-driven development (SDD)** workflow using GitHub Copilot custom agents and skills. The application is a small .NET 9 Web API (`src/BookLibrary.Api`) that manages a library of books. New features must flow through the spec-driven pipeline before any code is written.

## The spec-driven workflow

Every meaningful feature follows this pipeline. Each step has a persona (agent) and produces a markdown artifact in `docs/`:

1. **Issue → Spec** — `product-analyst` agent uses the `create-spec` skill to convert a GitHub issue into a `docs/specs/<slug>/spec.md` (user stories, acceptance criteria, scope, non-goals).
2. **Spec review** — `tech-lead` agent uses the `review-spec` skill to validate the spec for clarity, completeness, and testability. Findings are added as a "Review" section to the spec.
3. **Spec → Architecture** — `solution-architect` agent uses the `create-architecture` skill to produce `docs/specs/<slug>/architecture.md` (components, data model, API contract, sequence diagrams in Mermaid).
4. **Architecture → Plan** — `tech-lead` agent uses the `create-implementation-plan` skill to produce `docs/specs/<slug>/plan.md` (ordered, checkbox-style tasks).
5. **Plan → Code** — `developer` agent uses the `implement-task` skill to implement tasks one at a time, checking them off the plan.
6. **Validate** — `tech-lead` agent uses the `validate-against-spec` skill to confirm the implementation satisfies every acceptance criterion in the spec.

Handoffs between agents are defined in each `.agent.md` frontmatter so the chat surfaces a button for the next step.

## Code conventions

- Target framework: **.NET 9**, C# 12, nullable enabled, implicit usings on.
- API style: **ASP.NET Core Minimal APIs**. Group endpoints with `MapGroup` + an extension method per feature folder (see `Books/BookEndpoints.cs`).
- Storage: keep the in-memory store pattern (`IXxxStore` + `InMemoryXxxStore`) until a feature spec explicitly requires persistence.
- Records for DTOs and entities. `Guid` keys.
- Tests (when added): xUnit + `WebApplicationFactory` for integration tests. Place under `tests/BookLibrary.Api.Tests`.
- Folder structure: feature-first. New feature `X` lives under `src/BookLibrary.Api/X/`.

## Spec artifact conventions

- One folder per feature: `docs/specs/<kebab-case-slug>/`.
- Required files in order of creation: `spec.md`, `architecture.md`, `plan.md`.
- Every artifact starts with a YAML-ish header: `Issue:` link, `Status:` (`draft|reviewed|approved|implemented`), `Owner:` (agent name).
- Use Mermaid for diagrams (sequence, component, ER).

## Working with agents

- Don't skip steps. If a spec doesn't exist, **stop** and create one via the `product-analyst` agent — do not start coding.
- Each agent has a restricted toolset to enforce the workflow. If a tool is missing, you're probably in the wrong agent.
- When implementing, only check off plan items you have actually completed and verified (build passes, tests pass).

## See also

- [Demo walkthrough](docs/demo-script.md)
- [`docs/specs/`](docs/specs/) for in-flight features
- Agents: [`.github/agents/`](.github/agents/)
- Skills: [`.github/skills/`](.github/skills/)
