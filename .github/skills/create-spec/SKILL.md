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
4. **Fill in the template below.**
5. **Flag ambiguity, do not invent.** If a requirement is unclear, list it under "Open Questions" — never silently fill it in.
6. **Stop after writing the spec.** Do not propose a design. Offer the "Review this spec" handoff.

## Template

Use this exact structure. Replace placeholders, keep section headings.

```markdown
# Spec: <Feature title>

- **Issue:** <link or "n/a">
- **Status:** draft
- **Owner:** product-analyst
- **Created:** <YYYY-MM-DD>

## 1. Problem statement

One short paragraph. Who has the problem, what is the problem, why it matters now.

## 2. User stories

- As a <role>, I want <capability>, so that <outcome>.
- ...

## 3. Acceptance criteria

Numbered, Given/When/Then. Each must be observable and testable.

1. **Given** ... **when** ... **then** ...
2. ...

## 4. In scope

- ...

## 5. Out of scope / non-goals

- ...

## 6. Open questions

- [ ] Question for stakeholders ...

## 7. Success metrics (optional)

How will we know this is working in production?
```

## Quality bar

Before finishing, self-check:

- [ ] Every acceptance criterion is in Given/When/Then form.
- [ ] No solution language (no "use Postgres", no "add a /reserve endpoint").
- [ ] Non-goals section is non-empty.
- [ ] At least one open question OR a note stating "no open questions".
