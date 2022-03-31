//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedPatterns;
    using static XedFields;

    partial class XedRules
    {
        [Record(TableId)]
        public struct InstFieldRow
        {
            public const string TableId = "xed.inst.patterns.fields";

            public const byte FieldCount = 15;

            public uint PatternId;

            public uint InstId;

            public MachineMode Mode;

            public OpCodeKind OcKind;

            public AsmOcValue OcValue;

            public InstClass InstClass;

            public byte Index;

            public DefFieldClass FieldClass;

            public EmptyZero<FieldKind> FieldKind;

            public FieldExpr FieldExpr;

            public BitfieldSeg Bitfield;

            public Nonterminal Nonterminal;

            public EmptyZero<byte> IntLiteral;

            public EmptyZero<Hex8> HexLiteral;

            public EmptyZero<uint5> BitLiteral;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,8,8,18,18,8,16,16,22,12,22,12,12,12,};

            public static InstFieldRow Empty => default;
        }
    }
}