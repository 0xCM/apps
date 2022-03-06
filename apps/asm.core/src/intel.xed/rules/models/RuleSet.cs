//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleSet
        {
            public RuleSetKind Kind {get;}

            public Index<RulePattern> Patterns {get;}

            public Index<RuleTermTable> Tables {get;}

            public RuleSet(RuleSetKind kind, RulePattern[] patterns, RuleTermTable[] tables)
            {
                Kind = kind;
                Patterns = patterns;
                Tables = tables;
            }

            public static RuleSet Empty => new RuleSet(0, sys.empty<RulePattern>(), sys.empty<RuleTermTable>());
        }
    }
}