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
        public RuleTableSet CalcTableSet()
        {
            var tables = new RuleTableSet();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => CalcDefCells(RuleTableKind.Enc),
                () => CalcDefCells(RuleTableKind.Dec),
                () => buffers.Specs.TryAdd(RuleTableKind.Enc, CalcTableSpecs(RuleTableKind.Enc)),
                () => buffers.Specs.TryAdd(RuleTableKind.Dec, CalcTableSpecs(RuleTableKind.Dec))
                );

            exec(PllExec,
                () => buffers.Sigs = XedRules.CalcSigRows(buffers.Cells.Keys.Array()),
                () => buffers.Schema = XedRules.CalcSchemas(buffers.Cells)
                );

            var result = tables.Seal(buffers);
            return result;

            void CalcDefCells(RuleTableKind kind)
            {
                var defs = XedRules.CalcTableDefs(kind);
                buffers.Defs.TryAdd(kind, defs);
                iter(defs, def => buffers.Rows.TryAdd(def.Sig, XedRules.CalcCells(def, buffers.Cells)), PllExec);
            }
        }
    }
}