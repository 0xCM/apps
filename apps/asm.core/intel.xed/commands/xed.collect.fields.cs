//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/collect/fields")]
        Outcome XedDisasmFields(CmdArgs args)
        {
            XedDisasmSvc.CollectFields(Projects.Context(Project()));
            return true;
        }
    }
}