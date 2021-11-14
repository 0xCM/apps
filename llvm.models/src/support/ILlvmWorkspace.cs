//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LlvmAtoms;

    public interface ILlvmWorkspace : IWorkspace
    {
        FS.FolderPath BuildRoot {get;}

        FS.FolderPath LibDir()
            => BuildRoot + FS.folder(lib);

        FS.FolderPath IWorkspace.Bin()
            => BuildRoot + FS.folder(bin);

        FS.Files ExeBuilds()
            => Bin().Files(FS.Exe);

        FS.Files LibBuilds()
            => LibDir().Files(FS.Lib);
    }
}