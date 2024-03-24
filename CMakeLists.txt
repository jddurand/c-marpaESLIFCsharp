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
configure_file(src/org/parser/marpa/genericLoggerShr.cs.in           ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/genericLoggerShr.cs @ONLY)
configure_file(src/org/parser/marpa/Import.cs.in                     ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/Import.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFShr.cs.in              ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFShr.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIF.cs.in                 ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIF.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFAction.cs.in           ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFAction.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFOption.cs.in           ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFOption.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFGrammar.cs.in          ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFGrammar.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFGrammarOption.cs.in    ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFGrammarOption.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFLuaFunction.cs.in      ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFLuaFunction.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFRecognizer.cs.in       ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFRecognizer.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFRecognizerOption.cs.in ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFRecognizerOption.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFString.cs.in           ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFString.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIFValueOption.cs.in      ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIFValueOption.cs @ONLY)
configure_file(src/org/parser/marpa/marpaESLIF_wrapperShr.cs.in      ${CMAKE_CURRENT_SOURCE_DIR}/src/org/parser/marpa/marpaESLIF_wrapperShr.cs @ONLY)
#
# The C# package itself
#
add_library(marpaESLIFCSharp SHARED
  src/org/parser/marpa/genericLoggerShr.cs
  src/org/parser/marpa/Import.cs
  src/org/parser/marpa/marpaESLIFShr.cs
  src/org/parser/marpa/marpaESLIF.cs
  src/org/parser/marpa/marpaESLIFAction.cs
  src/org/parser/marpa/marpaESLIFOption.cs
  src/org/parser/marpa/marpaESLIFGrammar.cs
  src/org/parser/marpa/marpaESLIFGrammarOption.cs
  src/org/parser/marpa/marpaESLIFLuaFunction.cs
  src/org/parser/marpa/marpaESLIFRecognizer.cs
  src/org/parser/marpa/marpaESLIFRecognizerOption.cs
  src/org/parser/marpa/marpaESLIFString.cs
  src/org/parser/marpa/marpaESLIFValueOption.cs
  src/org/parser/marpa/marpaESLIF_wrapperShr.cs
  
  src/org/parser/marpa/ESLIF.cs
  src/org/parser/marpa/ESLIFAction.cs
  src/org/parser/marpa/ESLIFActionType.cs
  src/org/parser/marpa/ESLIFEvent.cs
  src/org/parser/marpa/ESLIFEventType.cs
  src/org/parser/marpa/ESLIFException.cs
  src/org/parser/marpa/ESLIFGrammar.cs
  src/org/parser/marpa/ESLIFGrammarDefaults.cs
  src/org/parser/marpa/ESLIFGrammarProperties.cs
  src/org/parser/marpa/ESLIFGrammarRuleProperties.cs
  src/org/parser/marpa/ESLIFGrammarSymbolProperties.cs
  src/org/parser/marpa/ESLIFJSON.cs
  src/org/parser/marpa/ESLIFJSONDecoder.cs
  src/org/parser/marpa/ESLIFJSONDecoderOption.cs
  src/org/parser/marpa/ESLIFJSONEncoder.cs
  src/org/parser/marpa/ESLIFLuaFunction.cs
  src/org/parser/marpa/ESLIFLoggerInterface.cs
  src/org/parser/marpa/ESLIFLoggerLevel.cs
  src/org/parser/marpa/ESLIFMultitonNullLogger.cs
  src/org/parser/marpa/ESLIFProgress.cs
  src/org/parser/marpa/ESLIFRecognizer.cs
  src/org/parser/marpa/ESLIFRecognizerInterface.cs
  src/org/parser/marpa/ESLIFRegexCallout.cs
  src/org/parser/marpa/ESLIFRulePropertyBitSet.cs
  src/org/parser/marpa/ESLIFSymbol.cs
  src/org/parser/marpa/ESLIFSymbolEventBitSet.cs
  src/org/parser/marpa/ESLIFSymbolPropertyBitSet.cs
  src/org/parser/marpa/ESLIFSymbolType.cs
  src/org/parser/marpa/ESLIFValue.cs
  src/org/parser/marpa/ESLIFValueInterface.cs
)
add_dependencies(marpaESLIFCSharp genericLoggerCopy marpaESLIFCopy)
set_property(TARGET marpaESLIFCSharp PROPERTY VS_DOTNET_REFERENCES "System;System.Runtime.InteropServices")
set_property(TARGET marpaESLIFCSharp PROPERTY VS_PACKAGE_REFERENCES "Microsoft.Extensions.Logging_8.0.0")
#
# Temporary test project
#
add_subdirectory(ConsoleApp)
#
# Make ConsoleApp the start project
#
set_property(DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR} PROPERTY VS_STARTUP_PROJECT ConsoleApp)
#
# C.f. https://gitlab.kitware.com/cmake/cmake/-/issues/23573
#
foreach (target marpaESLIFCSharp ConsoleApp)
  target_compile_options(${target} PRIVATE $<IF:$<STREQUAL:"win32",$<LOWER_CASE:"${CMAKE_GENERATOR_PLATFORM}">>,/platform:x86,/platform:x64>)
endforeach()
