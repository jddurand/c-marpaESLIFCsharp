function(get_SIZEOF_ENUM outvar)
  set(_singleton ${outvar}_SINGLETON)
  if(NOT ${_singleton})
    set(try_input ${CMAKE_CURRENT_BINARY_DIR}/try_input.c)
    file(WRITE ${try_input} "
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char **argv) {
  enum the_enum { the_enum_anything = 0 };

  fprintf(stdout, \"%d\\n\", (int) sizeof(the_enum_anything));
  exit(0);
}
")
    try_run(
      _run_result
      _compile_result
      SOURCE_FROM_FILE _try.c ${try_input}
      COMPILE_OUTPUT_VARIABLE _compile_output
      RUN_OUTPUT_VARIABLE _run_output
    )
    if(_compile_result AND (_run_result EQUAL 0))
      string(REGEX MATCH "^[0-9]+" sizeof_enum ${_run_output})
      message(STATUS "Looking for SIZEOF_ENUM gives ${sizeof_enum}")
      set(${outvar} ${sizeof_enum} CACHE INTERNAL "sizeof enum" FORCE)
      mark_as_advanced(${outvar})
    else()
      message(STATUS "Compile result: ${_compile_result}")
      message(STATUS "Compile output:\n${_compile_output}")
      message(STATUS "Run result: ${_run_result}")
      message(STATUS "Run output:\n${_run_output}")
      message(FATAL_ERROR "Looking for SIZEOF_ENUM failure")
    endif()
    set(${_singleton} TRUE CACHE BOOL "${outvar} try_run singleton" FORCE)
    mark_as_advanced(${_singleton})
  endif()
endfunction()

get_SIZEOF_ENUM(SIZEOF_ENUM)
