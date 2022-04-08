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
            XedDisasmSvc.Collect(Projects.Context(Project()));
            return true;
        }

        [CmdOp("xed/disasm/fields")]
        Outcome XedDisasmFields(CmdArgs args)
        {
            XedDisasmSvc.CollectFields(Projects.Context(Project()));
            return true;
        }
    }
}