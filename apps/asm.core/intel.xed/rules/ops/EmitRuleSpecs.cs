//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
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
    }
}