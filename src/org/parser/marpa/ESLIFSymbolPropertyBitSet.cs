using System;

namespace org.parser.marpa
{
    [Flags]
    public enum ESLIFSymbolPropertyBitSet
    {
        NONE = 0x00,
        ACCESSIBLE = 0x01,
        NULLABLE = 0x02,
        NULLING = 0x04,
        PRODUCTIVE = 0x08,
        START = 0x10,
        TERMINAL = 0x20,
    }
}
