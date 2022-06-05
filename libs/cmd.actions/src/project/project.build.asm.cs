//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/build/asm")]
        Outcome BuildMc(CmdArgs args)
            => ProjectSvc.BuildAsm(Project());
    }
}