//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Nasm
    {
        public FS.FilePath ListPath(FS.FolderPath dst, Identifier name)
            => dst + FS.file(name + ".bin", ListingExt);

        public FS.FileExt ListingExt
            => FS.ext("list") + FS.Asm;
    }
}