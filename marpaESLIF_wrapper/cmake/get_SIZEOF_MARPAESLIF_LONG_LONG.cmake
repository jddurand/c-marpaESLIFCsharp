function(get_SIZEOF_MARPAESLIF_LONG_LONG outvar)
  set(_singleton ${outvar}_SINGLETON)
  if(NOT ${_singleton})
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
      string(REGEX MATCH "^[0-9]+" marpaeslif_sizeof_long_long ${_run_output})
      message(STATUS "Looking for SIZEOF_MARPAESLIF_LONG_LONG gives ${marpaeslif_sizeof_long_long}")
      set(${outvar} ${marpaeslif_sizeof_long_long} CACHE INTERNAL "sizeof MARPAESLIF_LONG_LONG" FORCE)
      mark_as_advanced(${outvar})
    else()
      message(STATUS "Compile result: ${_compile_result}")
      message(STATUS "Compile output:\n${_compile_output}")
      message(STATUS "Run result: ${_run_result}")
      message(STATUS "Run output:\n${_run_output}")
      message(FATAL_ERROR "Looking for size of MARPAESLIF_LONG_LONG failure")
    endif()
    set(${_singleton} TRUE CACHE BOOL "${outvar} try_run singleton" FORCE)
    mark_as_advanced(${_singleton})
  endif()
endfunction()

get_SIZEOF_MARPAESLIF_LONG_LONG(SIZEOF_MARPAESLIF_LONG_LONG)
if(SIZEOF_MARPAESLIF_LONG_LONG)
  set(MARPAESLIF_HAVE_LONG_LONG TRUE CACHE BOOL "MARPAESLIF_HAVE_LONG_LONG define" FORCE)
  mark_as_advanced(HAVE_MARPAESLIF_LONG_LONG)
else()
  unset(MARPAESLIF_HAVE_LONG_LONG CACHE)
endif()
