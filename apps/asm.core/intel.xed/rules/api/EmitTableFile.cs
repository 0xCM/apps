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
        void EmitTableFiles(RuleTableKind kind, RuleTableSet tables)
        {
            var defs = tables.Defs[kind];
            iter(defs, def => EmitTableFile(def, tables.Rows(def.Sig)), PllExec);
        }

        public static void EmitTableFile(in RuleTable table, Index<RuleTableRow> src)
        {
            if(src.IsEmpty)
                return;

            ref readonly var sig = ref table.Sig;
            Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];
            CalcRenderWidths(sig, src, widths);
            var path = XedPaths.Service.TableDef(sig);
            var formatter = Tables.formatter<RuleTableRow>(widths);
            using var writer = path.AsciWriter();
            writer.AppendLine(formatter.FormatHeader());
            var count = src.Count;
            for(var i=0; i<count; i++)
                writer.AppendLine(formatter.Format(src[i]));

            writer.AppendLine();

            var desc = table.Format().Lines(trim:false);
            for(var i=0; i<desc.Length; i++)
                writer.AppendLineFormat("# {0}", skip(desc,i).Content);
        }
    }
}