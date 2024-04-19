#include <stdlib.h>
#include <string.h>
#include <marpaESLIF_wrapper.h>

void marpaESLIFValueResultFlatToMarpaESLIFValueResult(marpaESLIFValueResult_t *marpaESLIFValueResultp, marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp)
{
  marpaESLIFValueResultp->contextp        = marpaESLIFValueResultFlatp->contextp;
  marpaESLIFValueResultp->representationp = marpaESLIFValueResultFlatp->representationp;
  switch (marpaESLIFValueResultp->type = marpaESLIFValueResultFlatp->type) {
  case MARPAESLIF_VALUE_TYPE_CHAR:
    marpaESLIFValueResultp->u.c             = marpaESLIFValueResultFlatp->c;
    break;
  case MARPAESLIF_VALUE_TYPE_SHORT:
    marpaESLIFValueResultp->u.b             = marpaESLIFValueResultFlatp->b;
    break;
  case MARPAESLIF_VALUE_TYPE_INT:
    marpaESLIFValueResultp->u.i             = marpaESLIFValueResultFlatp->i;
    break;
  case MARPAESLIF_VALUE_TYPE_LONG:
    marpaESLIFValueResultp->u.l             = marpaESLIFValueResultFlatp->l;
    break;
  case MARPAESLIF_VALUE_TYPE_FLOAT:
    marpaESLIFValueResultp->u.f             = marpaESLIFValueResultFlatp->f;
    break;
  case MARPAESLIF_VALUE_TYPE_DOUBLE:
    marpaESLIFValueResultp->u.d             = marpaESLIFValueResultFlatp->d;
    break;
  case MARPAESLIF_VALUE_TYPE_PTR:
    marpaESLIFValueResultp->u.p             = marpaESLIFValueResultFlatp->p;
    break;
  case MARPAESLIF_VALUE_TYPE_ARRAY:
    marpaESLIFValueResultp->u.a             = marpaESLIFValueResultFlatp->a;
    break;
  case MARPAESLIF_VALUE_TYPE_BOOL:
    marpaESLIFValueResultp->u.y             = marpaESLIFValueResultFlatp->y;
    break;
  case MARPAESLIF_VALUE_TYPE_STRING:
    marpaESLIFValueResultp->u.s             = marpaESLIFValueResultFlatp->s;
    break;
  case MARPAESLIF_VALUE_TYPE_ROW:
    marpaESLIFValueResultp->u.r             = marpaESLIFValueResultFlatp->r;
    break;
  case MARPAESLIF_VALUE_TYPE_TABLE:
    marpaESLIFValueResultp->u.t             = marpaESLIFValueResultFlatp->t;
    break;
  case MARPAESLIF_VALUE_TYPE_LONG_DOUBLE:
    marpaESLIFValueResultp->u.ld            = marpaESLIFValueResultFlatp->ld;
    break;
#ifdef MARPAESLIF_HAVE_LONG_LONG
  case MARPAESLIF_VALUE_TYPE_LONG_LONG:
    marpaESLIFValueResultp->u.ll            = marpaESLIFValueResultFlatp->ll;
    break;
#endif
  case MARPAESLIF_VALUE_TYPE_OFFSET_AND_LENGTH:
    marpaESLIFValueResultp->u.o             = marpaESLIFValueResultFlatp->o;
    break;
  default:
    break;
  }
}

void marpaESLIFValueResultToMarpaESLIFValueResultFlat(marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp, marpaESLIFValueResult_t *marpaESLIFValueResultp)
{
  /* This is a flat version of something that should be an union */
  /* We make sure that we does not contain invalid things, in particular memory safeguards, by doing a memset */
  memset(marpaESLIFValueResultFlatp, 0, sizeof(marpaESLIFValueResultFlat_t));

  /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
  marpaESLIFValueResultFlatp->contextp        = marpaESLIFValueResultp->contextp;
  marpaESLIFValueResultFlatp->representationp = marpaESLIFValueResultp->representationp;
  switch (marpaESLIFValueResultFlatp->type = marpaESLIFValueResultp->type) {
  case MARPAESLIF_VALUE_TYPE_CHAR:
    marpaESLIFValueResultFlatp->c               = marpaESLIFValueResultp->u.c;
    break;
  case MARPAESLIF_VALUE_TYPE_SHORT:
    marpaESLIFValueResultFlatp->b               = marpaESLIFValueResultp->u.b;
    break;
  case MARPAESLIF_VALUE_TYPE_INT:
    marpaESLIFValueResultFlatp->i               = marpaESLIFValueResultp->u.i;
    break;
  case MARPAESLIF_VALUE_TYPE_LONG:
    marpaESLIFValueResultFlatp->l               = marpaESLIFValueResultp->u.l;
    break;
  case MARPAESLIF_VALUE_TYPE_FLOAT:
    marpaESLIFValueResultFlatp->f               = marpaESLIFValueResultp->u.f;
    break;
  case MARPAESLIF_VALUE_TYPE_DOUBLE:
    marpaESLIFValueResultFlatp->d               = marpaESLIFValueResultp->u.d;
    break;
  case MARPAESLIF_VALUE_TYPE_PTR:
    marpaESLIFValueResultFlatp->p               = marpaESLIFValueResultp->u.p;
    break;
  case MARPAESLIF_VALUE_TYPE_ARRAY:
    marpaESLIFValueResultFlatp->a               = marpaESLIFValueResultp->u.a;
    break;
  case MARPAESLIF_VALUE_TYPE_BOOL:
    marpaESLIFValueResultFlatp->y               = marpaESLIFValueResultp->u.y;
    break;
  case MARPAESLIF_VALUE_TYPE_STRING:
    marpaESLIFValueResultFlatp->s               = marpaESLIFValueResultp->u.s;
    break;
  case MARPAESLIF_VALUE_TYPE_ROW:
    marpaESLIFValueResultFlatp->r               = marpaESLIFValueResultp->u.r;
    break;
  case MARPAESLIF_VALUE_TYPE_TABLE:
    marpaESLIFValueResultFlatp->t               = marpaESLIFValueResultp->u.t;
    break;
  case MARPAESLIF_VALUE_TYPE_LONG_DOUBLE:
    marpaESLIFValueResultFlatp->ld              = marpaESLIFValueResultp->u.ld;
    break;
#ifdef MARPAESLIF_HAVE_LONG_LONG
  case MARPAESLIF_VALUE_TYPE_LONG_LONG:
    marpaESLIFValueResultFlatp->ll              = marpaESLIFValueResultp->u.ll;
    break;
#endif
  case MARPAESLIF_VALUE_TYPE_OFFSET_AND_LENGTH:
    marpaESLIFValueResultFlatp->o               = marpaESLIFValueResultp->u.o;
    break;
  default:
    break;
  }
}

marpaESLIFValueResultFlat_t*marpaESLIFValueResultConvertp(marpaESLIFValueResult_t *marpaESLIFValueResultp)
{
  marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp = malloc(sizeof(marpaESLIFValueResultFlat_t));

  if (marpaESLIFValueResultFlatp != NULL) {
    marpaESLIFValueResultToMarpaESLIFValueResultFlat(marpaESLIFValueResultFlatp, marpaESLIFValueResultp);
  }

  return marpaESLIFValueResultFlatp;
}

marpaESLIFValueResult_t *marpaESLIFValueResultFlatConvertp(marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp)
{
  marpaESLIFValueResult_t *marpaESLIFValueResultp = malloc(sizeof(marpaESLIFValueResult_t));

  if (marpaESLIFValueResultp != NULL) {
    marpaESLIFValueResultFlatToMarpaESLIFValueResult(marpaESLIFValueResultp, marpaESLIFValueResultFlatp);
  }

  return marpaESLIFValueResultp;
}

marpaESLIFActionFlat_t *marpaESLIFActionConvertp(marpaESLIFAction_t *marpaESLIFActionp)
{
  marpaESLIFActionFlat_t *marpaESLIFActionFlatp = malloc(sizeof(marpaESLIFActionFlat_t));

  if (marpaESLIFActionFlatp != NULL) {
    /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
    marpaESLIFActionFlatp->type        = marpaESLIFActionp->type;
    marpaESLIFActionFlatp->names       = marpaESLIFActionp->u.names;
    marpaESLIFActionFlatp->stringp     = marpaESLIFActionp->u.stringp;
    marpaESLIFActionFlatp->luas        = marpaESLIFActionp->u.luas;
    marpaESLIFActionFlatp->luaFunction = marpaESLIFActionp->u.luaFunction;
  }

  return marpaESLIFActionFlatp;
}

marpaESLIFAlternative_t *marpaESLIFAlternativep(char *names, marpaESLIFValueResult_t *marpaESLIFValueResultp, size_t grammarLengthl)
{
  marpaESLIFAlternative_t *marpaESLIFAlternativep = malloc(sizeof(marpaESLIFAlternative_t));

  if (marpaESLIFAlternativep != NULL) {
    marpaESLIFAlternativep->names          = names;
    marpaESLIFAlternativep->value          = *marpaESLIFValueResultp;
    marpaESLIFAlternativep->grammarLengthl = grammarLengthl;
  }

  return marpaESLIFAlternativep;
}

marpaESLIFAction_t *marpaESLIFActionFlatConvertp(marpaESLIFActionFlat_t *marpaESLIFActionFlatp)
{
  marpaESLIFAction_t *marpaESLIFActionp = malloc(sizeof(marpaESLIFAction_t));

  if (marpaESLIFActionp != NULL) {
    /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
    marpaESLIFActionp->type          = marpaESLIFActionFlatp->type;
    marpaESLIFActionp->u.names       = marpaESLIFActionFlatp->names;
    marpaESLIFActionp->u.stringp     = marpaESLIFActionFlatp->stringp;
    marpaESLIFActionp->u.luas        = marpaESLIFActionFlatp->luas;
    marpaESLIFActionp->u.luaFunction = marpaESLIFActionFlatp->luaFunction;
  }

  return marpaESLIFActionp;
}

void *marpaESLIF_malloc(size_t sizel)
{
  return malloc(sizel);
}

void *marpaESLIF_realloc(void *p, size_t sizel)
{
  return realloc(p, sizel);
}

void marpaESLIF_free(void *p) {
  free(p);
}

void marpaESLIF_memcpy(void *dstp, void *srcp, size_t sizel) {
  memcpy(dstp, srcp, sizel);
}

void marpaESLIF_memmove(void *dstp, void *srcp, size_t sizel) {
  memmove(dstp, srcp, sizel);
}

