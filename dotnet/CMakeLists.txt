#
# C.f. https://github.com/Mizux/dotnet-native/blob/main/cmake/dotnet.cmake
# ------------------------------------------------------------------------
cmake_minimum_required(VERSION 3.26.0 FATAL_ERROR)
project(marpaESLIFCsharp.DotnetNative VERSION ${marpaESLIFCsharp_VERSION} LANGUAGES CSharp)
set(OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR})
add_subdirectory(genericLoggerCopy)
add_subdirectory(marpaESLIFCopy)
#
# Language Version
# See: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version
#
set(DOTNET_LANG "8.0" CACHE STRING "Specify the C# language version (default \"8.0\")")
message(STATUS ".Net C# language version: ${DOTNET_LANG}")
#
# Targeted Framework Moniker
# See: https://docs.microsoft.com/en-us/dotnet/standard/frameworks
# See: https://learn.microsoft.com/en-us/dotnet/standard/net-standard
#
option(USE_DOTNET_46 "Use .Net Framework 4.6 support" OFF)
message(STATUS ".Net: Use .Net Framework 4.6 support: ${USE_DOTNET_46}")
option(USE_DOTNET_461 "Use .Net Framework 4.6.1 support" OFF)
message(STATUS ".Net: Use .Net Framework 4.6.1 support: ${USE_DOTNET_461}")
option(USE_DOTNET_462 "Use .Net Framework 4.6.2 support" OFF)
message(STATUS ".Net: Use .Net Framework 4.6.2 support: ${USE_DOTNET_462}")

option(USE_DOTNET_48 "Use .Net Framework 4.8 support" OFF)
message(STATUS ".Net: Use .Net Framework 4.8 support: ${USE_DOTNET_48}")

option(USE_DOTNET_STD_20 "Use .Net Standard 2.0 support" OFF)
message(STATUS ".Net: Use .Net Framework 2.0 support: ${USE_DOTNET_STD_20}")

option(USE_DOTNET_STD_21 "Use .Net Standard 2.1 support" OFF)
message(STATUS ".Net: Use .Net Framework 2.1 support: ${USE_DOTNET_STD_21}")
#
# .Net Core 3.1 LTS is not available for osx arm64
#
if(APPLE AND CMAKE_SYSTEM_PROCESSOR MATCHES "^(aarch64|arm64)")
  set(USE_DOTNET_CORE_31 OFF)
else()
  option(USE_DOTNET_CORE_31 "Use .Net Core 3.1 LTS support" OFF)
endif()
message(STATUS ".Net: Use .Net Core 3.1 LTS support: ${USE_DOTNET_CORE_31}")

option(USE_DOTNET_6 "Use .Net 6 LTS support" ON)
message(STATUS ".Net: Use .Net 6 LTS support: ${USE_DOTNET_6}")

option(USE_DOTNET_7 "Use .Net 7.0 support" OFF)
message(STATUS ".Net: Use .Net 7.0 support: ${USE_DOTNET_7}")

find_program(DOTNET_EXECUTABLE NAMES dotnet)
if(NOT DOTNET_EXECUTABLE)
  message(FATAL_ERROR "Check for dotnet Program: not found")
else()
  message(STATUS "Found dotnet Program: ${DOTNET_EXECUTABLE}")
endif()
#
# Needed by dotnet/CMakeLists.txt
#
set(DOTNET_PROJECT ${PROJECT_NAME})
message(STATUS ".Net project: ${DOTNET_PROJECT}")
set(DOTNET_PROJECT_DIR ${CMAKE_CURRENT_BINARY_DIR}/${DOTNET_PROJECT})
message(STATUS ".Net project build path: ${DOTNET_PROJECT_DIR}")
#
# Runtime IDentifier
# See: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
#
if(CMAKE_SYSTEM_PROCESSOR MATCHES "^(aarch64|arm64)")
  set(DOTNET_PLATFORM arm64)
else()
  set(DOTNET_PLATFORM x64)
endif()

if(APPLE)
  set(DOTNET_RID osx-${DOTNET_PLATFORM})
elseif(UNIX)
  set(DOTNET_RID linux-${DOTNET_PLATFORM})
elseif(WIN32)
  set(DOTNET_RID win-${DOTNET_PLATFORM})
else()
  message(FATAL_ERROR "Unsupported system !")
endif()
message(STATUS ".Net RID: ${DOTNET_RID}")

set(DOTNET_NATIVE_PROJECT ${DOTNET_PROJECT}.runtime.${DOTNET_RID})
message(STATUS ".Net runtime project: ${DOTNET_NATIVE_PROJECT}")
set(DOTNET_NATIVE_PROJECT_DIR ${CMAKE_CURRENT_BINARY_DIR}/${DOTNET_NATIVE_PROJECT})
message(STATUS ".Net runtime project build path: ${DOTNET_NATIVE_PROJECT_DIR}")

set(DOTNET_PACKAGES_DIR ${CMAKE_CURRENT_BINARY_DIR}/packages)
#
# Targeted Framework Moniker
# See: https://docs.microsoft.com/en-us/dotnet/standard/frameworks
# See: https://learn.microsoft.com/en-us/dotnet/standard/net-standard
#
if(USE_DOTNET_46)
  list(APPEND TFM "net46")
endif()
if(USE_DOTNET_461)
  list(APPEND TFM "net461")
endif()
if(USE_DOTNET_462)
  list(APPEND TFM "net462")
endif()
if(USE_DOTNET_48)
  list(APPEND TFM "net48")
endif()
if(USE_DOTNET_STD_20)
  list(APPEND TFM "netstandard2.0")
endif()
if(USE_DOTNET_STD_21)
  list(APPEND TFM "netstandard2.1")
endif()
if(USE_DOTNET_CORE_31)
  list(APPEND TFM "netcoreapp3.1")
endif()
if(USE_DOTNET_6)
  list(APPEND TFM "net6.0")
endif()
if(USE_DOTNET_7)
  list(APPEND TFM "net7.0")
endif()

list(LENGTH TFM TFM_LENGTH)
if(TFM_LENGTH EQUAL "0")
  message(FATAL_ERROR "No .Net SDK selected !")
endif()

string(JOIN ";" DOTNET_TFM ${TFM})
message(STATUS ".Net TFM: ${DOTNET_TFM}")
if(TFM_LENGTH GREATER "1")
  string(CONCAT DOTNET_TFM "<TargetFrameworks>" "${DOTNET_TFM}" "</TargetFrameworks>")
else()
  string(CONCAT DOTNET_TFM "<TargetFramework>" "${DOTNET_TFM}" "</TargetFramework>")
endif()
#
# Create the native library
#
set(DOTNET_NATIVE_LIBRARY marpaESLIFCsharp)
message(STATUS ".Net runtime library: ${DOTNET_NATIVE_LIBRARY}")

if(EXISTS ${CMAKE_CURRENT_SOURCE_DIR}/logo.png)
  file(COPY ${CMAKE_CURRENT_SOURCE_DIR}/logo.png DESTINATION ${CMAKE_CURRENT_BINARY_DIR})
  set(DOTNET_LOGO_DIR ${CMAKE_CURRENT_BINARY_DIR})
endif()
configure_file(${CMAKE_CURRENT_SOURCE_DIR}/Directory.Packages.props.in ${CMAKE_CURRENT_BINARY_DIR}/Directory.Packages.props)

file(MAKE_DIRECTORY ${DOTNET_PACKAGES_DIR})

############################
##  .Net Runtime Package  ##
############################
# *.csproj.in contains:
# CMake variable(s) (@PROJECT_NAME@) that configure_file() can manage and
# generator expression ($<TARGET_FILE:...>) that file(GENERATE) can manage.
configure_file(
  ${CMAKE_CURRENT_SOURCE_DIR}/${DOTNET_PROJECT}.runtime.csproj.in
  ${DOTNET_NATIVE_PROJECT_DIR}/${DOTNET_NATIVE_PROJECT}.csproj.in
  @ONLY)
file(GENERATE
  OUTPUT ${DOTNET_NATIVE_PROJECT_DIR}/$<CONFIG>/${DOTNET_NATIVE_PROJECT}.csproj.in
  INPUT ${DOTNET_NATIVE_PROJECT_DIR}/${DOTNET_NATIVE_PROJECT}.csproj.in)

add_custom_command(
  OUTPUT ${DOTNET_NATIVE_PROJECT_DIR}/${DOTNET_NATIVE_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E copy ./$<CONFIG>/${DOTNET_NATIVE_PROJECT}.csproj.in ${DOTNET_NATIVE_PROJECT}.csproj
  DEPENDS
    ${DOTNET_NATIVE_PROJECT_DIR}/$<CONFIG>/${DOTNET_NATIVE_PROJECT}.csproj.in
  WORKING_DIRECTORY ${DOTNET_NATIVE_PROJECT_DIR})

add_custom_command(
  OUTPUT ${DOTNET_NATIVE_PROJECT_DIR}/timestamp
  COMMAND ${CMAKE_COMMAND} -E env --unset=TARGETNAME
    ${DOTNET_EXECUTABLE} build --nologo -c Release /p:Platform=${DOTNET_PLATFORM} ${DOTNET_NATIVE_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E env --unset=TARGETNAME
    ${DOTNET_EXECUTABLE} pack --nologo -c Release ${DOTNET_NATIVE_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E touch ${DOTNET_NATIVE_PROJECT_DIR}/timestamp
  DEPENDS
    ${CMAKE_CURRENT_BINARY_DIR}/Directory.Packages.props
    ${DOTNET_NATIVE_PROJECT_DIR}/${DOTNET_NATIVE_PROJECT}.csproj
    ${DOTNET_NATIVE_LIBRARY}
  BYPRODUCTS
    ${DOTNET_NATIVE_PROJECT_DIR}/bin
    ${DOTNET_NATIVE_PROJECT_DIR}/obj
  VERBATIM
  COMMENT "Generate .Net native package ${DOTNET_NATIVE_PROJECT} (${DOTNET_NATIVE_PROJECT_DIR}/timestamp)"
  WORKING_DIRECTORY ${DOTNET_NATIVE_PROJECT_DIR})

add_custom_target(dotnet_native_package
  DEPENDS
    ${DOTNET_NATIVE_PROJECT_DIR}/timestamp
  WORKING_DIRECTORY ${DOTNET_NATIVE_PROJECT_DIR})

####################
##  .Net Package  ##
####################
configure_file(
  ${CMAKE_CURRENT_SOURCE_DIR}/${DOTNET_PROJECT}.csproj.in
  ${DOTNET_PROJECT_DIR}/${DOTNET_PROJECT}.csproj.in
  @ONLY)

add_custom_command(
  OUTPUT ${DOTNET_PROJECT_DIR}/${DOTNET_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E copy ${DOTNET_PROJECT}.csproj.in ${DOTNET_PROJECT}.csproj
  DEPENDS
    ${DOTNET_PROJECT_DIR}/${DOTNET_PROJECT}.csproj.in
  WORKING_DIRECTORY ${DOTNET_PROJECT_DIR})

add_custom_command(
  OUTPUT ${DOTNET_PROJECT_DIR}/timestamp
  COMMAND ${CMAKE_COMMAND} -E env --unset=TARGETNAME
    ${DOTNET_EXECUTABLE} build --nologo -c Release /p:Platform=${DOTNET_PLATFORM} ${DOTNET_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E env --unset=TARGETNAME
    ${DOTNET_EXECUTABLE} pack --nologo -c Release ${DOTNET_PROJECT}.csproj
  COMMAND ${CMAKE_COMMAND} -E touch ${DOTNET_PROJECT_DIR}/timestamp
  DEPENDS
    ${DOTNET_PROJECT_DIR}/${DOTNET_PROJECT}.csproj
    dotnet_native_package
  BYPRODUCTS
    ${DOTNET_PROJECT_DIR}/bin
    ${DOTNET_PROJECT_DIR}/obj
  VERBATIM
  COMMENT "Generate .Net package ${DOTNET_PROJECT} (${DOTNET_PROJECT_DIR}/timestamp)"
  WORKING_DIRECTORY ${DOTNET_PROJECT_DIR})

add_custom_target(dotnet_package ALL
  DEPENDS
    ${DOTNET_PROJECT_DIR}/timestamp
  WORKING_DIRECTORY ${DOTNET_PROJECT_DIR})

add_dependencies(dotnet_package genericLoggerDotnetCopy marpaESLIFDotnetCopy)
add_dependencies(dotnet_native_package genericLoggerDotnetCopy marpaESLIFDotnetCopy)
