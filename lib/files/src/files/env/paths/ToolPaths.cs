//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath ControlRoot()
            => Env.Control;

        FS.FolderPath Tools()
            => Env.ToolWs;

        FS.FolderPath ToolDataRoot()
            => DbRoot() + FS.folder(tools);

        FS.FolderPath ToolScripts(ToolId tool)
            => Tools() + FS.folder(tool.Format()) + FS.folder(scripts);

        FS.FolderPath ToolOutDir(ToolId tool)
            => ToolDataRoot() + FS.folder(tool.Format()) + FS.folder(output);

        FS.FilePath ToolScript(ToolId tool, ScriptId script, FS.FileExt? ext = null)
            => ToolScripts(tool) + FS.file(script.Format(), ext ?? FS.Cmd);
    }
}