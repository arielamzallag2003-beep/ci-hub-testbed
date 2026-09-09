# ci-hub testbed

A deliberately messy repository used to exercise
[ci-hub](https://github.com/arielamzallag2003-beep/ci-hub) end to end.

It contains five stacks at once, and **some things are wrong on purpose**.

| Stack | Location | Expected result |
| --- | --- | --- |
| C++ (CMake) | `CMakeLists.txt`, `src/`, `tests/` | **FAILS** — `cpp_fail_on_purpose` asserts `2 + 2 == 5` |
| .NET | `Testbed.sln`, `dotnet/` | **FAILS** — `DividesCorrectly_FailsOnPurpose` asserts `10 / 4 == 3` |
| Python | `python/` | passes — CodeQL and hygiene only |
| Node | `web/` | passes — CodeQL and hygiene only |
| Rust | `rust/` | passes — hygiene only, no build step in v1 |

Also deliberate:

- `bin/tool.exe`, `bin/output.dll` and `data/blob.bin` are committed build
  artifacts, so hygiene has something to warn about. Warnings must **not**
  fail the run.
- `.gitignore` deliberately does not cover them.

A correct run of this repository is therefore **red**, with `ci-ok` naming
exactly the C++ and .NET jobs and nothing else.
