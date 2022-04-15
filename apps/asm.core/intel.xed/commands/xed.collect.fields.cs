//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/collect/fields")]
        Outcome XedDisasmFields(CmdArgs args)
        {
            this.Client<DisasmFields>(Context()).EmitFields();
            return true;
        }
    }
}