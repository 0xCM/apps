//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectSvc
    {
        public McAsmDoc CalcMcAsmDoc(in FileRef src)
            => new LlvmAsmParser().ParseMcAsmDoc(src);

        public Index<McAsmDoc> CalcMcAsmDocs(IProjectWs src)
        {
            var files = WsCatalog.load(src).Entries(FileKind.McAsm);
            var count = files.Count;
            var dst = alloc<McAsmDoc>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = CalcMcAsmDoc(files[i]);
            return dst;
        }
    }
}