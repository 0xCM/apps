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

        public static Outcome split(RuleCell src, out RuleCellKind kind, out string value)
        {
            var result = Outcome.Success;
            var data = src.Data;
            value = data;
            kind = RuleCellKind.None;
            var left = EmptyString;
            if(src.Premise)
            {
                if(XedParsers.IsCmpNeq(data))
                {
                    kind = RuleCellKind.CmpNeq;
                    XedParsers.CmpNeq(data, out left, out value);
                }
                else if (text.contains(data, Chars.Eq))
                {
                    kind = RuleCellKind.CmpEq;
                    XedParsers.Assignment(data, out left, out value);
                }
                else
                    kind = RuleCellKind.Literal;
            }
            else
            {
                if(XedParsers.IsAssignment(data))
                {
                    kind = RuleCellKind.Assignment;
                    XedParsers.Assignment(data, out left, out value);
                }
                else if(XedParsers.IsCmpNeq(data))
                {
                    kind = RuleCellKind.CmpNeq;
                    XedParsers.CmpNeq(data, out left, out value);
                }
                else
                    kind = RuleCellKind.Literal;
            }

            if(XedParsers.IsBfSeg(data))
                kind |= RuleCellKind.BfSeg;
            if(XedParsers.IsNonterminal(value))
                kind |= RuleCellKind.Nonterminal;

            if(XedParsers.IsBinaryLiteral(value))
                kind |= RuleCellKind.Bits;
            else if(XedParsers.IsHexLiteral(value))
                kind |= RuleCellKind.Hex;
            else if(XedParsers.IsIntLiteral(value))
                kind |= RuleCellKind.Int;

            if(src.Field != 0)
                kind |= RuleCellKind.FieldValue;

            return result;
        }

        void EmitRuleSpecs(RuleTableKind kind,Index<RuleTableSpec> specs)
        {
            const string RenderPattern = "{0,-8} | {1,-32} | {2,-8} | {3,-22} | {4,-8} | {5,-8} | {6,-28} | {7,-28} | {8}";

            static string describe(uint row, byte col, RuleSig table, RuleCell cell)
            {
                var result = XedRules.split(cell, out var kind, out var value);
                var op = ruleop(kind);

                return string.Format(RenderPattern,
                    table.TableKind,
                    table,
                    row,
                    XedRender.format(kind),
                    cell.Premise ? 'P' : 'C',
                    col,
                    cell.Field == 0 ? EmptyString : XedRender.format(cell.Field),
                    value,
                    op == 0 ? value : string.Format("{0}{1}{2}", XedRender.format(cell.Field), XedRender.format(op), value)
                    );
            }

            var header = string.Format(RenderPattern, "Kind", "TableName", "Row",  "ColKind", "Logic", "Col", "Field", "Value", "Expression");
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
                for(var j=0u; j<statements.Count; j++)
                {
                    ref readonly var s = ref statements[j];

                    byte col = 0;
                    for(byte q=0; q<s.Premise.Count; q++, counter++)
                        writer.AppendLine(describe(j, col++, spec.Sig, s.Premise[q]));

                    for(byte q=0; q<s.Consequent.Count; q++, counter++)
                        writer.AppendLine(describe(j, col++, spec.Sig, s.Consequent[q]));
                }
            }

            EmittedFile(emitting,counter);
        }

        void EmitSpecs(RuleTableKind kind)
            => EmitRuleSpecs(kind, RuleTables.CalcRuleSpecs(kind));
    }
}