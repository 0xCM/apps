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
        public RuleTables CalcRules()
        {
            var tables = new RuleTables();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => buffers.Defs.TryAdd(RuleTableKind.Enc, CalcTableDefs(RuleTableKind.Enc)),
                () => buffers.Defs.TryAdd(RuleTableKind.Dec, CalcTableDefs(RuleTableKind.Dec)),
                () => buffers.Specs.TryAdd(RuleTableKind.Enc, CalcTableSpecs(RuleTableKind.Enc)),
                () => buffers.Specs.TryAdd(RuleTableKind.Dec, CalcTableSpecs(RuleTableKind.Dec))
                );

            exec(PllExec,
                () => buffers.Sigs = CalcSigRows(buffers.Defs),
                () => buffers.Schema = CalcSchemas(buffers.Defs)
                );

            return tables.Seal(buffers,PllExec);
        }
    }
}