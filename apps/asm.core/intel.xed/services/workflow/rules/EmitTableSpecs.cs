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

        void EmitTableSpecs(RuleTables tables, RuleTableKind kind)
        {
            var buffer = text.buffer();
            var specs = tables.Specs[kind];
            var path = XedPaths.RuleSpecs(kind);
            buffer.AppendLine(RuleCellRender.SpecHeader);
            RuleCellRender.render(specs, buffer);
            FileEmit(buffer.Emit(), specs.Count, XedPaths.RuleSpecs(kind), TextEncodingKind.Asci);
        }

        static void EmitTableFile(in RuleTableSpec spec, FS.FilePath dst)
        {
            var buffer = text.buffer();
            if(dst.Exists)
                dst = dst.ChangeExtension(FS.ext(string.Format("2.{0}", dst.Ext)));

            buffer.AppendLine(RuleCellRender.SpecHeader);
            RuleCellRender.render(spec, buffer);

            using var writer = dst.AsciWriter();
            writer.Append(buffer.Emit());
        }
    }
}