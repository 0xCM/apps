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
        public class MacroExpander
        {
            public static string expand(string src)
            {
                var input = text.trim(text.split(text.despace(src), Chars.Space));
                var count = input.Length;
                var output = alloc<string>(count);
                var names = RuleMacros.names();
                var kinds = RuleMacros.kinds();
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(input,i);
                    if(names.Contains(part))
                    {
                        if(kinds.Lookup(part, out var sym))
                            seek(output,i) = MacroLookup[sym.Kind].Format();
                        else
                            seek(output,i) = part;
                    }
                    else
                        seek(output,i) = part;
                }
                return output.Delimit(Chars.Space).Format();
            }

            public static Index<RuleTermTable> expand(Index<RuleTermTable> src)
            {
                var count = src.Count;
                for(var i=0; i<count; i++)
                    expand(ref src[i]);
                return src;
            }

            static void expand(ref RuleTermTable src)
            {
                ref var expressions = ref src.Expressions;
                var count = expressions.Count;
                for(var i=0; i<count; i++)
                    expand(ref expressions[i]);
            }

            static void expand(ref RuleTermExpr src)
            {
                expand(src.Premise);
                expand(src.Consequent);
            }

            static void expand(Index<RuleTerm> src)
            {
                var count = src.Count;
                for(var i=0; i<count; i++)
                    expand(ref src[i]);
            }

            static void expand(ref RuleTerm src)
            {
                if(MacroKinds.Lookup(src.Value, out var name))
                    src = src.WithValue(MacroLookup[name].Assignments.Format());
            }

        }
    }
}