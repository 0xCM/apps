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
        public void EmitRuleSpecs()
        {
            exec(true,
                () => EmitSpecs(RuleTableKind.Enc),
                () => EmitSpecs(RuleTableKind.Dec),
                () => EmitSpecs(RuleTableKind.EncDec)
                );
        }

        public Index<RuleTableSpec> CalcRuleSpecs(RuleTableKind kind)
            => RuleTables.CalcRuleSpecs(kind);

        public static Outcome classify(RuleCell src, out RuleCellKind dst)
        {
            var result = Outcome.Success;
            var data = src.Data;
            dst = RuleCellKind.None;
            if(XedParsers.IsAssignment(data))
                dst = RuleCellKind.Assignment;
            else if(XedParsers.IsCmpNeq(data))
                dst = RuleCellKind.Constraint;
            else
                dst = RuleCellKind.Literal;

            if(dst != RuleCellKind.Literal)
            {
                var left = EmptyString;
                var right = EmptyString;
                var field = FieldKind.INVALID;
                var op = RuleOperator.None;
                if(XedParsers.Assignment(data, out left, out right))
                {
                    op = RuleOperator.Assign;
                    if(dst != RuleCellKind.Assignment)
                        result = (false, string.Format("Cell assignment mismatch:'{0}' ", data));
                }
                else if(XedParsers.CmpNeq(data, out left, out right))
                {
                    op = RuleOperator.CmpNeq;
                    if(dst != RuleCellKind.Constraint)
                        result = (false, string.Format("Cell constraint mismatch:'{0}' ", data));
                }

                if(text.empty(left) || text.empty(right))
                    result = (false, string.Format("Cell classification failed:'{0}' ", data));

                var j = text.index(left,Chars.LBracket);

                XedParsers.parse(j>0 ? text.left(left,j) : left, out field);
                if(field != src.Field)
                    result = (false, string.Format("Cell kind mismatch:{0}!={1}", field, src.Field, data));

                if(XedParsers.IsNonterminal(right))
                    dst |= RuleCellKind.Nonterminal;
                else
                    dst |= RuleCellKind.Literal;
            }
            else
            {
                if(XedParsers.IsBfSeg(data))
                    dst = RuleCellKind.BfSeg;
            }

            return result;
        }

        void EmitRuleSpecs(RuleTableKind kind,Index<RuleTableSpec> specs)
        {
            const string RenderPattern = "{0,-32} | {1,-22} | {2,-16} | {3,-36} | {4}";

            static string describe(RuleSig table, RuleCell cell)
            {
                var result = XedRules.classify(cell, out var cellKind);
                return string.Format(RenderPattern,
                    table,
                    cell.Field == 0 ? EmptyString : XedRender.format(cell.Field),
                    XedRender.format(cellKind),
                    cell,
                    result.Fail ?  $"Error: {result.Message}" : EmptyString
                    );
            }

            var header = string.Format(RenderPattern,"Table", "Field", "Kind", "Value", "Errors");
            var path = XedPaths.RuleSpecs(kind);
            using var writer = path.Writer();
            writer.WriteLine(header);
            var emitting = EmittingFile(path);
            var counter = 0u;
            for(var i=0; i<specs.Count; i++)
            {
                ref readonly var spec = ref specs[i];

                writer.AppendLine();
                foreach(var line in spec.Format().Lines(trim:false))
                    writer.AppendLineFormat("# {0}", line.Content);
                writer.AppendLine();

                var statements = spec.Statements;
                for(var j=0; j<statements.Count; j++)
                {
                    ref readonly var s = ref statements[j];

                    for(var q=0; q<s.Premise.Count; q++, counter++)
                        writer.AppendLine(describe(spec.Sig, s.Premise[q]));

                    for(var q=0; q<s.Consequent.Count; q++, counter++)
                        writer.AppendLine(describe(spec.Sig, s.Consequent[q]));
                }
            }

            EmittedFile(emitting,counter);
        }

        void EmitSpecs(RuleTableKind kind)
            => EmitRuleSpecs(kind, RuleTables.CalcRuleSpecs(kind));
    }
}