//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class XedCmdProvider
    {
        [CmdOp("xed/collect/fields")]
        Outcome XedDisasmFields(CmdArgs args)
        {
            var context = Context();
            XedDisasmSvc.EmitFields(context);
            return true;
        }
    }
}