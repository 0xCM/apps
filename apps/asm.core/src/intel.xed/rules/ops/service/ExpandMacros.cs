//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void ExpandMacros(RuleSet src)
        {
            ExpandMacros(MacroLookup, src.Tables);
            ExpandMacros(MacroLookup, src.Patterns);
        }

        public void ExpandMacros(Index<InstDef> src)
        {
            for(var i=0; i<src.Count; i++)
                ExpandMacros(MacroLookup, src[i].PatternSpecs);
        }

        public void ExpandMacros(Index<RulePatternInfo> src)
        {
            ExpandMacros(MacroLookup,src);
        }

        public void ExpandMacros(Index<InstPatternSpec> src)
        {
            ExpandMacros(MacroLookup, src);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> lu, Index<InstPatternSpec> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var input = ref src[i];
                src[i] = input.WithPattern(ExpandMacros(lu, input.PatternExpr));
            }
        }

        static string ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, string src)
        {
            var input = text.trim(text.split(text.despace(src), Chars.Space));
            var count = input.Length;
            var output = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(input,i);
                if(MacroNameSet.Contains(part))
                {
                    if(MacroKinds.Lookup(part, out var sym))
                        seek(output,i) = specs[sym.Kind].Format();
                    else
                        seek(output,i) = part;
                }
                else
                    seek(output,i) = part;
            }
            return output.Delimit(Chars.Space).Format();
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, Index<RuleTable> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var table = ref src[i];
                ExpandMacros(specs, ref table);
            }
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, Index<RulePatternInfo> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var pattern = ref src[i];
                ExpandMacros(specs, ref pattern);
            }
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleTable src)
        {
            ref var expressions = ref src.Expressions;
            var count = expressions.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref expressions[i]);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleExpr src)
        {
            ExpandMacros(specs, src.Premise);
            ExpandMacros(specs, src.Consequent);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, Index<RuleCriterion> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref src[i]);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RulePatternInfo src)
        {
            src.Expression = ExpandMacros(specs,src.Expression);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleCriterion src)
        {
            if(MacroKinds.Lookup(src.Value, out var name))
                src = src.WithValue(specs[name].Assignments.Format());
        }
    }
}