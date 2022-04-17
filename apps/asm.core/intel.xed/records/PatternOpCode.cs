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
        [Record(TableId)]
        public struct PatternOpCode : IComparable<PatternOpCode>
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 11;

            public uint Seq;

            public ushort PatternId;

            public InstClass InstClass;

            public byte Index;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public InstLock Lock;

            public ModKind Mod;

            public RexBit RexW;

            public InstFields Layout;

            public InstFields Expr;

            public int CompareTo(PatternOpCode src)
                => new PatternOrder().Compare(this,src);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,10,18,8,26,6,6,6,6,112,1};
        }
    }
}