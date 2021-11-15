//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using Z0.Asm;

    partial class Nasm
    {
        public Index<AssembledAsm> LoadAssembledAsm(FS.FolderPath src, Identifier listname)
            => Assembled(LoadListedBlocks(ListPath(src, listname)));
    }
}