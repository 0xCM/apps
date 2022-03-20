//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/collect")]
        Outcome XedCollect(CmdArgs args)
        {
            XedDisasmSvc.CollectDisasm(Projects.Context(Project()));
            return true;
        }
    }
}