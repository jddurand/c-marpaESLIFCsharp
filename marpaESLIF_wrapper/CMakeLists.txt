cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIF_wrapper LANGUAGES C)
#
# Get library helper
#
include(FetchContent)
FetchContent_Declare(cmake-helpers GIT_REPOSITORY https://github.com/jddurand/cmake-helpers.git GIT_SHALLOW TRUE)
FetchContent_MakeAvailable(cmake-helpers)
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
# Our wrapper to ease life with structures having unions.
# We want only the shared library.
#
cmake_helpers_library(marpaESLIF_wrapper
  TYPE_AUTO          FALSE
  TYPE_SHARED        TRUE
  TARGET_NAME_SHARED marpaESLIF_wrapper
  DEPENDS            PUBLIC marpaESLIF::marpaESLIF
)
