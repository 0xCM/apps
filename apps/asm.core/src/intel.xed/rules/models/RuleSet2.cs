//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleSet2
        {
            public RuleSetKind Kind {get;}

            public Index<RulePattern> Patterns {get;}

            public Index<RuleTable> Tables {get;}

            public RuleSet2(RuleSetKind kind, RulePattern[] patterns, RuleTable[] tables)
            {
                Kind = kind;
                Patterns = patterns;
                Tables = tables;
            }

            public static RuleSet2 Empty => new RuleSet2(0, sys.empty<RulePattern>(), sys.empty<RuleTable>());
        }
    }
}