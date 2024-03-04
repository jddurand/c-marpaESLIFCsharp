cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
#
# Version must be kept in sync BY HAND with marpaESLIF
#
project(marpaESLIFCsharp VERSION 6.0.33 LANGUAGES CSharp)
#
# This version MUST be in sync with marpaESLIF version
#
# Win32 packaging mode (i.e. everything is make available)
#
set(ENV{CMAKE_HELPERS_WIN32_PACKAGING} 1)
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

add_library(${PROJECT_NAME} SHARED src/marpaESLIF.cs)
