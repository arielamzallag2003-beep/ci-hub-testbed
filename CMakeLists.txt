cmake_minimum_required(VERSION 3.16)
project(testbed CXX)
set(CMAKE_CXX_STANDARD 17)

add_library(mathx src/mathx.cpp)
target_include_directories(mathx PUBLIC src)

add_executable(testbed_app src/main.cpp)
target_link_libraries(testbed_app PRIVATE mathx)

enable_testing()

add_executable(pass_test tests/pass_test.cpp)
target_link_libraries(pass_test PRIVATE mathx)
add_test(NAME cpp_pass COMMAND pass_test)

# Deliberately wrong expectation. This test MUST fail: it is how we prove the
# hub reports a real test failure rather than swallowing it.
add_executable(fail_test tests/fail_test.cpp)
target_link_libraries(fail_test PRIVATE mathx)
add_test(NAME cpp_fail_on_purpose COMMAND fail_test)
