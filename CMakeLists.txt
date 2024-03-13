cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIFCsharp VERSION 6.0.33 LANGUAGES C CSharp)
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
# Thin interfaces
# (should be without CMAKE_CURRENT_SOURCE_DIR but does not show up in Visual Studio - a CMake bug ?)
#
configure_file(
  src/org/parser/marpa/genericLoggerShr.cs.in
  ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/genericLoggerShr.cs @ONLY
)
configure_file(
  src/org/parser/marpa/marpaESLIFShr.cs.in
  ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFShr.cs @ONLY
)
configure_file(
  src/org/parser/marpa/marpaESLIF_wrapperShr.cs.in
  ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIF_wrapperShr.cs @ONLY
)
#
# The C# package itself
#
add_library(marpaESLIFCSharp SHARED
  src/org/parser/marpa/genericLoggerShr.cs
  src/org/parser/marpa/marpaESLIFShr.cs
  src/org/parser/marpa/marpaESLIF_wrapperShr.cs
  src/org/parser/marpa/ESLIF.cs
  src/org/parser/marpa/ESLIFLoggerInterface.cs
  src/org/parser/marpa/ESLIFGrammarProperties.cs
  src/org/parser/marpa/ESLIFJSONDecoderOption.cs
  src/org/parser/marpa/ESLIFProgress.cs
  src/org/parser/marpa/ESLIFSymbol.cs

  src/org/parser/marpa/dev/ESLIF.cs
  src/org/parser/marpa/dev/ESLIFEvent.cs
  src/org/parser/marpa/dev/ESLIFEventType.cs
  src/org/parser/marpa/dev/ESLIFException.cs
  src/org/parser/marpa/dev/ESLIFGrammar.cs
  src/org/parser/marpa/dev/ESLIFGrammarProperties.cs
  src/org/parser/marpa/dev/ESLIFGrammarRuleProperties.cs
  src/org/parser/marpa/dev/ESLIFGrammarSymbolProperties.cs
  src/org/parser/marpa/dev/ESLIFJSON.cs
  src/org/parser/marpa/dev/ESLIFJSONDecoder.cs
  src/org/parser/marpa/dev/ESLIFJSONDecoderOption.cs
  src/org/parser/marpa/dev/ESLIFJSONEncoder.cs
  src/org/parser/marpa/dev/ESLIFLoggerInterface.cs
  src/org/parser/marpa/dev/ESLIFLoggerLevel.cs
  src/org/parser/marpa/dev/ESLIFMultitonNullLogger.cs
  src/org/parser/marpa/dev/ESLIFProgress.cs
  src/org/parser/marpa/dev/ESLIFRecognizer.cs
  src/org/parser/marpa/dev/ESLIFRecognizerInterface.cs
  src/org/parser/marpa/dev/ESLIFRegexCallout.cs
  src/org/parser/marpa/dev/ESLIFRulePropertyBitSet.cs
  src/org/parser/marpa/dev/ESLIFSymbol.cs
  src/org/parser/marpa/dev/ESLIFSymbolEventBitSet.cs
  src/org/parser/marpa/dev/ESLIFSymbolPropertyBitSet.cs
  src/org/parser/marpa/dev/ESLIFSymbolType.cs
  src/org/parser/marpa/dev/ESLIFValue.cs
  src/org/parser/marpa/dev/ESLIFValueInterface.cs
)
add_dependencies(marpaESLIFCSharp genericLoggerCopy marpaESLIFCopy)
set_property(TARGET marpaESLIFCSharp PROPERTY VS_DOTNET_REFERENCES "System;System.Runtime.InteropServices")
set_property(TARGET marpaESLIFCSharp PROPERTY VS_PACKAGE_REFERENCES "Microsoft.Extensions.Logging_8.0.0")
#
# C.f. https://gitlab.kitware.com/cmake/cmake/-/issues/23573
#
target_compile_options(marpaESLIFCSharp PRIVATE $<IF:$<STREQUAL:"win32",$<LOWER_CASE:"${CMAKE_GENERATOR_PLATFORM}">>,/platform:x86,/platform:x64>)
