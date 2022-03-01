//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public Index<RuleFieldSpec> CalcRuleFields()
            => RuleState.specs();

        public void EmitRuleFields()
            => TableEmit(CalcRuleFields().View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());

        public Index<MacroAssignment> CalcMacroAssignments()
        {
            var macros = RuleMacros.discover();
            var count = macros.Length;
            var buffer = alloc<MacroAssignment>(count);

            for(var i=0; i<count; i++)
            {
                ref readonly var m = ref macros[i];
                var assignments = m.Assignments;
                var j=0;
                var k = m.Assignments.Count;
                ref var dst = ref seek(buffer,i);
                dst.MacroName = m.Name;
                if(k >= 1)
                    dst.A0 = assignments[j++];
                if(k >= 2)
                    dst.A1 = assignments[j++];
                if(k >= 3)
                    dst.A2 = assignments[j++];
                if(k >= 4)
                    dst.A3 = assignments[j++];
                if(k >= 5)
                    dst.A4 = assignments[j++];
            }

            return buffer;
        }

        void EmitMacroAssignments()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, AppDb.XedPath("xed.rules.macros", FileKind.Csv));

        public void ExpandMacros(RuleSet src)
        {
            var specs = RuleMacros.discover().Storage.Map(x => (x.Name, x)).ToDictionary();
            ExpandMacros(specs, src.Tables);
            ExpandMacros(specs, src.Patterns);
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

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref XedRuleExpr src)
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
            var input = text.trim(text.split(text.despace(src.Expression.Format()), Chars.Space));
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
            src.Expression = output.Delimit(Chars.Space).Format();
        }

        void ExpandMacros(ConstLookup<RuleMacroName,MacroSpec> specs, ref RuleCriterion src)
        {
            if(MacroNames.Lookup(src.Value, out var name))
                src.Value = specs[name].Assignments.Format();
        }
    }
}