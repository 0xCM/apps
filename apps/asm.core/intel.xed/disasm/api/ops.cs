//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        public static Dictionary<OpName,DisasmOp> ops(in RuleState state, in AsmHexCode code)
        {
            var dst = dict<OpName,DisasmOp>();
            iter(XedFields.opvalues(state, code), o => dst.TryAdd(o.Name, new DisasmOp(o.Name, o.Value)));
            return dst;
        }
    }
}