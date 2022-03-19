//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasmSvc
    {
        static DisasmOps CalcDisasmOps(in RuleState state, in AsmHexCode code)
        {
            var dst = dict<RuleOpName,DisasmOp>();
            iter(RuleOpValues.calc(state, code).Values, o => dst.TryAdd(o.Name, new DisasmOp(o.Name, o.Value)));
            return dst;
        }
    }
}