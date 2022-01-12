//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("sdm/import")]
        Outcome runsdmetl(CmdArgs args)
            => Sdm.Import();
    }
}