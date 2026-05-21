# Demo script — spec-driven-speckit

**Premise:** Drop GitHub Spec Kit into an *existing* .NET project and use it to
drive a brand-new feature (book reservations) all the way to working code.

**Setup:** Open the `spec-driven-speckit/` folder directly in VS Code so all
Spec Kit-generated files (`.specify/`, `memory/`, `.github/prompts/`, `specs/`)
land in the right place. Sign in to GitHub Copilot.

---

## Act 0 — Show the starting point (~1 min)

1. Tree view: only `src/BookLibrary.Api/`, `feature-ideas/book-reservations.md`,
   `README.md`. No spec folder, no constitution, no Spec Kit files.
2. Open `feature-ideas/book-reservations.md` — read out the one-paragraph
   description and the "open questions" section. That is the *entire* input.

## Act 1 — Install Spec Kit into the existing project (~2 min)

1. Install the CLI (one-time per machine):

   ```bash
   # uv is a prerequisite — install from https://docs.astral.sh/uv/ if needed.
   uv tool install specify-cli --from git+https://github.com/github/spec-kit.git
   specify --version
   ```

2. Initialise Spec Kit *in the current directory* (this is the brownfield bit):

   ```bash
   # --here          : init in the current directory (don't create a subfolder)
   # --integration   : use Copilot's slash commands
   # --force         : the directory already has files (src/, README.md, etc.)
   # --no-git        : we're inside an outer monorepo; don't init a nested repo
   specify init --here --integration copilot --force --no-git
   ```

   > **About `--no-git`:** this only skips `git init`. Spec Kit's runtime git
   > integration — the branch `/speckit.specify` creates and the commits it
   > makes — still works, because git resolves to the **outer** `spec-driven-demos`
   > repo. The feature branch (e.g. `001-book-reservations`) will be created
   > there. If you are running this demo standalone (this folder cloned on its
   > own, not inside the parent monorepo), drop `--no-git` so Spec Kit can
   > initialise a fresh repo for you.

3. Show what got added in the file tree:
   - `.specify/` — templates, scripts, configuration.
   - `memory/constitution.md` — the (empty) constitution waiting to be populated.
   - `.github/prompts/speckit.*.prompt.md` — the slash-command definitions
     Copilot will use.
4. Talking point: nothing under `src/` was touched. Spec Kit is non-invasive.

## Act 2 — Establish the constitution (~3 min)

1. In Copilot Chat, run:

   ```
   /speckit.constitution Create governing principles for a small .NET 9 Minimal
   API codebase: feature-folder layout, in-memory stores behind interfaces,
   integration tests with WebApplicationFactory, explicit input validation,
   problem+json error responses, no premature persistence layer, and a strict
   spec-first workflow.
   ```

2. Show the populated `memory/constitution.md`. Read the highlights — these
   principles will now constrain every plan Spec Kit produces.
3. Commit the constitution so the trail is preserved.

## Act 3 — Generate the specification (~4 min)

1. In Copilot Chat:

   ```
   /speckit.specify Use the description in feature-ideas/book-reservations.md
   as the feature input. Members can reserve books, reservations form a FIFO
   queue per book, the head of the queue is fulfilled when a copy is returned,
   members can cancel their own reservations, librarians can view any queue.
   ```

2. Spec Kit will:
   - Decide the next feature number (e.g. `001-book-reservations`).
   - Create a Git branch `001-book-reservations` and switch to it.
   - Create `specs/001-book-reservations/spec.md` populated from its template.
   - Mark every assumption it could not make with `[NEEDS CLARIFICATION: ...]`.

3. Open the generated spec and walk through the `[NEEDS CLARIFICATION]`
   markers — these are exactly the open questions the feature idea file
   highlighted.

4. **Optional but recommended:**

   ```
   /speckit.clarify
   ```

   Spec Kit will interview you on each ambiguity and update the spec in place.
   Answer the questions live:
   - One member cannot reserve the same book twice.
   - A fulfilled reservation is held for 48 hours before it expires.
   - Deleting a book cancels all its outstanding reservations.

## Act 4 — Produce the implementation plan (~4 min)

1. In Copilot Chat:

   ```
   /speckit.plan Reuse the existing .NET 9 Minimal API in src/BookLibrary.Api.
   Add a Reservations feature folder mirroring the Books folder. Use an
   IReservationStore interface with an in-memory implementation backed by a
   ConcurrentDictionary keyed by bookId. Expose endpoints under /books/{id}/
   reservations. Wire fulfilment into the existing Books update path so when
   CopiesAvailable goes up the head of the queue is fulfilled.
   ```

2. Spec Kit generates:
   - `specs/001-book-reservations/plan.md` — high-level plan that passes the
     constitution's simplicity and integration-first gates.
   - `specs/001-book-reservations/research.md` — any technical research the
     plan relied on.
   - `specs/001-book-reservations/data-model.md` — `Reservation` entity, fields,
     invariants.
   - `specs/001-book-reservations/contracts/` — OpenAPI snippets for the new
     endpoints.
   - `specs/001-book-reservations/quickstart.md` — manual validation script.

3. Skim each generated file. Talking point: notice how every technical decision
   in `plan.md` cites either a spec acceptance criterion or a constitutional
   article.

## Act 5 — Generate the task list (~2 min)

1. In Copilot Chat:

   ```
   /speckit.tasks
   ```

2. Show `specs/001-book-reservations/tasks.md`. Point out:
   - Tests come **before** implementation (test-first article of the constitution).
   - Tasks marked `[P]` can run in parallel.
   - Every task references the file(s) it will create.

3. **Optional sanity check** before implementing:

   ```
   /speckit.analyze
   ```

   Cross-artefact consistency check across spec, plan, and tasks.

## Act 6 — Implement (~5 min)

1. In Copilot Chat:

   ```
   /speckit.implement
   ```

2. Spec Kit executes the task list end-to-end. Show:
   - New files appearing under `src/BookLibrary.Api/Reservations/`.
   - A new test project (or test files) being created and tests being written
     *first*.
   - `dotnet test` being run as part of the implementation.

3. When it finishes, run yourself:

   ```bash
   dotnet test
   dotnet run --project src/BookLibrary.Api
   ```

   Hit the new endpoints from `BookLibrary.Api.http` or `curl` to demonstrate
   the feature is live.

4. Show the Git history on the `001-book-reservations` branch — every artefact
   and the implementation are committed with clear messages.

---

## Talking points

- **Brownfield, not greenfield.** Spec Kit dropped into a 200-line existing app
  without touching its code and drove a new feature end-to-end.
- **The constitution is the architectural memory.** Every subsequent plan
  Spec Kit generates is checked against it automatically.
- **One feature, one branch, one folder.** `specs/NNN-feature-name/` keeps every
  artefact for a feature versioned together.
- **Compared to the other demos in this repo:** demo 1 (`book-library-sdd`)
  showed a hand-rolled spec-driven workflow with custom agents and skills.
  Demo 2 (`spec-driven-testing`) showed using specs to drive test creation.
  This demo shows what an off-the-shelf spec-driven toolkit does for the same
  problem.

---

## Reference — How Spec Kit uses Git and folders

A short cheat-sheet of what Spec Kit does to your repository so you know what
to expect (and what to commit).

### Files created at init time

`specify init --here --integration copilot` lays down:

| Path | Purpose | Commit? |
| --- | --- | --- |
| `.specify/` | Templates, scripts, and per-project config used by every slash command. | Yes |
| `memory/constitution.md` | Repo-wide governing principles. Populated by `/speckit.constitution`. | Yes |
| `.github/prompts/speckit.*.prompt.md` | One file per slash command (`constitution`, `specify`, `clarify`, `plan`, `tasks`, `analyze`, `implement`, …). This is how Copilot learns the commands. | Yes |
| `.specify/state/` (if present) | Local CLI state. | No — gitignore. |

Nothing under `src/` is touched at init time.

### What `/speckit.specify` does

1. Reads `.specify/` to find the **next feature number** using the configured
   `--branch-numbering` strategy (default: `sequential`, so `001`, `002`, …;
   alternative: `timestamp`).
2. Generates a kebab-case slug from your feature description, e.g.
   `book-reservations`.
3. Creates a Git branch named `NNN-slug` (e.g. `001-book-reservations`) from
   the current branch and **switches to it**.
4. Creates `specs/NNN-slug/` and writes `spec.md` from the template.
5. Commits the new spec on the new branch.

> If Spec Kit was initialised with `--no-git`, or you're in a non-git directory,
> set the `SPECIFY_FEATURE` env var (e.g. `export SPECIFY_FEATURE=001-book-reservations`)
> so subsequent slash commands know which feature folder to operate on. With
> git, the current branch name is used automatically.

### What ends up in `specs/NNN-slug/`

One folder per feature, all artefacts together:

```
specs/
└── 001-book-reservations/
    ├── spec.md           ← /speckit.specify (+ updates from /speckit.clarify)
    ├── plan.md           ← /speckit.plan
    ├── research.md       ← /speckit.plan
    ├── data-model.md     ← /speckit.plan
    ├── contracts/        ← /speckit.plan (OpenAPI fragments, etc.)
    ├── quickstart.md     ← /speckit.plan
    ├── tasks.md          ← /speckit.tasks
    └── checklists/       ← /speckit.checklist (optional)
```

Each slash command after `/speckit.specify` operates on the feature folder
matching the **current branch**. Switching branches switches "active feature".

### Branch lifecycle

```
main ──●────────────────────────────●──── (merge PR) ────●────►
        \                          /
         ●──●──●──●──●──●──●──●──●     001-book-reservations
         ↑   ↑      ↑      ↑     ↑
         |   |      |      |     └─ /speckit.implement commits
         |   |      |      └─ /speckit.tasks
         |   |      └─ /speckit.plan (multiple commits)
         |   └─ /speckit.clarify (updates spec.md)
         └─ /speckit.specify creates branch + spec.md
```

- Branch creation, checkout, and commits are all done by Spec Kit.
- Merging back to `main` is **your** job — typically via a normal PR. Spec Kit
  never pushes or opens PRs on its own.
- The `memory/constitution.md` change is usually committed on `main` (or its
  own branch) **before** running `/speckit.specify`, because it applies to
  every feature thereafter.

### Multiple features in flight

Each feature lives on its own branch and in its own `specs/NNN-…/` folder, so
they don't collide. To work on a second feature in parallel:

```bash
git checkout main
# in Copilot Chat:
/speckit.specify Add overdue-loan notifications …
# → creates branch 002-overdue-loan-notifications and specs/002-…/
```

### Effect of `--no-git` in this monorepo

Because this demo lives inside the outer `spec-driven-demos` repo, we passed
`--no-git` at init time to avoid a nested `.git/`. The consequence:

- `/speckit.specify` creates the `001-book-reservations` branch on the **outer**
  repo, not on a per-demo repo.
- All Spec Kit commits land on that outer-repo branch.
- The `specs/001-book-reservations/` folder is scoped to this demo folder, so
  the diff is still localised; only the branch is shared.

If you instead cloned `spec-driven-speckit/` on its own, you would omit
`--no-git`, Spec Kit would `git init` a fresh repo, and branches would be
self-contained.
