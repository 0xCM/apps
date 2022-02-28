//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public Index<NonterminalRule> Nonterminals(ReadOnlySpan<RuleTable> src)
        {
            var nonterms = NonterminalKinds().Map(x => (x.ToString(),x)).ToDictionary();
            var count = src.Length;
            var buffer = list<NonterminalRule>();
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref src[i];
                var name = rule.Name.Format().ToUpperInvariant();
                if(nonterms.TryGetValue(name, out var kind))
                    buffer.Add((rule,kind));
            }
            return buffer.ToArray();
        }

        public Index<TerminalRule> Terminals(ReadOnlySpan<RuleTable> src)
        {
            var nonterms = NonterminalKinds().Map(x => (x.ToString(),x)).ToDictionary();
            var count = src.Length;
            var buffer = list<TerminalRule>();
            for(var i=0; i<count; i++)
            {
                ref readonly var rule = ref src[i];
                var name = rule.Name.Format().ToUpperInvariant();
                if(!nonterms.ContainsKey(name))
                    buffer.Add(rule);
            }
            return buffer.ToArray();
        }
    }
}