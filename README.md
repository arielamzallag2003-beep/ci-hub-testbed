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
