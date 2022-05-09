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
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public record struct InstOperandRow
        {
            //public const byte FieldCount = 24;

            public const string TableName = "xed.inst.operands";

            [Render(12)]
            public uint PatternId;

            [Render(18)]
            public InstClass InstClass;

            [Render(6)]
            public XedOpCode OpCode;

            [Render(6)]
            public MachineMode Mode;

            [Render(6)]
            public LockIndicator Lock;

            [Render(6)]
            public ModIndicator Mod;

            [Render(10)]
            public BitIndicator RexW;

            [Render(10)]
            public byte OpCount;

            [Render(8)]
            public byte Index;

            [Render(8)]
            public OpName Name;

            [Render(8)]
            public OpKind Kind;

            [Render(10)]
            public EnumFormat<OpAction> Action;

            [Render(10)]
            public EnumFormat<OpWidthCode> WidthCode;

            [Render(10)]
            public GprWidth GprWidth;

            [Render(10)]
            public EmptyZero<ushort> BitWidth;

            [Render(6)]
            public ElementType EType;

            [Render(6)]
            public EmptyZero<ushort> EWidth;

            [Render(12)]
            public EmptyZero<byte> ECount;

            [Render(12)]
            public BitSegType SegInfo;

            [Render(8)]
            public EmptyZero<Register> RegLit;

            [Render(12)]
            public OpModifier Modifier;

            [Render(12)]
            public Visibility Visibility;

            [Render(16)]
            public Nonterminal NonTerminal;

            [Render(1)]
            public asci64 SourceExpr;

            //public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,18,28,6,6,6,6,10,10,8,8,8,10,10,10,10,6,6,12,12,8,12,16,1,};

            public static InstOperandRow Empty => default;

        }
    }
}