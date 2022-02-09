//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    public class AsmFileGen : AppService<AsmFileGen>
    {
        public void Emit(AsmFileSpec src, ITextBuffer dst)
        {
            if(src.IntelSyntax)
            {
                dst.AppendLine(".intel_syntax noprefix");
                dst.AppendLine();
            }

            foreach(var comment in src.HeaderComments)
                dst.AppendLine(comment.Format());

            var blocks = src.Blocks;
            var count = blocks.Count;
            for(var i=0; i<count; i++)
                dst.Append(blocks[i].Format());
        }

        public FS.FilePath Emit(AsmFileSpec src, FS.FolderPath dst)
        {
            var buffer = text.buffer();
            Emit(src,buffer);

            var path = dst + FS.file(src.Name.Format(), FS.Asm);
            using var writer = path.AsciWriter();
            writer.WriteLine(buffer.Emit());
            return path;
        }
    }
}