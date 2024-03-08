cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
#
# Version must be kept in sync BY HAND with marpaESLIF
#
project(marpaESLIFCsharp VERSION 6.0.33 LANGUAGES C CXX CSharp)
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
#
# Find/import the dependencies
list(PREPEND CMAKE_PREFIX_PATH ${CMAKE_HELPERS_INSTALL_PATH}/${CMAKE_HELPERS_INSTALL_CMAKEDIR})
message(STATUS "CMAKE_PREFIX_PATH: ${CMAKE_PREFIX_PATH}")
set(CMAKE_FIND_USE_CMAKE_PATH TRUE)
find_package(marpaESLIF REQUIRED)
message(STATUS "marpaESLIF version: ${marpaESLIF_VERSION}")
find_package(genericLogger REQUIRED)
message(STATUS "genericLogger version: ${genericLogger_VERSION}")
#
# Our wrapper to ease life with structures having unions
#
cmake_helpers_library(marpaESLIF_wrapper DEPENDS_EXT PUBLIC BUILD_LOCAL_INTERFACE marpaESLIF)
#
# Types sizes
#
include(CheckTypeSize)
block()
  #
  # We said FILE FALSE when checking marpaESLIF, so per def it is installed there ;)
  #
  list(APPEND CMAKE_REQUIRED_DEFINITIONS -DMARPAESLIFCSHARP_MARPAESLIF_WRAPPER_INTROSPECTION=1)
  list(APPEND CMAKE_REQUIRED_INCLUDES ${CMAKE_CURRENT_SOURCE_DIR}/include)
  list(APPEND CMAKE_REQUIRED_LIBRARIES marpaESLIF)
  list(APPEND CMAKE_EXTRA_INCLUDE_FILES "marpaESLIF_wrapper.h")
  check_type_size("int" SIZEOF_int LANGUAGE C)
  check_type_size("size_t" SIZEOF_size_t LANGUAGE C)
  check_type_size("short" SIZEOF_short LANGUAGE C)
  check_type_size("char" SIZEOF_char LANGUAGE C)
  check_type_size("unsigned int" SIZEOF_unsigned_int LANGUAGE C)
  check_type_size("long" SIZEOF_long LANGUAGE C)
  check_type_size("float" SIZEOF_float LANGUAGE C)
  check_type_size("double" SIZEOF_double LANGUAGE C)
  check_type_size("unsigned char" SIZEOF_unsigned_char LANGUAGE C)
  check_type_size("ptrdiff_t" SIZEOF_ptrdiff_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultShort_t" SIZEOF_marpaESLIFValueResultShort_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultLong_t" SIZEOF_marpaESLIFValueResultLong_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultFloat_t" SIZEOF_marpaESLIFValueResultFloat_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultDouble_t" SIZEOF_marpaESLIFValueResultDouble_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultPtr_t" SIZEOF_marpaESLIFValueResultPtr_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultArray_t" SIZEOF_marpaESLIFValueResultArray_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultString_t" SIZEOF_marpaESLIFValueResultString_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultRow_t" SIZEOF_marpaESLIFValueResultRow_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultPair_t" SIZEOF_marpaESLIFValueResultPair_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultTable_t" SIZEOF_marpaESLIFValueResultTable_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultLongDouble_t" SIZEOF_marpaESLIFValueResultLongDouble_t LANGUAGE C)
  if(SIZEOF_MARPAESLIF_LONG_LONG)
    check_type_size("marpaESLIFValueResultLongLong_t" SIZEOF_marpaESLIFValueResultLongLong_t LANGUAGE C)
  endif()
  check_type_size("marpaESLIFValueResultOffsetAndLength_t" SIZEOF_marpaESLIFValueResultOffsetAndLength_t LANGUAGE C)
  check_type_size("marpaESLIFValueResult_t" SIZEOF_marpaESLIFValueResult_t LANGUAGE C)
  check_type_size("marpaESLIFAlternative_t" SIZEOF_marpaESLIFAlternative_t LANGUAGE C)
  check_type_size("marpaESLIFValueOption_t" SIZEOF_marpaESLIFValueOption_t LANGUAGE C)
  check_type_size("marpaESLIFRecognizerProgress_t" SIZEOF_marpaESLIFRecognizerProgress_t LANGUAGE C)
  check_type_size("marpaESLIFString_t" SIZEOF_marpaESLIFString_t LANGUAGE C)
  check_type_size("marpaESLIFLuaFunction_t" SIZEOF_marpaESLIFLuaFunction_t LANGUAGE C)
  check_type_size("marpaESLIFAction_t" SIZEOF_marpaESLIFAction_t LANGUAGE C)
  check_type_size("marpaESLIFGrammarDefaults_t" SIZEOF_marpaESLIFGrammarDefaults_t LANGUAGE C)
  check_type_size("marpaESLIFGrammarProperty_t" SIZEOF_marpaESLIFGrammarProperty_t LANGUAGE C)
  check_type_size("marpaESLIFRuleProperty_t" SIZEOF_marpaESLIFRuleProperty_t LANGUAGE C)
  check_type_size("marpaESLIFSymbolProperty_t" SIZEOF_marpaESLIFSymbolProperty_t LANGUAGE C)
  check_type_size("marpaESLIFJSONDecodeOption_t" SIZEOF_marpaESLIFJSONDecodeOption_t LANGUAGE C)
  check_type_size("marpaESLIFOption_t" SIZEOF_marpaESLIFOption_t LANGUAGE C)
  check_type_size("marpaESLIFGrammarOption_t" SIZEOF_marpaESLIFGrammarOption_t LANGUAGE C)
  check_type_size("marpaESLIFSymbolOption_t" SIZEOF_marpaESLIFSymbolOption_t LANGUAGE C)
  check_type_size("marpaESLIFValueResultFlat_t" SIZEOF_marpaESLIFValueResultFlat_t LANGUAGE C)
endblock()
#
# Our cmake helpers
#
list(PREPEND CMAKE_MODULE_PATH ${CMAKE_CURRENT_SOURCE_DIR}/cmake)
include(get_SIZEOF_MARPAESLIF_LONG_LONG)
include(get_marpaESLIF_offsetof)
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
# The thin interface to generigLogger shared library
# ps: why, if generated in CMAKE_CURRENT_BINARY_DIR, does it not show in Visual Studio ?
#
configure_file(${CMAKE_CURRENT_SOURCE_DIR}/src/genericLoggerShr.cs.in ${CMAKE_CURRENT_SOURCE_DIR}/src/genericLoggerShr.cs @ONLY)
add_library(genericLoggerShr SHARED src/genericLoggerShr.cs)
set_target_properties(genericLoggerShr PROPERTIES VS_DOTNET_REFERENCES "System;System.Runtime.InteropServices")
#
# A custom target that will copy genericLogger dll to runtime output directory. Note that I do not know a default property to get pdb location.
#
get_target_property(genericLogger_imported_location genericLogger::genericLogger LOCATION)
string(REGEX REPLACE "dll$" "pdb" genericLogger_imported_pdb_location ${genericLogger_imported_location})
if(EXISTS ${genericLogger_imported_pdb_location})
  add_custom_target(genericLoggerCopy
    COMMAND ${CMAKE_COMMAND} -E copy ${genericLogger_imported_location}     ${OUTPUT_DIRECTORY}
    COMMAND ${CMAKE_COMMAND} -E copy ${genericLogger_imported_pdb_location} ${OUTPUT_DIRECTORY}
    COMMENT "Copying genericLogger dll and pdb"
  )
else()
  add_custom_target(genericLoggerCopy
    COMMAND ${CMAKE_COMMAND} -E copy ${genericLogger_imported_location}     ${OUTPUT_DIRECTORY}
    COMMENT "Copying genericLogger dll"
  )
endif()
add_dependencies(genericLoggerShr genericLoggerCopy)
#
# The interface to generigLogger
#
add_library(genericLoggerIface SHARED src/genericLoggerIface.cs)
set_target_properties(genericLoggerIface PROPERTIES VS_DOTNET_REFERENCES "log4net;genericLoggerShr")
#
# C.f. https://gitlab.kitware.com/cmake/cmake/-/issues/23573
#
foreach(_target genericLoggerShr genericLoggerIface)
  target_compile_options(${_target} PRIVATE $<IF:$<STREQUAL:"win32",$<LOWER_CASE:"${CMAKE_GENERATOR_PLATFORM}">>,/platform:x86,/platform:x64>)
endforeach()
#
# The thin interface to marpaESLIF
#
# configure_file(${CMAKE_CURRENT_SOURCE_DIR}/src/marpaESLIFshr.cs.in ${CMAKE_CURRENT_BINARY_DIR}/marpaESLIFshr.cs @ONLY)
#
# Our P/Invoke libraries
#
