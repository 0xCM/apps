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

        FS.FolderPath AdminDir()
            => Root + FS.folder(admin);

        FS.Files AdminFiles(FS.FileExt ext)
            => AdminDir().Files(ext);

        FS.FolderPath SrcDir()
            => Root + FS.folder(src);

        FS.FolderPath SrcDir(string scope)
            => SrcDir() + FS.folder(scope);

        FS.FolderPath OutDir()
            => Root + FS.folder(output);

        FS.FolderPath OutDir(string scope)
            => OutDir() + FS.folder(scope);

        FS.FolderPath ScriptDir()
            => Root + FS.folder(scripts);

        FS.FolderPath ObjSymDir()
            => OutDir() + FS.folder(sym);

        FS.FilePath Script(string id)
            => ScriptDir() + FS.file(id,FS.Cmd);

        FS.FolderPath Bin()
            => OutDir() + FS.folder(bin);

        FS.FilePath BinPath(string id)
            => Bin() + FS.file(id, FS.Bin);

        FS.FolderPath ExeOut()
            => OutDir() + FS.folder(exe);

        FS.FilePath ExePath(string tool)
            => ExeOut() + FS.file(tool,FS.Exe);

        FS.FolderPath Settings()
            => Root + FS.folder(settings);

        FS.FilePath Settings(string tool, FS.FileExt ext)
            => Settings() + FS.file(tool, ext);

        FS.FolderPath ToolHome(string tool)
            => Root + FS.folder(tool);

        FS.FolderPath ToolDocs(string tool)
            => ToolHome(tool) + FS.folder(docs);

        FS.FolderPath Logs(string tool)
            => ToolHome(tool) + FS.folder(logs);

        FS.FolderPath Scripts(string id)
            => ToolHome(id) + FS.folder(scripts);

        FS.FilePath Script(string tool, string id)
            => Scripts(tool) + FS.file(id,FS.Cmd);

        FS.FilePath ConfigScript(string tool)
            => ToolHome(tool) + FS.file(config, FS.Cmd);

        FS.FilePath ConfigLog(ToolIdOld id)
            => Logs(id) + FS.file(config, FS.Log);
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