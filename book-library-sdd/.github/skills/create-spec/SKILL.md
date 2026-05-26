---
name: create-spec
description: Convert a GitHub issue or feature idea into a structured, testable feature specification stored at docs/specs/<slug>/spec.md. Use whenever a new feature needs to be specified before any design or coding begins.
argument-hint: <issue-number-or-url-or-description>
---

# Create Spec

Produce a feature specification that is unambiguous, testable, and scoped.

## Steps

1. **Gather the source.** If given an issue number/URL, read the full issue and any linked discussion. If given a free-form description, treat it as the issue body.
2. **Derive a slug.** Lowercase, hyphenated, ≤ 4 words (e.g. `book-reservations`, `overdue-notifications`).
3. **Create the folder and file.** Path: `docs/specs/<slug>/spec.md`.
4. **Fill in the template.** Use [`references/spec-template.md`](./references/spec-template.md) as the exact structure — replace the placeholders, keep the section headings.
5. **Separate functional and non-functional requirements.**
   - **Functional (`FR-`)**: what the feature must *do* — behaviours, rules, capabilities.
   - **Non-functional (`NFR-`)**: how it must *behave* — performance, security, reliability, observability, accessibility, compliance, data retention. Walk every NFR category in the template; for any you exclude, say so explicitly rather than silently dropping it.
   - Every requirement gets a stable ID so acceptance criteria can trace back to it.
6. **Write acceptance criteria that cover both.** At minimum one AC per functional requirement, plus ACs for measurable non-functional requirements (e.g. "p95 latency", "unauthenticated request returns 401"). Each AC cites the `FR-`/`NFR-` IDs it covers.
7. **Flag ambiguity, do not invent.** If a requirement (functional or non-functional) is unclear, list it under "Open Questions" — never silently fill it in. Common NFR ambiguities to surface: expected load, auth model, SLOs, data sensitivity.
8. **Stop after writing the spec.** Do not propose a design. Offer the "Review this spec" handoff.

## Quality bar

Before finishing, self-check:

- [ ] Functional requirements (`FR-`) and non-functional requirements (`NFR-`) are in separate sections, each with stable IDs.
- [ ] Every NFR category in the template is either populated or explicitly marked as "not applicable" with a one-line reason.
- [ ] Non-functional requirements are measurable (numeric target, observable condition, or named standard) — no "fast", "secure", "reliable" without a definition.
- [ ] Every acceptance criterion is in Given/When/Then form and cites the `FR-`/`NFR-` IDs it covers.
- [ ] At least one acceptance criterion covers a non-functional requirement (not just happy-path behaviour).
- [ ] No solution language (no "use Postgres", no "add a /reserve endpoint").
- [ ] Non-goals section is non-empty.
- [ ] At least one open question OR a note stating "no open questions".
