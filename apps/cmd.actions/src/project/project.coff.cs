//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
       [CmdOp("project/coff")]
        Outcome Blah(CmdArgs args)
        {
            var project = Project();
            var blocks = ProjectData.LoadObjBlocks(project);
            iter(blocks, block => Write(string.Format("'{0}'", block.BlockName)));
            return true;
        }
    }
}