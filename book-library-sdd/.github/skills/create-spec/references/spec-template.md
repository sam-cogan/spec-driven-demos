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

## 3. Functional requirements

What the system must **do** — the behaviours, rules, and capabilities the feature delivers. Numbered, prefixed `FR-`.

- **FR-1.** ...
- **FR-2.** ...

## 4. Non-functional requirements

How the system must **behave** — performance, security, availability, accessibility, observability, compliance, data retention, etc. Numbered, prefixed `NFR-`. Each must be measurable (include a target value where possible) and grouped by category.

### 4.1 Performance & scalability

- **NFR-1.** e.g. p95 response time for `<operation>` ≤ 200 ms at 50 RPS.

### 4.2 Security & privacy

- **NFR-2.** e.g. all endpoints require authenticated callers; PII is never logged.

### 4.3 Reliability & availability

- **NFR-3.** e.g. feature must degrade gracefully if `<dependency>` is unavailable.

### 4.4 Observability

- **NFR-4.** e.g. every state change emits a structured log with correlation ID.

### 4.5 Accessibility & UX (if applicable)

- **NFR-5.** e.g. WCAG 2.2 AA for any new UI.

### 4.6 Compliance & data handling (if applicable)

- **NFR-6.** e.g. reservation records retained for 12 months then purged.

> Delete any category that genuinely doesn't apply, but state explicitly that you considered it.

## 5. Acceptance criteria

Numbered, Given/When/Then. Each criterion must trace to one or more `FR-` or `NFR-` IDs and must be observable and testable. Include criteria for non-functional behaviour (e.g. performance thresholds, auth failures) — not just happy-path functional flows.

1. **AC-1** (covers FR-1) — **Given** ... **when** ... **then** ...
2. **AC-2** (covers NFR-1) — **Given** ... **when** ... **then** ...
3. ...

## 6. In scope

- ...

## 7. Out of scope / non-goals

- ...

## 8. Open questions

- [ ] Question for stakeholders ...

## 9. Success metrics (optional)

How will we know this is working in production?
