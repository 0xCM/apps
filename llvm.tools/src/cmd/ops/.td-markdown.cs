//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmCmd
    {
       FS.Files TdFiles()
            => FileArchives.filtered(LlvmPaths.LlvmRoot, FS.ext("td")).Files().Array();

        FS.FilePath EmitTdLinks()
        {
            var dst = LlvmPaths.TmpFile("tablegen-defs", FS.Md);
            using var writer = dst.AsciWriter();
            iter(TdFiles(), f => writer.WriteLine(f.ToUri().MarkdownBullet()));
            return dst;
        }

        [CmdOp(".td-markdown")]
        Outcome TdMd(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = EmitTdLinks();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                Write(line.Format());
            }
            return result;
        }
    }
}