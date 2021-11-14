//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".td-symlinks")]
        Outcome TdRel(CmdArgs args)
        {
            var result = Outcome.Success;
            var sources = TdFiles().View;
            var count = sources.Length;
            var view = LlvmPaths.LlvmSourceView();
            for(var i=0; i<count; i++)
            {
                ref readonly var srcpath = ref skip(sources,i);
                var relative = srcpath.Relative(LlvmPaths.LlvmRoot);
                var linkpath = view + relative;
                var link = FS.symlink(linkpath, srcpath, true);
                link.OnFailure(Error).OnSuccess(Write);
            }

            return result;
        }
    }
}