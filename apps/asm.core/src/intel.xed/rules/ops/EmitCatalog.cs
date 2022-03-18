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
        public void EmitCatalog()
        {
            var defs = CalcInstDefs();
            var patterns = CalcInstPatterns(defs);
            exec(PllWf,
                () => EmitPatternData(patterns),
                EmitRuleSpecs,
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