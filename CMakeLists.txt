cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIFCsharp VERSION 6.0.33 LANGUAGES CSharp)
#
# Note: C.f. https://gitlab.kitware.com/cmake/cmake/-/issues/25579 to know why there are different subdirectories
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
# Fix all find/import dependencies
#
list(PREPEND CMAKE_PREFIX_PATH ${CMAKE_HELPERS_INSTALL_PATH}/${CMAKE_HELPERS_INSTALL_CMAKEDIR})
message(STATUS "CMAKE_PREFIX_PATH: ${CMAKE_PREFIX_PATH}")
set(CMAKE_FIND_USE_CMAKE_PATH TRUE)
#
# To have something clean with our dll dependencies, for the runtime output directory
#
set(OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}/csharp_build)
foreach(_type DEBUG RELEASE RELWITHDEBINFO MINSIZEREL)
  SET(CMAKE_RUNTIME_OUTPUT_DIRECTORY_${_type} "${OUTPUT_DIRECTORY}")
  SET(CMAKE_LIBRARY_OUTPUT_DIRECTORY_${_type} "${OUTPUT_DIRECTORY}")
  SET(CMAKE_ARCHIVE_OUTPUT_DIRECTORY_${_type} "${OUTPUT_DIRECTORY}")
endforeach()
#
# genericLogger local target
#
set(genericLogger_git https://github.com/jddurand/c-genericLogger.git)
cmake_helpers_depend(genericLogger
  EXTERNALPROJECT_ADD_ARGS GIT_REPOSITORY ${genericLogger_git} GIT_SHALLOW TRUE
  FIND                     FALSE
  # CONFIGURE                FALSE
  # BUILD                    FALSE
  # INSTALL                  FALSE
  # MAKEAVAILABLE            TRUE
  # EXCLUDE_FROM_ALL         FALSE
)
find_package(genericLogger REQUIRED)
message(STATUS "genericLogger version: ${genericLogger_VERSION}")
#
# A custom target that will copy genericLogger dll to runtime output directory. Note that I do not know a default property to get pdb location.
#
add_subdirectory(genericLoggerCopy)
#
# marpaESLIF local target
#
set(marpaESLIF_git https://github.com/jddurand/c-marpaESLIF.git)
cmake_helpers_depend(marpaESLIF
  EXTERNALPROJECT_ADD_ARGS GIT_REPOSITORY ${marpaESLIF_git} GIT_SHALLOW TRUE
  FIND                     FALSE
  # CONFIGURE                FALSE
  # BUILD                    FALSE
  # INSTALL                  FALSE
  # MAKEAVAILABLE            TRUE
  # EXCLUDE_FROM_ALL         FALSE
)
find_package(marpaESLIF REQUIRED)
message(STATUS "marpaESLIF version: ${marpaESLIF_VERSION}")
#
# A custom target that will copy genericLogger dll to runtime output directory. Note that I do not know a default property to get pdb location.
#
add_subdirectory(marpaESLIFCopy)
#
# Our marpaESLIF wrapper just to easy the use of struct with unions
#
add_subdirectory(marpaESLIF_wrapper)
#
# Remember C# targets because of https://gitlab.kitware.com/cmake/cmake/-/issues/23573
#
set(csharp_targets)
#
# The thin interface to generigLogger shared library
#
add_library(genericLoggerShr SHARED src/genericLoggerShr.cs)
set_property(TARGET genericLoggerShr PROPERTY VS_DOTNET_REFERENCES "System;System.Runtime.InteropServices")
add_dependencies(genericLoggerShr genericLoggerCopy)
list(APPEND csharp_targets genericLoggerShr)
#
# The thin interface to marpaESLIF shared library
#
add_library(marpaESLIFShr SHARED src/marpaESLIFShr.cs)
set_property(TARGET marpaESLIFShr PROPERTY VS_DOTNET_REFERENCES "System;System.Runtime.InteropServices")
add_dependencies(marpaESLIFShr marpaESLIFCopy)
list(APPEND csharp_targets marpaESLIFShr)
#
# The thin interface to marpaESLIF
#
#
# The interface to generigLogger
#
# add_library(genericLoggerIface SHARED src/genericLoggerIface.cs)
# add_dependencies(genericLoggerIface genericLoggerShr)
#set_property(TARGET genericLoggerIface PROPERTY VS_DOTNET_REFERENCES "System;genericLoggerShr")
# set_property(TARGET genericLoggerIface PROPERTY VS_PACKAGE_REFERENCES "log4net_2.0.15")
#
# C.f. https://gitlab.kitware.com/cmake/cmake/-/issues/23573

foreach(_target IN LISTS csharp_targets)
  target_compile_options(${_target} PRIVATE $<IF:$<STREQUAL:"win32",$<LOWER_CASE:"${CMAKE_GENERATOR_PLATFORM}">>,/platform:x86,/platform:x64>)
endforeach()
#
# The thin interface to marpaESLIF
#
# configure_file(${CMAKE_CURRENT_SOURCE_DIR}/src/marpaESLIFshr.cs.in ${CMAKE_CURRENT_BINARY_DIR}/marpaESLIFshr.cs @ONLY)
#
# Our P/Invoke libraries
#
