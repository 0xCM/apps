//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("nasm/emit/catalog")]
        Outcome EmitNasmCatalog(CmdArgs args)
        {
            Service(Wf.NasmCatalog).ImportInstructions();
            return true;
        }
    }
}