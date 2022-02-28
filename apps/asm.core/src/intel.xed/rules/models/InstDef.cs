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
        public struct InstDef : IComparable<InstDef>
        {
            public IClass Class;

            public IForm Form;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public Index<AttributeKind> Attributes;

            public Index<FlagAction> Flags;

            public Index<InstPatternSpec> PatternSpecs;

            public int CompareTo(InstDef src)
            {
                var result = ((ushort)Class).CompareTo((ushort)src.Class);
                if(result == 0)
                {
                    if(PatternSpecs.IsNonEmpty && src.PatternSpecs.IsNonEmpty)
                        result = PatternSpecs.First.PatternExpr.CompareTo(src.PatternSpecs.First.PatternExpr);
                }
                return result;
            }
        }
    }
}