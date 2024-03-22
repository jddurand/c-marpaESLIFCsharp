using System;

namespace org.parser.marpa
{
    [Flags]
    public enum ESLIFSymbolEventBitSet
    {
        COMPLETION = 0x01,
        NULLED = 0x02,
        PREDICTION = 0x04,
    }
}
