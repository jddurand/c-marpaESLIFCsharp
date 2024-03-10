#include <marpaESLIF_wrapper.h>

void marpaESLIFValueResultConvertv(marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp, marpaESLIFValueResult_t *marpaESLIFValueResultp)
{
  /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
  marpaESLIFValueResultFlatp->contextp        = marpaESLIFValueResultp->contextp;
  marpaESLIFValueResultFlatp->representationp = marpaESLIFValueResultp->representationp;
  marpaESLIFValueResultFlatp->type            = marpaESLIFValueResultp->type;
  marpaESLIFValueResultFlatp->c               = marpaESLIFValueResultp->u.c;
  marpaESLIFValueResultFlatp->b               = marpaESLIFValueResultp->u.b;
  marpaESLIFValueResultFlatp->i               = marpaESLIFValueResultp->u.i;
  marpaESLIFValueResultFlatp->l               = marpaESLIFValueResultp->u.l;
  marpaESLIFValueResultFlatp->f               = marpaESLIFValueResultp->u.f;
  marpaESLIFValueResultFlatp->d               = marpaESLIFValueResultp->u.d;
  marpaESLIFValueResultFlatp->p               = marpaESLIFValueResultp->u.p;
  marpaESLIFValueResultFlatp->a               = marpaESLIFValueResultp->u.a;
  marpaESLIFValueResultFlatp->y               = marpaESLIFValueResultp->u.y;
  marpaESLIFValueResultFlatp->s               = marpaESLIFValueResultp->u.s;
  marpaESLIFValueResultFlatp->r               = marpaESLIFValueResultp->u.r;
  marpaESLIFValueResultFlatp->t               = marpaESLIFValueResultp->u.t;
  marpaESLIFValueResultFlatp->ld              = marpaESLIFValueResultp->u.ld;
#ifdef MARPAESLIF_HAVE_LONG_LONG
  marpaESLIFValueResultFlatp->ll              = marpaESLIFValueResultp->u.ll;
#endif
  marpaESLIFValueResultFlatp->o               = marpaESLIFValueResultp->u.o;
}

void marpaESLIFValueResultFlatConvertv(marpaESLIFValueResult_t *marpaESLIFValueResultp, marpaESLIFValueResultFlat_t *marpaESLIFValueResultFlatp)
{
  /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
  marpaESLIFValueResultp->contextp        = marpaESLIFValueResultFlatp->contextp;
  marpaESLIFValueResultp->representationp = marpaESLIFValueResultFlatp->representationp;
  marpaESLIFValueResultp->type            = marpaESLIFValueResultFlatp->type;
  marpaESLIFValueResultp->u.c             = marpaESLIFValueResultFlatp->c;
  marpaESLIFValueResultp->u.b             = marpaESLIFValueResultFlatp->b;
  marpaESLIFValueResultp->u.i             = marpaESLIFValueResultFlatp->i;
  marpaESLIFValueResultp->u.l             = marpaESLIFValueResultFlatp->l;
  marpaESLIFValueResultp->u.f             = marpaESLIFValueResultFlatp->f;
  marpaESLIFValueResultp->u.d             = marpaESLIFValueResultFlatp->d;
  marpaESLIFValueResultp->u.p             = marpaESLIFValueResultFlatp->p;
  marpaESLIFValueResultp->u.a             = marpaESLIFValueResultFlatp->a;
  marpaESLIFValueResultp->u.y             = marpaESLIFValueResultFlatp->y;
  marpaESLIFValueResultp->u.s             = marpaESLIFValueResultFlatp->s;
  marpaESLIFValueResultp->u.r             = marpaESLIFValueResultFlatp->r;
  marpaESLIFValueResultp->u.t             = marpaESLIFValueResultFlatp->t;
  marpaESLIFValueResultp->u.ld            = marpaESLIFValueResultFlatp->ld;
#ifdef MARPAESLIF_HAVE_LONG_LONG
  marpaESLIFValueResultp->u.ll            = marpaESLIFValueResultFlatp->ll;
#endif
  marpaESLIFValueResultp->u.o             = marpaESLIFValueResultFlatp->o;
}

void marpaESLIFActionConvertv(marpaESLIFActionFlat_t *marpaESLIFActionFlatp, marpaESLIFAction_t *marpaESLIFActionp)
{
  /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
  marpaESLIFActionFlatp->type        = marpaESLIFActionp->type;
  marpaESLIFActionFlatp->names       = marpaESLIFActionp->u.names;
  marpaESLIFActionFlatp->stringp     = marpaESLIFActionp->u.stringp;
  marpaESLIFActionFlatp->luas        = marpaESLIFActionp->u.luas;
  marpaESLIFActionFlatp->luaFunction = marpaESLIFActionp->u.luaFunction;
}

void marpaESLIFActionFlatConvertv(marpaESLIFAction_t *marpaESLIFActionp, marpaESLIFActionFlat_t *marpaESLIFActionFlatp)
{
  /* We do NOT really mind if everything has a meaning. We just assign and this remains correct. */
  marpaESLIFActionp->type          = marpaESLIFActionFlatp->type;
  marpaESLIFActionp->u.names       = marpaESLIFActionFlatp->names;
  marpaESLIFActionp->u.stringp     = marpaESLIFActionFlatp->stringp;
  marpaESLIFActionp->u.luas        = marpaESLIFActionFlatp->luas;
  marpaESLIFActionp->u.luaFunction = marpaESLIFActionFlatp->luaFunction;
}

