cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIF_wrapper LANGUAGES C)
#
# Get library helper
#
include(FetchContent)
FetchContent_Declare(cmake-helpers GIT_REPOSITORY https://github.com/jddurand/cmake-helpers.git GIT_SHALLOW TRUE)
FetchContent_MakeAvailable(cmake-helpers)
find_package(marpaESLIF REQUIRED)
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
  list(APPEND CMAKE_REQUIRED_LIBRARIES marpaESLIF::marpaESLIF)
  list(APPEND CMAKE_EXTRA_INCLUDE_FILES "marpaESLIF_wrapper.h")
  check_type_size("int" SIZEOF_int LANGUAGE C)
  check_type_size("size_t" SIZEOF_size_t LANGUAGE C)
  check_type_size("short" SIZEOF_short LANGUAGE C)
  check_type_size("char" SIZEOF_char LANGUAGE C)
  check_type_size("unsigned int" SIZEOF_unsigned_int LANGUAGE C)
  check_type_size("long" SIZEOF_long LANGUAGE C)
  check_type_size("float" SIZEOF_float LANGUAGE C)
  check_type_size("double" SIZEOF_double LANGUAGE C)
  check_type_size("long double" SIZEOF_long_double LANGUAGE C)
  check_type_size("unsigned char" SIZEOF_unsigned_char LANGUAGE C)
  check_type_size("ptrdiff_t" SIZEOF_ptrdiff_t LANGUAGE C)
  check_type_size("marpaESLIFRecognizerOption_t" SIZEOF_marpaESLIFRecognizerOption_t LANGUAGE C)
  check_type_size("marpaESLIFEvent_t" SIZEOF_marpaESLIFEvent_t LANGUAGE C)
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
  check_type_size("marpaESLIFActionFlat_t" SIZEOF_marpaESLIFActionFlat_t LANGUAGE C)
endblock()
#
# Our cmake helpers
#
list(PREPEND CMAKE_MODULE_PATH ${CMAKE_CURRENT_SOURCE_DIR}/cmake)
include(get_SIZEOF_ENUM)
include(get_SIZEOF_MARPAESLIF_LONG_LONG)
include(get_marpaESLIF_offsetof)
#
# Our wrapper to ease life with structures having unions.
# We want only the shared library.
#
cmake_helpers_library(marpaESLIF_wrapper
  TYPE_AUTO          FALSE
  TYPE_SHARED        TRUE
  TARGET_NAME_SHARED marpaESLIF_wrapper
  DEPENDS            PUBLIC marpaESLIF::marpaESLIF
)
#
# We collect the mapping of all C types <=> C# types we need
# In C# the following conventions applies:
# - Size of a C#  enum  can vary
# - Size of a C#  sbyte is 1
# - Size of a C#   byte is 1
# - Size of a C#  short is 2
# - Size of a C# ushort is 2
# - Size of a C#    int is 4
# - Size of a C#   uint is 4
# - Size of a C#   long is 8
# - Size of a C#  ulong is 8
# - Size of a C#   char is 2
#
# - Required types
#
function(c_type_to_csharp_type c_type signed outvar)
  set(sizeof_c_type "sizeof_${c_type}")
  string(REGEX REPLACE "[^a-zA-Z0-9_]" "_" sizeof_c_type "${sizeof_c_type}")
  string(TOUPPER "${sizeof_c_type}" sizeof_c_type)
  set(csharp_type)
  if("x${${sizeof_c_type}}" STREQUAL "x1")
    if(signed)
      set(csharp_type sbyte)
    else()
      set(csharp_type byte)
    endif()
  elseif("x${${sizeof_c_type}}" STREQUAL "x2")
    if(signed)
      set(csharp_type short)
    else()
      set(csharp_type ushort)
    endif()
  elseif("x${${sizeof_c_type}}" STREQUAL "x4")
    if(signed)
      set(csharp_type int)
    else()
      set(csharp_type uint)
    endif()
  elseif("x${${sizeof_c_type}}" STREQUAL "x8")
    if(signed)
      set(csharp_type long)
    else()
      set(csharp_type ulong)
    endif()
  endif()
  if(NOT csharp_type)
    message(FATAL_ERROR "Cannot map C type ${c_type} to C#, lookup was on internal variable ${sizeof_c_type}")
  endif()
  message(STATUS "Mapping: C type ${c_type} <=> C# type ${csharp_type}, byte size: ${${sizeof_c_type}}")
  set(${outvar} ${csharp_type} CACHE INTERNAL "C# type for C type ${c_type} (signed: ${signed}" FORCE)
  mark_as_advanced(${outvar})
endfunction()
#
# Required types
#
c_type_to_csharp_type("enum"           TRUE  C2CSHARP_TYPE_ENUM)
c_type_to_csharp_type("size_t"         FALSE C2CSHARP_TYPE_SIZE_T)
c_type_to_csharp_type("ptrdiff_t"      TRUE  C2CSHARP_TYPE_PTRDIFF_T)
c_type_to_csharp_type("char"           TRUE  C2CSHARP_TYPE_CHAR)
c_type_to_csharp_type("unsigned char"  FALSE C2CSHARP_TYPE_UNSIGNED_CHAR)
c_type_to_csharp_type("short"          TRUE  C2CSHARP_TYPE_SHORT)
c_type_to_csharp_type("unsigned short" FALSE C2CSHARP_TYPE_UNSIGNED_SHORT)
c_type_to_csharp_type("int"            TRUE  C2CSHARP_TYPE_INT)
c_type_to_csharp_type("unsigned int"   FALSE C2CSHARP_TYPE_UNSIGNED_INT)
c_type_to_csharp_type("long"           TRUE  C2CSHARP_TYPE_LONG)
c_type_to_csharp_type("unsigned long"  FALSE C2CSHARP_TYPE_UNSIGNED_LONG)
#
# Special cases
#
if(SIZEOF_MARPAESLIF_LONG_LONG)
  c_type_to_csharp_type("MARPAESLIF_LONG_LONG" TRUE C2CSHARP_TYPE_MARPAESLIF_LONG_LONG)
endif()
#
# We have an issue with float, double and long double - we expect them to be of the same size...
# and this is always the case. Though we verify.
#
# In C# float is 4 bytes
#       double is 8 bytes
#       long double does not exist, and in fact Microsoft abdandoned it: it is expected to equal to be a double
#
if("x${SIZEOF_float}" STREQUAL "x4")
  message(STATUS "Mapping: C type float <=> C# type float, byte size: 4")
  set(C2CSHARP_TYPE_FLOAT float CACHE INTERNAL "C# type for C type float" FORCE)
  mark_as_advanced(C2CSHARP_TYPE_FLOAT)
else()
  message(FATAL_ERROR "float is expected to 4 bytes in C")
endif()
if("x${SIZEOF_double}" STREQUAL "x8")
  message(STATUS "Mapping: C type double <=> C# type double, byte size: 8")
  set(C2CSHARP_TYPE_DOUBLE double CACHE INTERNAL "C# type for C type double" FORCE)
  mark_as_advanced(C2CSHARP_TYPE_DOUBLE)
else()
  message(FATAL_ERROR "double is expected to 8 bytes in C")
endif()
if("x${SIZEOF_long_double}" STREQUAL "x8")
  message(STATUS "Mapping: C type long double <=> C# type double, byte size: 8")
  set(C2CSHARP_TYPE_LONG_DOUBLE double CACHE INTERNAL "C# type for C type long double" FORCE)
  mark_as_advanced(C2CSHARP_TYPE_LONG_DOUBLE)
else()
  message(FATAL_ERROR "double is expected to 8 bytes in C")
endif()
