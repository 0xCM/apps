//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/build/asm")]
        Outcome BuildMc(CmdArgs args)
            => ProjectData.BuildAsm(Project());
   }
}