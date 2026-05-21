# spec-driven-demos

A collection of demos showing spec-driven development with GitHub Copilot custom agents and skills.

Open the specific demo folder in VS Code to use its agents, skills, and Copilot instructions.

## Demos

- [book-library-sdd](./book-library-sdd/) — .NET 9 Minimal API for a book library, built end-to-end via the spec-driven workflow (product analyst → tech lead → solution architect → developer).
- [spec-driven-testing](./spec-driven-testing/) — Same book-library API, but already implemented. Demonstrates using a written spec **and** an OpenAPI document to drive the creation of a complete xUnit test suite via dedicated `test-analyst` and `test-engineer` agents.
- [spec-driven-speckit](./spec-driven-speckit/) — Same book-library API again, already implemented. Demonstrates dropping the off-the-shelf [GitHub Spec Kit](https://github.com/github/spec-kit) into an **existing** project (brownfield) and using it to add a new feature (book reservations) via the `/speckit.constitution`, `/speckit.specify`, `/speckit.plan`, `/speckit.tasks`, and `/speckit.implement` workflow.
