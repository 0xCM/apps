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
        static Dictionary<OpName,DisasmOp> CalcDisasmOps(in RuleState state, in AsmHexCode code)
        {
            var dst = dict<OpName,DisasmOp>();
            iter(XedFields.opvalues(state, code), o => dst.TryAdd(o.Name, new DisasmOp(o.Name, o.Value)));
            return dst;
        }
    }
}