//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("objhex/check")]
        Outcome CheckObjHex(CmdArgs args)
            => CoffServices.CheckObjHex(Project());
    }
}