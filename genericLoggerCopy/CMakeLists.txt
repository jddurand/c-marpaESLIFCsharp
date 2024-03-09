cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(genericLoggerCopy)
find_package(genericLogger REQUIRED)
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
