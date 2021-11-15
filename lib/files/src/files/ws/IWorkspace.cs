//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IWorkspace : IFileArchive
    {
        Identifier Name {get;}

        FS.FolderPath AdminDir()
            => Root + FS.folder(admin);

        FS.Files AdminFiles(FS.FileExt ext)
            => AdminDir().Files(ext);

        FS.FolderPath SrcDir()
            => Root + FS.folder(src);

        FS.FolderPath SrcDir(Subject scope)
            => SrcDir() + FS.folder(scope.Format());

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

        FS.FilePath ExePath(string id)
            => ExeOut() + FS.file(id,FS.Exe);

        FS.FolderPath Settings()
            => Root + FS.folder(settings);

        FS.FilePath Settings(string id, FS.FileExt ext)
            => Settings() + FS.file(id, ext);

        FS.FolderPath ToolHome(ToolId id)
            => Root + FS.folder(id.Format());

        FS.FolderPath ToolDocs(ToolId id)
            => ToolHome(id) + FS.folder(docs);

        FS.FolderPath Logs(ToolId id)
            => ToolHome(id) + FS.folder(logs);

        FS.FolderPath Scripts(ToolId id)
            => ToolHome(id) + FS.folder(scripts);

        FS.FilePath Script(ToolId tool, string id)
            => Scripts(tool) + FS.file(id,FS.Cmd);

        FS.FilePath ConfigScript(ToolId id)
            => ToolHome(id) + FS.file(config, FS.Cmd);

        FS.FilePath ConfigLog(ToolId id)
            => Logs(id) + FS.file(config, FS.Log);
    }

    public interface IWorkspace<T> : IWorkspace
        where T : IWorkspace<T>
    {
        FS.FolderPath WsRoot()
            => Root;

        Identifier IWorkspace.Name
            => WsRoot().FolderName.Format();
    }
}