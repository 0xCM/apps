//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        // public static void exec(bool pll, params Action[] src)
        //     => iter(src, a => a(), pll);

        public void EmitCatalog()
        {
            var defs = CalcInstDefs();
            var patterns = CalcInstPatterns(defs);
            exec(PllWf,
                () => EmitPatternData(patterns),
                EmitRuleTables,
                EmitFieldDefs,
                EmitOperandWidths,
                EmitPointerWidths,
                EmitOpCodeKinds,
                EmitMacroDefs,
                EmitReflectedFields
                );
        }
    }
}