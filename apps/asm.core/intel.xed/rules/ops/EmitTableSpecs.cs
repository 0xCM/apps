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

        void EmitTableSpecs(RuleTableSet tables)
        {
            exec(PllExec,
                () => EmitTableSpecs(tables, RuleTableKind.Enc),
                () => EmitTableSpecs(tables, RuleTableKind.Dec)
                );
        }

        public void EmitTableFiles(RuleTableSet tables)
        {
            exec(PllExec,
                () => EmitTableFiles(tables,RuleTableKind.Enc),
                () => EmitTableFiles(tables, RuleTableKind.Dec)
            );
        }

        void EmitTableFiles(RuleTableSet tables, RuleTableKind kind)
            => iter(tables.Specs[kind], spec => EmitTableFile(spec, XedPaths.Service.TableDef(spec.Sig)), PllExec);

        static uint EmitTableFile(in RuleTableSpec spec, FS.FilePath dst)
        {
            var counter = 0u;
            if(dst.Exists)
                dst = dst.ChangeExtension(FS.ext(string.Format("2.{0}", dst.Ext)));

            using var writer = dst.Writer();
            writer.AppendLine(SpecHeader);
            var buffer = text.buffer();
            RenderSpec(spec, buffer);
            writer.Append(buffer.Emit());
            return counter;
        }

        const string SpecRender = "{0,-8} | {1,-32} | {2,-8} | {3,-22} | {4,-8} | {5,-8} | {6,-28} | {7,-28} | {8}";

        static string SpecHeader = string.Format(SpecRender, "Kind", "TableName", "Row",  "ColKind", "Logic", "Col", "Field", "Value", "Expression");

        static string FormatSpecRow(uint row, byte col, RuleSig table, RuleCell cell)
        {
            var result = XedRules.split(cell, out RuleCellKind cellkind, out var value);
            var op = ruleop(cellkind);
            return string.Format(SpecRender,
                table.TableKind,
                table,
                row,
                XedRender.format(cellkind),
                cell.Premise ? 'P' : 'C',
                col,
                cell.Field == 0 ? EmptyString : XedRender.format(cell.Field),
                value,
                op == 0 ? value : string.Format("{0}{1}{2}", XedRender.format(cell.Field), XedRender.format(op), value)
                );
        }

        static uint RenderStatements(in RuleTableSpec spec, ITextBuffer dst)
        {
            var counter = 0u;
            var statements = spec.Statements;
            for(var j=0u; j<statements.Count; j++)
            {
                ref readonly var statement = ref statements[j];
                byte col = 0;
                for(byte q=0; q<statement.Premise.Count; q++, counter++)
                    dst.AppendLine(FormatSpecRow(j, col++, spec.Sig, statement.Premise[q]));

                for(byte q=0; q<statement.Consequent.Count; q++, counter++)
                    dst.AppendLine(FormatSpecRow(j, col++, spec.Sig, statement.Consequent[q]));
            }
            return counter;
        }

        static uint RenderDescription(in RuleTableSpec spec, ITextBuffer dst)
        {
            var counter = 0u;
            foreach(var line in spec.Format().Lines(trim:false))
            {
                dst.AppendLineFormat("# {0}", line.Content);
                counter++;
            }
            return counter;
        }

        static uint RenderSpec(in RuleTableSpec spec, ITextBuffer dst)
        {
            var counter=0u;
            counter += RenderStatements(spec, dst);
            dst.AppendLine();
            counter += RenderDescription(spec, dst);
            return counter;
        }

        void EmitTableSpecs(RuleTableSet tables, RuleTableKind kind)
        {
            var specs = tables.Specs[kind];
            var path = XedPaths.RuleSpecs(kind);
            using var dst = path.Writer();
            dst.WriteLine(SpecHeader);
            var emitting = EmittingFile(path);
            var counter = 0u;
            var buffer = text.buffer();
            for(var i=0; i<specs.Count; i++)
            {
                dst.AppendLine();
                RenderSpec(specs[i],buffer);
                dst.Write(buffer.Emit());
            }

            EmittedFile(emitting,counter);
        }
    }
}