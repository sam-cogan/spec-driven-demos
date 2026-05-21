---
name: review-spec
description: Review a feature spec or architecture document against a quality checklist, then append a Review section to the file with findings and an approve / request-changes verdict. Use for any review gate in the spec-driven workflow.
argument-hint: <path to spec.md or architecture.md>
---

# Review Spec

Apply a rigorous, checklist-driven review and record the verdict in the file itself.

## Steps

1. Read the target file in full.
2. Run the checklist below.
3. Append a `## Review` section to the file with the date, your verdict, and itemised findings.
4. If verdict is **Request changes**, update `Status:` in the header to `draft`. If **Approve**, set it to `reviewed` (for specs) or `approved` (for architecture).
5. Summarise the verdict to the user with the next-step handoff.

## Checklist — for a spec

- **Clarity** — could a new engineer implement this without asking the author questions?
- **Testability** — is every acceptance criterion observable? Could you write a test for it today?
- **Scope** — are non-goals listed? Is the scope small enough to deliver in days, not weeks?
- **No solution leakage** — does the spec describe *what* and *why*, not *how*?
- **Consistency** — do user stories, acceptance criteria, and the problem statement align?
- **Open questions** — are unresolved assumptions called out rather than buried?

## Checklist — for an architecture

- **Spec coverage** — does every acceptance criterion in the spec map to something in the architecture?
- **Fits existing patterns** — does it follow the conventions in `.github/copilot-instructions.md`?
- **Alternatives considered** — is there at least one rejected alternative with a reason?
- **Diagrams present** — at least one Mermaid diagram (sequence or component)?
- **Data model defined** — entities, fields, types, identity strategy?
- **API contract defined** — for each new endpoint: method, route, request, response, status codes?
- **Failure modes** — what happens on invalid input, conflicts, concurrency?
- **No over-engineering** — no unused abstractions, no premature scaling concerns.

## Review section template

Append the Review section using the exact structure in [`references/review-section-template.md`](./references/review-section-template.md).

## Tone

Be specific. "Acceptance criterion #3 is not testable — what does 'soon' mean?" beats "Make criteria more testable."
