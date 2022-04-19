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
        public record struct PatternOpCode : IComparable<PatternOpCode>
        {
            public const string TableId = "xed.opcodes";

            public const byte FieldCount = 12;

            public uint Seq;

            public ushort PatternId;

            public InstClass InstClass;

            public byte Index;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public LockIndicator Lock;

            public ModIndicator Mod;

            public BitIndicator RexW;

            public RepIndicator Rep;

            public InstFields Layout;

            public InstFields Expr;

            public Hex8 PrimaryByte
            {
                [MethodImpl(Inline)]
                get => OpCode.FirstByte;
            }

            [MethodImpl(Inline)]
            public OcInstClass OcInstClass()
                => XedOpCodes.instclass(InstClass, OpCode, Index);

            [MethodImpl(Inline)]
            public int CompareTo(PatternOpCode src)
                => XedRules.cmp(this, src);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,10,18,8,26,6,6,6,6,6,112,1};
        }
    }
}