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
        void EmitTableSpecs(RuleTables tables)
        {
            exec(PllExec,
                () => EmitTableSpecs(tables, RuleTableKind.Enc),
                () => EmitTableSpecs(tables, RuleTableKind.Dec)
                );
        }

        public void EmitTableFiles(RuleTables tables)
        {
            exec(PllExec,
                () => EmitTableFiles(tables,RuleTableKind.Enc),
                () => EmitTableFiles(tables, RuleTableKind.Dec)
            );
        }

        void EmitTableFiles(RuleTables tables, RuleTableKind kind)
            => iter(tables.Specs[kind], spec => EmitTableFile(spec, XedPaths.Service.TableDef(spec.Sig)), false);

        const string SpecRender = "{0,-8} | {1,-32} | {2,-8} | {3,-8} | {4,-8} | {5,-8} | {6,-28} | {7}";

        static uint render(in RuleTableSpec spec, ITextBuffer dst)
        {
            var counter=0u;
            counter += RenderRows(spec, dst);
            dst.AppendLine();
            counter += RenderContent(spec, dst);
            return counter;

            static string FormatRow(uint row, byte col, RuleSig sig, RuleCell cell)
            {
                var result = split(cell, out RuleCellKind cellkind, out var value);
                return string.Format(SpecRender,
                    sig.TableKind,
                    sig.ShortName,
                    row,
                    format(cellkind),
                    cell.Premise ? 'P' : 'C',
                    col,
                    cellkind == RuleCellKind.BfSeg ? string.Format("{0}[{1}]", XedRender.format(cell.Field), value) : cell.Operator != 0 ? string.Format("{0}{1}{2}", XedRender.format(cell.Field), XedRender.format(cell.Operator), value) : value,
                    cell.Data
                    );
            }

            static uint RenderRows(in RuleTableSpec spec, ITextBuffer dst)
            {
                var counter = 0u;
                var statements = spec.Statements;
                for(var j=0u; j<statements.Count; j++)
                {
                    ref readonly var statement = ref statements[j];
                    byte col = 0;
                    for(byte q=0; q<statement.Premise.Count; q++, counter++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Premise[q]));

                    for(byte q=0; q<statement.Consequent.Count; q++, counter++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Consequent[q]));
                }
                return counter;
            }

            static uint RenderContent(in RuleTableSpec spec, ITextBuffer dst)
            {
                var counter = 0u;
                foreach(var line in spec.Format().Lines(trim:false))
                {
                    dst.AppendLineFormat("# {0}", line.Content);
                    counter++;
                }
                return counter;
            }
        }

        static string SpecHeader = string.Format(SpecRender, "Kind", "TableName", "Row",  "ColKind", "Logic", "Col", "Expr", "SourceExpr");

        static void render(Index<RuleTableSpec> specs, ITextBuffer dst)
        {
            for(var i=0; i<specs.Count; i++)
            {
                dst.AppendLine();
                render(specs[i], dst);
            }
        }

        void EmitTableSpecs(RuleTables tables, RuleTableKind kind)
        {
            var specs = tables.Specs[kind];
            var path = XedPaths.RuleSpecs(kind);
            using var dst = path.Writer();
            dst.WriteLine(SpecHeader);
            var emitting = EmittingFile(path);
            var counter = 0u;
            var buffer = text.buffer();
            render(specs,buffer);
            dst.WriteLine(buffer.Emit());

            EmittedFile(emitting, specs.Count);
        }

        static uint EmitTableFile(in RuleTableSpec spec, FS.FilePath dst)
        {
            var counter = 0u;
            if(dst.Exists)
                dst = dst.ChangeExtension(FS.ext(string.Format("2.{0}", dst.Ext)));

            using var writer = dst.Writer();
            writer.AppendLine(SpecHeader);
            var buffer = text.buffer();
            render(spec, buffer);
            writer.Append(buffer.Emit());
            return counter;
        }
    }
}