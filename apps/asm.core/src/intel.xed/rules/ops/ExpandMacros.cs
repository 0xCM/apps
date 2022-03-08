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
        public RuleSet ExpandMacros(RuleSet src)
        {
            ExpandMacros(src.Tables);
            ExpandMacros(src.Patterns);
            return src;
        }

        public void ExpandMacros(Index<RulePattern> src)
        {
            var assign = span<FieldAssign>(12);
            var tokens = list<RuleToken>(32);
            for(var i=0; i<src.Count; i++)
                src[i] = ExpandMacros(src[i]);
        }

        public static RulePattern ExpandMacros(in RulePattern pattern)
        {
            var tokens = list<RuleToken>(32);
            var assign = span<FieldAssign>(12);
            for(var j=0; j<pattern.Tokens.Count;j++)
            {
                ref var token = ref pattern.Tokens[j];
                var count = expand(token,assign);
                if(count > 0)
                {
                    for(var k=0; k<count; k++)
                        tokens.Add(new RuleToken(skip(assign,k)));
                }
                else
                    tokens.Add(token);
            }
            return pattern.WithTokens(tokens.ToArray());
        }

        public Index<RuleToken> ExpandMacros(Index<RuleToken> src)
        {
            var dst = list<RuleToken>();
            var assign = span<FieldAssign>(12);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var token = ref src[i];
                var count = expand(token, assign);
                if(count > 0)
                {
                    for(var j=0; j<count; j++)
                        dst.Add(new RuleToken(skip(assign,j)));
                }
                else
                    dst.Add(token);
            }
            return dst.ToArray();
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
                src[i] = input.WithPattern(ExpandMacros(lu, input.Expression));
            }
        }

        static string ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, string src)
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
                        seek(output,i) = specs[sym.Kind].Format();
                    else
                        seek(output,i) = part;
                }
                else
                    seek(output,i) = part;
            }
            return output.Delimit(Chars.Space).Format();
        }

        static void ExpandMacros(Index<RuleTermTable> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var table = ref src[i];
                ExpandMacros(MacroLookup, ref table);
            }
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, Index<RulePatternInfo> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref var pattern = ref src[i];
                ExpandMacros(MacroLookup, ref pattern);
            }
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleTermTable src)
        {
            ref var expressions = ref src.Expressions;
            var count = expressions.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref expressions[i]);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleTermExpr src)
        {
            ExpandMacros(specs, src.Premise);
            ExpandMacros(specs, src.Consequent);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, Index<RuleTerm> src)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
                ExpandMacros(specs, ref src[i]);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RulePatternInfo src)
        {
            src.Expression = ExpandMacros(specs,src.Expression);
        }

        static void ExpandMacros(ConstLookup<RuleMacroKind,MacroSpec> specs, ref RuleTerm src)
        {
            if(MacroKinds.Lookup(src.Value, out var name))
                src = src.WithValue(specs[name].Assignments.Format());
        }
    }
}