#include <cstdlib>

#include "mathx.h"

// This one is correct and must pass.
int main() {
  if (add(2, 3) != 5) return EXIT_FAILURE;
  if (multiply(4, 5) != 20) return EXIT_FAILURE;
  return EXIT_SUCCESS;
}
