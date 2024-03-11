/* Wrapper on marpaESLIF.h to ease the manipulation of some marpaESLIF structures. */

/* Some marpaESLIF structures are using unions. We make flat version of them ease P/Invoke. */

#ifndef MARPAESLIFCSHARP_MARPAESLIF_WRAPPER
#define MARPAESLIFCSHARP_MARPAESLIF_WRAPPER

#ifndef MARPAESLIFCSHARP_MARPAESLIF_WRAPPER_INTROSPECTION
#include <marpaESLIF_wrapper/export.h>
#else
#define marpaESLIF_wrapper_EXPORT
#endif /* MARPAESLIFCSHARP_MARPAESLIF_WRAPPER_INTROSPECTION */
#include <marpaESLIF.h>

typedef struct marpaESLIFValueResultFlat {
  void                      *contextp;          /* Free value meaningful only to the user */
  marpaESLIFRepresentation_t representationp;   /* How a user-land alternative is represented if it was in the input */
  marpaESLIFValueType_t      type;              /* Type for tagging the following union */
  marpaESLIFValueResultChar_t             c; /* Value is a char */
  marpaESLIFValueResultShort_t            b; /* Value is a short */
  marpaESLIFValueResultInt_t              i; /* Value is an int */
  marpaESLIFValueResultLong_t             l; /* Value is a long */
  marpaESLIFValueResultFloat_t            f; /* Value is a float */
  marpaESLIFValueResultDouble_t           d; /* Value is a double */
  marpaESLIFValueResultPtr_t              p; /* Value is a pointer */
  marpaESLIFValueResultArray_t            a; /* Value is a byte array */
  marpaESLIFValueResultBool_t             y; /* Value is a boolean */
  marpaESLIFValueResultString_t           s; /* Value is a string */
  marpaESLIFValueResultRow_t              r; /* Value is a row of values */
  marpaESLIFValueResultTable_t            t; /* Value is a row of values, where sizel is even */
  marpaESLIFValueResultLongDouble_t      ld; /* Value is a long double */
#ifdef MARPAESLIF_HAVE_LONG_LONG
  marpaESLIFValueResultLongLong_t        ll; /* Value is a long long */
#endif
  marpaESLIFValueResultOffsetAndLength_t  o; /* Value is an offset and length */
} marpaESLIFValueResultFlat_t;

typedef struct marpaESLIFActionFlat {
  marpaESLIFActionType_t type;
  char                          *names;
  marpaESLIFString_t            *stringp;
  char                          *luas;
  marpaESLIFLuaFunction_t        luaFunction;
} marpaESLIFActionFlat_t;

#ifdef __cplusplus
extern "C" {
#endif
  /* ===================== */
  /* marpaESLIFValueResult */
  /* ===================== */
  marpaESLIF_wrapper_EXPORT marpaESLIFValueResultFlat_t *marpaESLIFValueResultConvertp(marpaESLIFValueResult_t *marpaESLIFValueResultp);
  marpaESLIF_wrapper_EXPORT marpaESLIFValueResult_t     *marpaESLIFValueResultFlatConvertp(marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp);
  marpaESLIF_wrapper_EXPORT marpaESLIFActionFlat_t      *marpaESLIFActionConvertp(marpaESLIFAction_t *marpaESLIFActionp);
  marpaESLIF_wrapper_EXPORT marpaESLIFAction_t          *marpaESLIFActionFlatConvertp(marpaESLIFActionFlat_t *marpaESLIFActionFlatp);
  /* ============================= */
  /* Acces to CLR memory functions */
  /* ============================= */
  marpaESLIF_wrapper_EXPORT void *marpaESLIF_malloc(size_t sizel);
  marpaESLIF_wrapper_EXPORT void *marpaESLIF_realloc(void *p, size_t sizel);
  marpaESLIF_wrapper_EXPORT void  marpaESLIF_free(void *p);
#ifdef __cplusplus
}
#endif

#endif /* MARPAESLIFCSHARP_MARPAESLIF_WRAPPER */
