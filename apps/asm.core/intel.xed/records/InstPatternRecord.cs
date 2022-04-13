//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [Record(TableId),StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct InstPatternRecord : IComparable<InstPatternRecord>
        {
            public const string TableId = "xed.inst.patterns";

            public const byte FieldCount = 8;

            public uint PatternId;

            public InstClass InstClass;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public EmptyZero<bit> Scalable;

            public InstForm InstForm;

            public InstPatternBody Body;

            public int CompareTo(InstPatternRecord src)
                => Sort().CompareTo(src.Sort());

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,18,26,8,8,8,52,1};

            public static InstPatternRecord Empty => default;
        }
    }
}