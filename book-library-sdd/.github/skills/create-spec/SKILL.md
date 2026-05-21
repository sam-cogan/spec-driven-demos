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
5. **Flag ambiguity, do not invent.** If a requirement is unclear, list it under "Open Questions" — never silently fill it in.
6. **Stop after writing the spec.** Do not propose a design. Offer the "Review this spec" handoff.

## Quality bar

Before finishing, self-check:

- [ ] Every acceptance criterion is in Given/When/Then form.
- [ ] No solution language (no "use Postgres", no "add a /reserve endpoint").
- [ ] Non-goals section is non-empty.
- [ ] At least one open question OR a note stating "no open questions".
