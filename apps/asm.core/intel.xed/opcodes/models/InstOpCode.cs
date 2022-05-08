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
        public record struct InstOpCode : IComparable<InstOpCode>
        {
            public const string TableId = "xed.inst.opcodes";

            [Render(8)]
            public uint Seq;

            [Render(12)]
            public ushort PatternId;

            [Render(18)]
            public InstClass InstClass;

            [Render(8)]
            public byte Index;

            [Render(26)]
            public XedOpCode OpCode;

            [Render(6)]
            public MachineMode Mode;

            [Render(6)]
            public LockIndicator Lock;

            [Render(6)]
            public ModIndicator Mod;

            [Render(6)]
            public BitIndicator RexW;

            [Render(6)]
            public RepIndicator Rep;

            [Render(112)]
            public InstCells Layout;

            [Render(1)]
            public InstCells Expr;

            public Hex8 PrimaryByte
            {
                [MethodImpl(Inline)]
                get => OpCode.FirstByte;
            }

            [MethodImpl(Inline)]
            public int CompareTo(InstOpCode src)
                => XedRules.cmp(this, src);
        }
    }
}