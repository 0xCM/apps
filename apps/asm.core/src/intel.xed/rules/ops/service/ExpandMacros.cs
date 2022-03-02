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
        public static ConstLookup<RuleMacroName,MacroSpec> macrolookup()
            => RuleMacros.discover().Storage.Map(x => (x.Name, x)).ToDictionary();

        public void ExpandMacros(RuleSet src)
        {
            var lu = macrolookup();
            ExpandMacros(lu, src.Tables);
            ExpandMacros(lu, src.Patterns);
        }

        public void ExpandMacros(Index<InstDef> src)
        {
            var lu = macrolookup();
            for(var i=0; i<src.Count; i++)
                ExpandMacros(lu, src[i].PatternSpecs);
        }

        public void ExpandMacros(Index<RulePattern> src)
        {
            ExpandMacros(macrolookup(),src);
        }

        public void ExpandMacros(Index<InstPatternSpec> src)
        {
            ExpandMacros(macrolookup(), src);
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> lu, Index<InstPatternSpec> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var input = ref src[i];
                src[i] = input.WithPattern(ExpandMacros(lu, input.PatternExpr));
            }
        }

        string ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, string src)
        {
            var input = text.trim(text.split(text.despace(src), Chars.Space));
            var count = input.Length;
            var output = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(input,i);
                if(MacroNameSet.Contains(part))
                {
                    if(MacroNames.Lookup(part, out var sym))
                        seek(output,i) = specs[sym.Kind].Format();
                    else
                        seek(output,i) = part;
                }
                else
                    seek(output,i) = part;
            }
            return output.Delimit(Chars.Space).Format();
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, Index<RuleTable> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var table = ref src[i];
                ExpandMacros(specs, ref table);
            }
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, Index<RulePattern> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var pattern = ref src[i];
                ExpandMacros(specs, ref pattern);
            }
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref RuleTable src)
        {
            ref var expressions = ref src.Expressions;
            var count = expressions.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref expressions[i]);
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref RuleExpr src)
        {
            ExpandMacros(specs, src.Premise);
            ExpandMacros(specs, src.Consequent);
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, Index<RuleCriterion> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref src[i]);
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref RulePattern src)
        {
            // var input = text.trim(text.split(text.despace(src.Expression.Format()), Chars.Space));
            // var count = input.Length;
            // var output = alloc<string>(count);
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var part = ref skip(input,i);
            //     if(MacroNameSet.Contains(part))
            //     {
            //         if(MacroNames.Lookup(part, out var sym))
            //             seek(output,i) = specs[sym.Kind].Format();
            //         else
            //             seek(output,i) = part;
            //     }
            //     else
            //         seek(output,i) = part;
            // }
            src.Expression = ExpandMacros(specs,src.Expression);
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref RuleCriterion src)
        {
            if(MacroNames.Lookup(src.Value, out var name))
                src = src.WithValue(specs[name].Assignments.Format());
        }
    }
}