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
        public void EmitTableFiles(RuleTableSet tables)
        {
            exec(PllExec,
                () => EmitTableFiles(RuleTableKind.Enc, tables),
                () => EmitTableFiles(RuleTableKind.Dec, tables)
            );
        }

        void EmitTableFiles(RuleTableKind kind, RuleTableSet tables)
        {
            iter(tables.Specs[kind], spec => EmitTableFile(spec, XedPaths.Service.TableDef(spec.Sig)), PllExec);
        }

        static uint EmitTableFile(in RuleTableSpec spec, FS.FilePath dst)
        {
            var counter = 0u;
            if(dst.Exists)
                dst = dst.ChangeExtension(FS.ext(string.Format("2.{0}", dst.Ext)));

            using var writer = dst.Writer();
            writer.AppendLine(SpecHeader);
            var statements = spec.Statements;
            for(var j=0u; j<statements.Count; j++)
            {
                ref readonly var statement = ref statements[j];
                byte col = 0;
                for(byte q=0; q<statement.Premise.Count; q++, counter++)
                    writer.AppendLine(FormatSpecRow(j, col++, spec.Sig, statement.Premise[q]));

                for(byte q=0; q<statement.Consequent.Count; q++, counter++)
                    writer.AppendLine(FormatSpecRow(j, col++, spec.Sig, statement.Consequent[q]));
            }

            writer.AppendLine();
            foreach(var line in spec.Format().Lines(trim:false))
                writer.AppendLineFormat("# {0}", line.Content);
            return counter;
        }
    }
}