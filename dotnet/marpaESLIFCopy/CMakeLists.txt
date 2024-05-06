cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIFCopy)
find_package(marpaESLIF REQUIRED)
get_target_property(marpaESLIF_imported_location marpaESLIF::marpaESLIF LOCATION)
string(REGEX REPLACE "dll$" "pdb" marpaESLIF_imported_pdb_location ${marpaESLIF_imported_location})
if(EXISTS ${marpaESLIF_imported_pdb_location})
  add_custom_target(marpaESLIFDotnetCopy
    COMMAND ${CMAKE_COMMAND} -E copy ${marpaESLIF_imported_location}     ${OUTPUT_DIRECTORY}
    COMMAND ${CMAKE_COMMAND} -E copy ${marpaESLIF_imported_pdb_location} ${OUTPUT_DIRECTORY}
    COMMENT "Copying marpaESLIF dll and pdb"
  )
else()
  add_custom_target(marpaESLIFDotnetCopy
    COMMAND ${CMAKE_COMMAND} -E copy ${marpaESLIF_imported_location}     ${OUTPUT_DIRECTORY}
    COMMENT "Copying marpaESLIF dll"
  )
endif()
