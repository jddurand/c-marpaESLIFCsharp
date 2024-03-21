using System;

namespace org.parser.marpa
{
    [Flags]
    public enum ESLIFRulePropertyBitSet
    {
        NONE= 0x00,
        ACCESSIBLE = 0x01,
        NULLABLE = 0x02,
        NULLING = 0x04,
        LOOP = 0x08,
        PRODUCTIVE = 0x10,
    }
}
