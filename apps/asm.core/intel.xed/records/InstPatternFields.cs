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
        public struct InstFieldRow
        {
            public const string TableId = "xed.inst.patterns.fields";

            public const byte FieldCount = 16;

            public uint PatternId;

            public InstClass InstClass;

            public XedOpCode OpCode;

            public MachineMode Mode;

            public LockIndicator Lock;

            public byte Index;

            public CellClass FieldClass;

            public EmptyZero<FieldKind> FieldKind;

            public CellExpr FieldExpr;

            public InstSeg Seg;

            public SegField SegField;

            public SegVar SegVar;

            public Nonterminal Nonterminal;

            public EmptyZero<byte> IntLiteral;

            public EmptyZero<Hex8> HexLiteral;

            public EmptyZero<uint5> BitLiteral;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,18,26,8,8,12,12,26,16,16,16,16,22,22,12,12,};

            public static InstFieldRow Empty => default;
        }
    }
}