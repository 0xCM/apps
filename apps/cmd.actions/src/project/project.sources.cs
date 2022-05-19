//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/sources")]
        protected Outcome ProjectSrcFiles(CmdArgs args)
        {
            if(args.Length == 0)
                Files(Project().SrcFiles());
            else
                Files(Project().SrcFiles(arg(args,0)));
            return true;
        }
    }
}