//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/td/links")]
        void EmitTdSymLinks()
        {
            var sources = TdFiles().View;
            var count = sources.Length;
            var view = Paths.LlvmSourceView();
            for(var i=0; i<count; i++)
            {
                ref readonly var srcpath = ref skip(sources,i);
                var relative = srcpath.Relative(Paths.LlvmRoot);
                var linkpath = view + relative;
                var link = FS.symlink(linkpath, srcpath, true);
                link.OnFailure(Error).OnSuccess(Write);
            }

            var dst = Paths.File("tablegen-defs", FS.Md);
            using var writer = dst.AsciWriter();
            iter(TdFiles(), f => writer.WriteLine(f.ToUri().MarkdownBullet()));
        }
    }
}