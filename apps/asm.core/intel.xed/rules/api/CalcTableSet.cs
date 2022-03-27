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
        public static RuleTableSet CalcTableSet(bool pll)
        {
            var tables = new RuleTableSet();
            var buffers = tables.CreateBuffers();
            exec(pll,
                () => CalcDefCells(RuleTableKind.Enc),
                () => CalcDefCells(RuleTableKind.Dec),
                () => CalcDefCells(RuleTableKind.EncDec)
                );

            exec(pll,
                () => buffers.Sigs = XedRules.CalcSigRows(buffers.Cells.Keys.Array().Sort()),
                () => buffers.Schema = XedRules.CalcSchemas(buffers.Cells)
                );

            return tables.Seal(buffers);

            void CalcDefCells(RuleTableKind kind)
            {
                var defs = XedRules.CalcTableDefs(kind);
                buffers.Defs.TryAdd(kind, defs);
                iter(defs, def => buffers.Rows.TryAdd(def.Sig, XedRules.CalcCells(def, buffers.Cells)), pll);
            }
        }
    }
}