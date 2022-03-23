//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        [Record(TableId)]
        public struct InstFieldInfo
        {
            public const string TableId = "xed.inst.patterns.fields";

            public const byte FieldCount = 15;

            public uint InstId;

            public uint PatternId;

            public byte Index;

            public IClass InstClass;

            public XedOpCode OpCode;

            public DefFieldClass FieldClass;

            public EmptyZero<FieldKind> FieldKind;

            public BitfieldSeg Bitfield;

            public FieldAssign Assignment;

            public FieldValue FieldLiteral;

            public FieldConstraint Constraint;

            public Nonterminal Nonterminal;

            public EmptyZero<byte> IntLiteral;

            public EmptyZero<Hex8> HexLiteral;

            public EmptyZero<uint5> BitLiteral;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,8,18,20,12,12,12,22,12,12,22,12,12,12};

            public static InstFieldInfo Empty => default;
        }
    }
}