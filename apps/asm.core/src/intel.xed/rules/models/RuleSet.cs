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
        public class RuleSet
        {
            public RuleSetKind Kind {get;}

            public Index<RulePatternInfo> Patterns {get;}

            public Index<RuleTable> Tables {get;}

            public RuleSet(RuleSetKind kind, RulePatternInfo[] patterns, RuleTable[] tables)
            {
                Kind = kind;
                Patterns = patterns;
                Tables = tables;
            }

            public static RuleSet Empty => new RuleSet(0, sys.empty<RulePatternInfo>(), sys.empty<RuleTable>());
        }
    }
}