//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial struct XedModels
    {
        [Record(TableId)]
        public struct OpCodeCounts : IComparable<OpCodeCounts>
        {
            public const byte FieldCount = 7;

            public const string TableId = "xed.opcodes.counts";

            public uint PatternId;

            public InstClass InstClass;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public InstPatternBody PatternBody;

            public PatternSort Sort;

            public int CompareTo(OpCodeCounts src)
                => Sort.CompareTo(src.Sort);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,18,26,6,6,160,1};
        }
    }
}