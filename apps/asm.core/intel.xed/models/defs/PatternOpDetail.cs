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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct PatternOpDetail : IComparable<PatternOpDetail>
        {
            public uint InstId;

            public uint PatternId;

            public InstClass InstClass;

            public MachineMode Mode;

            public InstLock Lock;

            public XedOpCode OpCode;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAction Action;

            public OpWidthCode WidthCode;

            public GprWidth GrpWidth;

            public ushort BitWidth;

            public ElementType ElementType;

            public ushort ElementWidth;

            public byte ElementCount;

            public BitSegType SegInfo;

            public Register RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerminal;

            public asci32 SourceExpr;

            public int CompareTo(PatternOpDetail src)
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

            public static PatternOpDetail Empty => default;
        }
    }
}