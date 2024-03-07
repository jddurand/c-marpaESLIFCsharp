function(get_SIZEOF_MARPAESLIF_LONG_LONG outvar)
  set(try_input ${CMAKE_CURRENT_BINARY_DIR}/try_input.c)
  file(WRITE ${try_input} "
#include <stdio.h>
#include <stdlib.h>
#include <marpaESLIF.h>
#include <marpaESLIF_wrapper.h>

int main(int argc, char **argv) {
#ifdef MARPAESLIF_HAVE_LONG_LONG
  long long sizeof_long_long = (long long) sizeof(MARPAESLIF_LONG_LONG);
  fprintf(stdout, MARPAESLIF_LONG_LONG_FMT \"\\n\", sizeof_long_long);
#else
  fprintf(stdout, \"%d\\n\", (int) 0);
#endif
  exit(0);
}
")
  try_run(
    _run_result
    _compile_result
    SOURCE_FROM_FILE _try.c ${try_input}
    COMPILE_DEFINITIONS -DMARPAESLIFCSHARP_MARPAESLIF_WRAPPER_INTROSPECTION=1
    CMAKE_FLAGS -DINCLUDE_DIRECTORIES=${CMAKE_CURRENT_SOURCE_DIR}/include
    COMPILE_OUTPUT_VARIABLE _compile_output
    LINK_LIBRARIES marpaESLIF::marpaESLIF
    RUN_OUTPUT_VARIABLE _run_output
  )
  if(_compile_result AND (_run_result EQUAL 0))
    string(REGEX MATCH "^[0-9]+" marpaeslif_have_long_long ${_run_output})
    message(STATUS "Looking for SIZEOF_MARPAESLIF_LONG_LONG gives ${marpaeslif_have_long_long}")
    set(${outvar} ${marpaeslif_have_long_long} PARENT_SCOPE)
  else()
    message(STATUS "Compile result: ${_compile_result}")
    message(STATUS "Compile output:\n${_compile_output}")
    message(STATUS "Run result: ${_run_result}")
    message(STATUS "Run output:\n${_run_output}")
    message(FATAL_ERROR "Looking for MARPAESLIF_HAVE_LONG_LONG failure")
  endif()
endfunction()

get_SIZEOF_MARPAESLIF_LONG_LONG(SIZEOF_MARPAESLIF_LONG_LONG)
