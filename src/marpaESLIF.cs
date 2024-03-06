using System;

namespace src
{
    public class marpaESLIF
    {
        public enum marpaESLIFValueResultBool
        {
            MARPAESLIFVALUERESULTBOOL_FALSE = 0,
            MARPAESLIFVALUERESULTBOOL_TRUE = 1,
        }

        public delegate void marpaESLIFValueResultFreeCallback(IntPtr userDatavp, marpaESLIFValueResult marpaESLIFValueResultp);
        public delegate void marpaESLIFReaderDispose(IntPtr userDatavp, IntPtr inputcp, size_t inputl, short eofb, short characterStreamb, string encodings, size_t encodingl);
        public delegate short marpaESLIFRecognizerIfCallback(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, marpaESLIFValueResult marpaESLIFValueResultp, marpaESLIFValueResultBool marpaESLIFValueResultBoolp);
        public delegate marpaESLIFRecognizerIfCallback marpaESLIFRecognizerIfActionResolver(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, string actions);
        public delegate short marpaESLIFRecognizerEventCallback(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, marpaESLIFEvent[] eventArrayp, size_t eventArrayl, marpaESLIFValueResultBool marpaESLIFValueResultBoolp);
        public delegate marpaESLIFRecognizerEventCallback marpaESLIFRecognizerEventActionResolver(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, string actions);

        public enum marpaESLIFCalloutBlockEnum
        {
            MARPAESLIFCALLOUTBLOCK_CALLOUT_NUMBER = 0,
            MARPAESLIFCALLOUTBLOCK_CALLOUT_STRING,
            MARPAESLIFCALLOUTBLOCK_SUBJECT,
            MARPAESLIFCALLOUTBLOCK_PATTERN,
            MARPAESLIFCALLOUTBLOCK_CAPTURE_TOP,
            MARPAESLIFCALLOUTBLOCK_CAPTURE_LAST,
            MARPAESLIFCALLOUTBLOCK_OFFSET_VECTOR,
            MARPAESLIFCALLOUTBLOCK_MARK,
            MARPAESLIFCALLOUTBLOCK_START_MATCH,
            MARPAESLIFCALLOUTBLOCK_CURRENT_POSITION,
            MARPAESLIFCALLOUTBLOCK_NEXT_ITEM,
            MARPAESLIFCALLOUTBLOCK_GRAMMAR_LEVEL,
            MARPAESLIFCALLOUTBLOCK_SYMBOL_ID,
            _MARPAESLIFCALLOUTBLOCK_SIZE,
        }

        public static string[] marpaESLIFCalloutKeysp =
        {
            "callout_number",
            "callout_string",
            "subject",
            "pattern",
            "capture_top",
            "capture_last",
            "offset_vector",
            "mark",
            "start_match",
            "current_position",
            "next_item",
            "grammar_level",
            "symbol_id"
        };

        public delegate short marpaESLIFRecognizerRegexCallback(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, IntPtr marpaESLIFCalloutBlockp, IntPtr marpaESLIFValueResultOutp);
        public delegate marpaESLIFRecognizerRegexCallback marpaESLIFRecognizerRegexActionResolver(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, string actions);
        public delegate short marpaESLIFRecognizerGeneratorCallback(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, IntPtr contextp, IntPtr marpaESLIFValueResultOutp);
        public delegate marpaESLIFRecognizerGeneratorCallback marpaESLIFRecognizerGeneratorActionResolver(IntPtr userDatavp, IntPtr marpaESLIFRecognizerp, string actions);
        public delegate short marpaESLIFRecognizerImport(IntPtr marpaESLIFRecognizerp, IntPtr userDatavp, IntPtr marpaESLIFValueResultp, short haveUndefb);

        public struct marpaESLIFRecognizerOption
        {
            IntPtr userDatavp;          /* User specific context */
            IntPtr readerCallbackp;     /* Reader */
            short disableThresholdb;   /* Default: 0 */
            short exhaustedb;          /* Exhaustion event. Default: 0 */
            short newlineb;            /* Count line/column numbers. Default: 0 */
            short trackb;              /* Track absolute position. Default: 0 */
            size_t bufsizl;             /* Minimum stream buffer size: Recommended: 0 (internally, a system default will apply) */
            uint buftriggerperci;     /* Excess number of bytes, in percentage of bufsizl, where stream buffer size is reduced. Recommended: 50 */
            uint bufaddperci;         /* Policy of minimum of bytes for increase, in percentage of current allocated size, when stream buffer size need to augment. Recommended: 50 */
            marpaESLIFRecognizerIfActionResolver ifActionResolverp;   /* Will return the function doing the wanted if action */
            marpaESLIFRecognizerEventActionResolver eventActionResolverp; /* Will return the function doing the wanted event action */
            marpaESLIFRecognizerRegexActionResolver regexActionResolverp; /* Will return the function doing the wanted regex callout action */
            marpaESLIFRecognizerGeneratorActionResolver generatorActionResolverp; /* Will return the function doing the wanted symbol generation action */
            marpaESLIFRecognizerImport importerp;           /* If end-user want to import a marpaESLIFValueResult */
        }

        public enum marpaESLIFEventType
        {
            MARPAESLIF_EVENTTYPE_NONE = 0x00,
            MARPAESLIF_EVENTTYPE_COMPLETED = 0x01, /* Grammar event */
            MARPAESLIF_EVENTTYPE_NULLED = 0x02, /* Grammar event */
            MARPAESLIF_EVENTTYPE_PREDICTED = 0x04, /* Grammar event */
            MARPAESLIF_EVENTTYPE_BEFORE = 0x08, /* Just before symbol is commited */
            MARPAESLIF_EVENTTYPE_AFTER = 0x10, /* Just after symbol is commited */
            MARPAESLIF_EVENTTYPE_EXHAUSTED = 0x20, /* Exhaustion */
            MARPAESLIF_EVENTTYPE_DISCARD = 0x40,  /* Discard */
        }

        public struct marpaESLIFEvent
        {
            marpaESLIFEventType type;
            string symbols; /* Symbol name, always NULL if exhausted event, always ':discard' if discard event */
            string events;  /* Event name, always NULL if exhaustion eent */
        }

        public enum marpaESLIFValueType
        {
            MARPAESLIF_VALUE_TYPE_UNDEF = 0,
            MARPAESLIF_VALUE_TYPE_CHAR,
            MARPAESLIF_VALUE_TYPE_SHORT,
            MARPAESLIF_VALUE_TYPE_INT,
            MARPAESLIF_VALUE_TYPE_LONG,
            MARPAESLIF_VALUE_TYPE_FLOAT,
            MARPAESLIF_VALUE_TYPE_DOUBLE,
            MARPAESLIF_VALUE_TYPE_PTR,
            MARPAESLIF_VALUE_TYPE_ARRAY,
            MARPAESLIF_VALUE_TYPE_BOOL,
            MARPAESLIF_VALUE_TYPE_STRING,
            MARPAESLIF_VALUE_TYPE_ROW,
            MARPAESLIF_VALUE_TYPE_TABLE,
            MARPAESLIF_VALUE_TYPE_LONG_DOUBLE,
#if MARPAESLIF_HAVE_LONG_LONG
            MARPAESLIF_VALUE_TYPE_LONG_LONG,
#endif
            MARPAESLIF_VALUE_TYPE_OFFSET_AND_LENGTH,
        }

        public delegate short marpaESLIFValueRuleCallback(IntPtr userDatavp, IntPtr marpaESLIFValuep, int arg0i, int argni, int resulti, short nullableb);
        public delegate short marpaESLIFValueSymbolCallback(IntPtr userDatavp, IntPtr marpaESLIFValuep, IntPtr marpaESLIFValueResult, int resulti);
        public delegate marpaESLIFValueRuleCallback marpaESLIFValueRuleActionResolver(IntPtr userDatavp, IntPtr marpaESLIFValuep, string actions);
        public delegate marpaESLIFValueSymbolCallback marpaESLIFValueSymbolActionResolver(IntPtr userDatavp, IntPtr marpaESLIFValuep, string actions);

        public delegate void marpaESLIFRepresentationDispose(IntPtr userDatavp, string inputcp, size_t inputl, string encodingasciis);
        public delegate short marpaESLIFRepresentation(IntPtr userDatavp, IntPtr marpaESLIFValueResultp, string inputcpp, size_t* inputlp, string encodingasciisp, marpaESLIFRepresentationDispose disposeCallbackpp, short stringbp);

        struct marpaESLIFValueResultPtr
        {
            IntPtr p;
            short shallowb;
            IntPtr freeUserDatavp;
            marpaESLIFValueResultFreeCallback freeCallbackp;
        }
    }
}