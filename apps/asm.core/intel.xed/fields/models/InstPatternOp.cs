//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public struct InstPatternOp : IComparable<InstPatternOp>
        {
            public const byte FieldCount = 19;

            public const string TableName = "xed.inst.patterns.ops";

            public uint InstId;

            public uint PatternId;

            public InstClass InstClass;

            public MachineMode Mode;

            public XedOpCode OpCode;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public EmptyZero<bit> NonTerm;

            public OpAttrib Action;

            public OpWidth OpWidth;

            public ElementType CellType;

            public EmptyZero<ushort> BitWidth;

            public EmptyZero<ushort> CellWidth;

            public OpAttrib RegLit;

            public OpAttrib Modifier;

            public Visibility Visibility;

            public @string Expression;

            public Nonterminal NonTerminal;

            public int CompareTo(InstPatternOp src)
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

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{10,10,18,6,24,6,8,8,8,8,10,10,10,10,16,8,12,32,1,};

            public static InstPatternOp Empty => default;
        }
    }
}