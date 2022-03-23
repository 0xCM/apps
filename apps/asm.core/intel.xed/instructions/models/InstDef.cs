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
        public struct InstDef : IComparable<InstDef>
        {
            public uint InstId;

            public IClass Class;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public InstAttribs Attributes;

            public Index<XedFlagEffect> FlagEffects;

            public Index<InstPatternSpec> PatternSpecs;

            public int CompareTo(InstDef src)
            {
                var result = ((ushort)Class).CompareTo((ushort)src.Class);
                if(result == 0)
                {
                    if(PatternSpecs.IsNonEmpty && src.PatternSpecs.IsNonEmpty)
                        result = PatternSpecs.First.Body[0].Format().CompareTo(src.PatternSpecs.First.Body[0].Format());
                }
                return result;
            }
        }
    }
}