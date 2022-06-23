//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath ToolScripts(ToolId tool)
            => Env.ToolWs + FS.folder(tool.Format()) + FS.folder(scripts);

        FS.FolderPath ToolOutDir(ToolId tool)
            => Env.Db + FS.folder(tools) + FS.folder(tool.Format()) + FS.folder(output);

        FS.FilePath ToolScript(ToolId tool, ScriptId script, FS.FileExt? ext = null)
            => ToolScripts(tool) + FS.file(script.Format(), ext ?? FS.Cmd);
    }
}