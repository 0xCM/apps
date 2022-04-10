//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public struct PatternOpRow : IComparable<PatternOpRow>
        {
            public const byte FieldCount = 21;

            public const string TableName = "xed.inst.patterns.ops";

            public uint InstId;

            public uint PatternId;

            public InstClass InstClass;

            public MachineMode Mode;

            public OpCodeKind OcKind;

            public AsmOcValue OcValue;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public EnumFormat<OpAction> Action;

            public EnumFormat<OpWidthCode> WidthCode;

            public EmptyZero<ushort> BitWidth;

            public ElementType EType;

            public EmptyZero<ushort> EWidth;

            public EmptyZero<byte> ECount;

            public SegType SegType;

            public Register RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerminal;

            public @string SourceExpr;

            public int CompareTo(PatternOpRow src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                {
                    result = PatternId.CompareTo(src.PatternId);
                    if(result == 0)
                        result = Index.CompareTo(src.Index);
                }
                return result;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,10,18,6,10,16,6,8,8,8,10,10,10,6,6,12,12,8,12,16,1,};

            public static PatternOpRow Empty => default;
        }
    }
}