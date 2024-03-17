function(get_marpaESLIF_offsetof struct member outvar)
  set(_singleton ${outvar}_SINGLETON)
  if(NOT ${_singleton})
    set(try_input ${CMAKE_CURRENT_BINARY_DIR}/try_input.c)
    file(WRITE ${try_input} "
#include <stdio.h>
#include <stdlib.h>
#include <marpaESLIF.h>
#include <marpaESLIF_wrapper.h>

/* We do not bother to check if offsetof is available */
#define _my_offsetof(st, m) ((size_t)((char *)&((st *)0)->m - (char *)0))

int main(int argc, char **argv) {
#ifdef MARPAESLIF_HAVE_LONG_LONG
  long long offset = (long long) _my_offsetof(C_STRUCT, C_MEMBER);
  fprintf(stdout, MARPAESLIF_LONG_LONG_FMT \"\\n\", offset);
#else
  long offset = (long) _my_offsetof(C_STRUCT, C_M);
  fprintf(stdout, \"%ld\\n\", offset);
#endif
  exit(0);
}
")
    try_run(
      _run_result
      _compile_result
      SOURCE_FROM_FILE _try.c ${try_input}
      COMPILE_DEFINITIONS -DC_STRUCT=${struct} -DC_MEMBER=${member} -DMARPAESLIFCSHARP_MARPAESLIF_WRAPPER_INTROSPECTION=1
      CMAKE_FLAGS -DINCLUDE_DIRECTORIES=${CMAKE_CURRENT_SOURCE_DIR}/include
      COMPILE_OUTPUT_VARIABLE _compile_output
      LINK_LIBRARIES marpaESLIF::marpaESLIF
      RUN_OUTPUT_VARIABLE _run_output
    )
    if(_compile_result AND (_run_result EQUAL 0))
      string(REGEX MATCH "^[0-9]+" offsetof ${_run_output})
      message(STATUS "Looking for offsetof(${struct}, ${member}) gives ${offsetof}")
      set(${outvar} ${offsetof} CACHE INTERNAL "offsetof(${struct}, ${member}" FORCE)
      mark_as_advanced(${outvar})
    else()
      message(STATUS "Compile result: ${_compile_result}")
      message(STATUS "Compile output:\n${_compile_output}")
      message(STATUS "Run result: ${_run_result}")
      message(STATUS "Run output:\n${_run_output}")
      message(FATAL_ERROR "Looking for offsetof(${struct}, ${member}) failure")
    endif()
    set(${_singleton} TRUE CACHE BOOL "${outvar} try_run singleton" FORCE)
    mark_as_advanced(${_singleton})
  endif()
endfunction()

#
# marpaESLIFRecognizerOption_t type
#
message(STATUS "Looking at type marpaESLIFRecognizerOption_t")
foreach(member 
    userDatavp
    readerCallbackp
    disableThresholdb
    exhaustedb
    newlineb
    trackb
    bufsizl
    buftriggerperci
    bufaddperci
    ifActionResolverp
    eventActionResolverp
    regexActionResolverp
    generatorActionResolverp
    importerp
  )
  get_marpaESLIF_offsetof("marpaESLIFRecognizerOption_t" ${member} OFFSETOF_marpaESLIFRecognizerOption_t_${member})
endforeach()
#
# marpaESLIFEvent_t type
#
message(STATUS "Looking at type marpaESLIFEvent_t")
foreach(member 
    type
    symbols
    events
  )
  get_marpaESLIF_offsetof("marpaESLIFEvent_t" ${member} OFFSETOF_marpaESLIFEvent_t_${member})
endforeach()
#
# marpaESLIFValueResultPtr_t type
#
message(STATUS "Looking at type marpaESLIFValueResultPtr_t")
foreach(member 
    p
    shallowb
    freeUserDatavp
    freeCallbackp
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultPtr_t" ${member} OFFSETOF_marpaESLIFValueResultPtr_t_${member})
endforeach()
#
# marpaESLIFValueResultPtr_t type
#
message(STATUS "Looking at type marpaESLIFValueResultArray_t")
foreach(member 
    p
    shallowb
    freeUserDatavp
    freeCallbackp
    sizel
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultArray_t" ${member} OFFSETOF_marpaESLIFValueResultArray_t_${member})
endforeach()
#
# marpaESLIFValueResultString_t type
#
message(STATUS "Looking at type marpaESLIFValueResultString_t")
foreach(member 
    p
    shallowb
    freeUserDatavp
    freeCallbackp
    sizel
    encodingasciis
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultString_t" ${member} OFFSETOF_marpaESLIFValueResultString_t_${member})
endforeach()
#
# marpaESLIFValueResultRow_t type
#
message(STATUS "Looking at type marpaESLIFValueResultRow_t")
foreach(member 
    p
    shallowb
    freeUserDatavp
    freeCallbackp
    sizel
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultRow_t" ${member} OFFSETOF_marpaESLIFValueResultRow_t_${member})
endforeach()
#
# marpaESLIFValueResultTable_t type
#
message(STATUS "Looking at type marpaESLIFValueResultTable_t")
foreach(member 
    p
    shallowb
    freeUserDatavp
    freeCallbackp
    sizel
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultTable_t" ${member} OFFSETOF_marpaESLIFValueResultTable_t_${member})
endforeach()
#
# marpaESLIFValueResultOffsetAndLength_t type
#
message(STATUS "Looking at type marpaESLIFValueResultOffsetAndLength_t")
foreach(member 
    p
    sizel
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultOffsetAndLength_t" ${member} OFFSETOF_marpaESLIFValueResultOffsetAndLength_t_${member})
endforeach()
#
# marpaESLIFValueResult_t type
#
message(STATUS "Looking at type marpaESLIFValueResult_t")
foreach(member
    contextp
    representationp
    type
    u
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResult_t" ${member} OFFSETOF_marpaESLIFValueResultOffsetAndLength_t_${member})
endforeach()
#
# marpaESLIFValueResultPair_t type
#
message(STATUS "Looking at type marpaESLIFValueResultPair_t")
foreach(member 
    key
    value
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultPair_t" ${member} OFFSETOF_marpaESLIFValueResultPair_t_${member})
endforeach()
#
# marpaESLIFAlternative_t type
#
message(STATUS "Looking at type marpaESLIFAlternative_t")
foreach(member 
    names
    value
    grammarLengthl
  )
  get_marpaESLIF_offsetof("marpaESLIFAlternative_t" ${member} OFFSETOF_marpaESLIFAlternative_t_${member})
endforeach()
#
# marpaESLIFValueOption_t type
#
message(STATUS "Looking at type marpaESLIFValueOption_t")
foreach(member 
    userDatavp
    ruleActionResolverp
    symbolActionResolverp
    importerp
    highRankOnlyb
    orderByRankb
    ambiguousb
    nullb
    maxParsesi
  )
  get_marpaESLIF_offsetof("marpaESLIFValueOption_t" ${member} OFFSETOF_marpaESLIFValueOption_t_${member})
endforeach()
#
# marpaESLIFValueOption_t type
#
message(STATUS "Looking at type marpaESLIFRecognizerProgress_t")
foreach(member 
    earleySetIdi
    earleySetOrigIdi
    rulei
    positioni
  )
  get_marpaESLIF_offsetof("marpaESLIFRecognizerProgress_t" ${member} OFFSETOF_marpaESLIFRecognizerProgress_t_${member})
endforeach()
#
# marpaESLIFString_t type
#
message(STATUS "Looking at type marpaESLIFString_t")
foreach(member 
    bytep
    bytel
    encodingasciis
    asciis
  )
  get_marpaESLIF_offsetof("marpaESLIFString_t" ${member} OFFSETOF_marpaESLIFString_t_${member})
endforeach()
#
# marpaESLIFLuaFunction_t type
#
message(STATUS "Looking at type marpaESLIFLuaFunction_t")
foreach(member 
    luas
    actions
    luacb
    luacp
    luacl
    luacstripp
    luacstripl
  )
  get_marpaESLIF_offsetof("marpaESLIFLuaFunction_t" ${member} OFFSETOF_marpaESLIFLuaFunction_t_${member})
endforeach()
#
# marpaESLIFAction_t type
#
message(STATUS "Looking at type marpaESLIFAction_t")
foreach(member 
    type
    u
    u.names
    u.stringp
    u.luas
    u.luaFunction
  )
  get_marpaESLIF_offsetof("marpaESLIFAction_t" ${member} OFFSETOF_marpaESLIFAction_t_${member})
endforeach()
#
# marpaESLIFGrammarDefaults_t type
#
message(STATUS "Looking at type marpaESLIFGrammarDefaults_t")
foreach(member 
    defaultRuleActionp
    defaultSymbolActionp
    defaultEventActionp
    defaultRegexActionp
    defaultEncodings
    fallbackEncodings
  )
  get_marpaESLIF_offsetof("marpaESLIFGrammarDefaults_t" ${member} OFFSETOF_marpaESLIFGrammarDefaults_t_${member})
endforeach()
#
# marpaESLIFGrammarProperty_t type
#
message(STATUS "Looking at type marpaESLIFGrammarProperty_t")
foreach(member 
    leveli
    maxLeveli
    descp
    latmb
    discardIsFallbackb
    defaultSymbolActionp
    defaultRuleActionp
    defaultEventActionp
    defaultRegexActionp
    starti
    discardi
    nsymboll
    symbolip
    nrulel
    ruleip
    defaultEncodings
    fallbackEncodings
  )
  get_marpaESLIF_offsetof("marpaESLIFGrammarProperty_t" ${member} OFFSETOF_marpaESLIFGrammarProperty_t_${member})
endforeach()
#
# marpaESLIFRuleProperty_t type
#
message(STATUS "Looking at type marpaESLIFRuleProperty_t")
foreach(member 
    idi
    descp
    asciishows
    lhsi
    separatori
    nrhsl
    rhsip
    skipbp
    exceptioni
    actionp
    discardEvents
    discardEventb
    ranki
    nullRanksHighb
    sequenceb
    properb
    minimumi
    propertyBitSet
    hideseparatorb
  )
  get_marpaESLIF_offsetof("marpaESLIFRuleProperty_t" ${member} OFFSETOF_marpaESLIFRuleProperty_t_${member})
endforeach()
#
# marpaESLIFSymbolProperty_t type
#
message(STATUS "Looking at type marpaESLIFSymbolProperty_t")
foreach(member 
    type
    startb
    discardb
    discardRhsb
    lhsb
    topb
    idi
    descp
    eventBefores
    eventBeforeb
    eventAfters
    eventAfterb
    eventPredicteds
    eventPredictedb
    eventNulleds
    eventNulledb
    eventCompleteds
    eventCompletedb
    discardEvents
    discardEventb
    lookupResolvedLeveli
    priorityi
    nullableActionp
    propertyBitSet
    eventBitSet
    symbolActionp
    ifActionp
    generatorActionp
    verboseb
  )
  get_marpaESLIF_offsetof("marpaESLIFSymbolProperty_t" ${member} OFFSETOF_marpaESLIFSymbolProperty_t_${member})
endforeach()
#
# marpaESLIFJSONDecodeOption_t type
#
message(STATUS "Looking at type marpaESLIFJSONDecodeOption_t")
foreach(member 
    disallowDupkeysb
    maxDepthl
    noReplacementCharacterb
    positiveInfinityActionp
    negativeInfinityActionp
    positiveNanActionp
    negativeNanActionp
    numberActionp
  )
  get_marpaESLIF_offsetof("marpaESLIFJSONDecodeOption_t" ${member} OFFSETOF_marpaESLIFJSONDecodeOption_t_${member})
endforeach()
#
# marpaESLIFOption_t type
#
message(STATUS "Looking at type marpaESLIFOption_t")
foreach(member 
    genericLoggerp
  )
  get_marpaESLIF_offsetof("marpaESLIFOption_t" ${member} OFFSETOF_marpaESLIFOption_t_${member})
endforeach()
#
# marpaESLIFGrammarOption_t type
#
message(STATUS "Looking at type marpaESLIFGrammarOption_t")
foreach(member 
    bytep
    bytel
    encodings
    encodingl
  )
  get_marpaESLIF_offsetof("marpaESLIFGrammarOption_t" ${member} OFFSETOF_marpaESLIFGrammarOption_t_${member})
endforeach()
#
# marpaESLIFSymbolOption_t type
#
message(STATUS "Looking at type marpaESLIFSymbolOption_t")
foreach(member 
    userDatavp
    importerp
  )
  get_marpaESLIF_offsetof("marpaESLIFSymbolOption_t" ${member} OFFSETOF_marpaESLIFSymbolOption_t_${member})
endforeach()
#
# Our marpaESLIFValueResultFlat_t handy structure
#
message(STATUS "Looking at type marpaESLIFValueResultFlat_t")
foreach(member 
    contextp
    representationp
    type
    c
    b
    i
    l
    f
    d
    p
    a
    y
    s
    r
    t
    ld
    o
  )
  get_marpaESLIF_offsetof("marpaESLIFValueResultFlat_t" ${member} OFFSETOF_marpaESLIFValueResultFlat_t_${member})
endforeach()
if(SIZEOF_MARPAESLIF_LONG_LONG)
  set(member ll)
  get_marpaESLIF_offsetof("marpaESLIFValueResultFlat_t" ${member} OFFSETOF_marpaESLIFValueResultFlat_t_${member})
endif()
#
# Our marpaESLIFActionFlat_t handy structure
#
message(STATUS "Looking at type marpaESLIFActionFlat_t")
foreach(member 
    type
    names
    stringp
    luas
    luaFunction
  )
  get_marpaESLIF_offsetof("marpaESLIFActionFlat_t" ${member} OFFSETOF_marpaESLIFActionFlat_t_${member})
endforeach()
