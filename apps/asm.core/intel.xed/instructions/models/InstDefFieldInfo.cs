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
        public struct InstDefFieldInfo
        {
            public const string TableId = "xed.inst.def.fields";

            public const byte FieldCount = 12;

            public uint InstId;

            public uint PatternId;

            public byte Index;

            public DefFieldClass FieldClass;

            public BitfieldSeg BitfieldSeg;

            public FieldAssign Assignment;

            public FieldValue FieldLiteral;

            public FieldConstraint Constraint;

            public Nonterminal Nonterminal;

            public EmptyZero<byte> IntLiteral;

            public EmptyZero<Hex8> HexLiteral;

            public EmptyZero<uint5> BitLiteral;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,8,12,12,12,12,12,12,12,12,12};

            public static InstDefFieldInfo Empty => default;
        }
    }
}