//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IWorkspace : IFileArchive
    {
        string Name {get;}

        FS.FolderPath IFileArchive.Datasets()
            => Root + FS.folder("db");

        FS.FolderPath IFileArchive.Datasets(string scope)
            => Datasets() + FS.folder(scope);

        FS.FolderPath SrcDir()
            => Root + FS.folder(src);

        FS.FolderPath SrcDir(string scope)
            => SrcDir() + FS.folder(scope);

        FS.FolderPath BuildOut()
            => Root + FS.folder(".out");

        FS.FolderPath BuildOut(string scope)
            => BuildOut() + FS.folder(scope);

        FS.FolderPath ScriptDir()
            => Root + FS.folder(scripts);

        FS.FilePath Script(string name)
            => ScriptDir() + FS.file(name, FS.Cmd);
    }

    public interface IWorkspace<T> : IWorkspace
        where T : IWorkspace<T>
    {
        FS.FolderPath WsRoot()
            => Root;

        string IWorkspace.Name
            => WsRoot().FolderName.Format();
    }
}