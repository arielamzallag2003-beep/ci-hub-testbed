#include <cstdio>
#include <cstdlib>

#include "mathx.h"

// Fixed: the expectation now matches reality.
int main() {
  const int actual = add(2, 2);
  const int expected = 4;
  if (actual != expected) {
    std::printf("cpp_now_correct: expected %d, got %d\n", expected, actual);
    return EXIT_FAILURE;
  }
  return EXIT_SUCCESS;
}
