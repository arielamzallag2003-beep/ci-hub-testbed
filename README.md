# ci-hub testbed

A deliberately messy repository used to exercise
[ci-hub](https://github.com/arielamzallag2003-beep/ci-hub) end to end.

It contains five stacks at once, and **some things are wrong on purpose**.

| Stack | Location | Expected result |
| --- | --- | --- |
| C++ (CMake) | `CMakeLists.txt`, `src/`, `tests/` | **FAILS** — `src/mathx.cpp` violates `.clang-format` |
| .NET | `Testbed.sln`, `dotnet/` | passes — 4 tests, all green |
| Python | `python/` | passes — CodeQL and hygiene only |
| Node | `web/` | passes — CodeQL and hygiene only |
| Rust | `rust/` | passes — hygiene only, no build step in v1 |

Also deliberate:

- `bin/tool.exe`, `bin/output.dll` and `data/blob.bin` are committed build
  artifacts, so hygiene has something to warn about. Warnings must **not**
  fail the run.
- `.gitignore` deliberately does not cover them.

### History

The repository is edited in phases to exercise different paths:

1. **Failing tests** — `2 + 2 == 5` in C++ and `10 / 4 == 3` in .NET.
   Result: red, with `ci-ok` reporting `CI failed in: cpp dotnet`. Confirmed.
2. **Failing format** — tests fixed, but `src/mathx.cpp` deliberately
   misformatted. The C++ job must fail at the format check and upload a
   `format-patch-cpp` artifact **without modifying the file**.
3. **All green** — apply the patch.
4. **Docs-only pull request** — change nothing but `docs/`.

## What this testbed found

Running it end to end surfaced two real bugs in the hub, both of which only a
repository like this one could expose:

| Bug | How it showed up | Fixed in |
| --- | --- | --- |
| `dependency-review-action` hard-failed when a repository has the dependency graph disabled — a *setting*, not a property of the code | every pull request went red | `v1.0.2` |
| Docs-only pull requests never actually skipped anything: `fetch-depth: ${{ ... && 0 \|\| 1 }}` collapses to `1` because GitHub treats `0` as falsy, so the shallow clone hid the base commit and the diff failed silently | a docs-only PR ran full C++ and .NET builds, 154s | `v1.0.3` |
| CodeQL still ran on docs-only changes, over four unchanged languages | 617s for a one-paragraph docs edit | `v1.0.4` |

Verified results, in order:

| Phase | `ci-ok` | Detail |
| --- | --- | --- |
| Failing tests | red | `CI failed in: cpp dotnet` — named exactly the two, nothing else |
| Failing format | red | C++ failed at the format check; `format-patch-cpp` artifact uploaded; **the repository was not modified** |
| Patch applied | green | `git apply format.patch` applied cleanly |
| Docs-only PR | green | builds and CodeQL skipped; 47s of job time instead of ~10 minutes |

Throughout, hygiene warned about the committed artifacts in `bin/` and `data/`
without ever failing the run, and no bot commit was ever made.
