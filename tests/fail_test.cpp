#include <cstdio>
#include <cstdlib>

#include "mathx.h"

// DELIBERATELY WRONG. 2 + 2 is 4, not 5.
// Exists so that CI has something real to catch.
int main() {
  const int actual = add(2, 2);
  const int expected = 5;
  if (actual != expected) {
    std::printf("cpp_fail_on_purpose: expected %d, got %d\n", expected, actual);
    return EXIT_FAILURE;
  }
  return EXIT_SUCCESS;
}
