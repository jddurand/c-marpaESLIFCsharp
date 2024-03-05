cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
#
# Version must be kept in sync BY HAND with marpaESLIF
#
project(marpaESLIFCsharp VERSION 6.0.33 LANGUAGES CSharp)
#
# This version MUST be in sync with marpaESLIF version
#
# We explicity require a "Visual Studio" generator with a platform
#
string(REGEX MATCH "^Visual Studio" visual_studio ${CMAKE_GENERATOR})
if(NOT visual_studio)
  message(FATAL_ERROR "Visual Studio generator is required")
endif()
if(NOT CMAKE_GENERATOR_PLATFORM)
  message(FATAL_ERROR "Visual Studio generator platform is required")
endif()
#
# Get library helper
#
include(FetchContent)
FetchContent_Declare(cmake-helpers GIT_REPOSITORY https://github.com/jddurand/cmake-helpers.git GIT_SHALLOW TRUE)
FetchContent_MakeAvailable(cmake-helpers)
#
# marpaESLIF dependency:
#
set(marpaESLIF_git https://github.com/jddurand/c-marpaESLIF.git)
cmake_helpers_depend(marpaESLIF
  EXTERNALPROJECT_ADD_ARGS GIT_REPOSITORY ${marpaESLIF_git} GIT_SHALLOW TRUE
  FIND FALSE
  MAKEAVAILABLE TRUE # To have the install rules and recuperate marpaESLIF version
)
find_package(marpaESLIF REQUIRED)
message(STATUS "marpaESLIF version: ${marpaESLIF_VERSION}")

#
# The CSharp interface is deciphered by calculating:
# - All offsetof of all structures
# - All sizes of all integral data types
#
# Note that we reuse the try_value() macro of cmake-helpers
# that has all the bits to make sure things are ok
#
set(try_input ${CMAKE_CURRENT_BINARY_DIR}/try_input.c)
file(WRITE ${try_input} "
#include <stdio.h>
#include <stdlib.h>
#include <marpaESLIF.h>

/* We do not bother to check if offsetof is available
#define _my_offsetof(st, m) ((size_t)((char *)&((st *)0)->m - (char *)0))

int main(int argc, char **argv) {
#ifdef MARPAESLIF_HAVE_LONG_LONG
  long long offset = (long long) _my_offsetof(C_STRUCT, C_MEMBER);
  fprintf(stdout, MARPAESLIF_LONG_LONG_FMT \"\\n\", offset);
#else
  long offset = (long) _my_offsetof(C_STRUCT, C_M);
  fprintf(stdout, \"%ld\\n\", offset);
#endif
  exit(0);
}
")
function(get_marpaESLIF_offsetof struct member)
  set(CMAKE_HELPERS_TRY_RUN_COMPILE_DEFINITIONS "-DC_STRUCT=${struct} -DC_MEMBER=${member}")
  set(CMAKE_REQUIRED_LIBRARIES marpaESLIF::marpaESLIF)
  cmake_helpers_try_value(C_MARPAESLIF_${struct}_${member} ${try_input} "offset(${struct}, ${member})")
endfunction()

get_marpaESLIF_offsetof("marpaESLIFValueResultPair_t" "value")

add_library(${PROJECT_NAME} SHARED src/marpaESLIF.cs)
