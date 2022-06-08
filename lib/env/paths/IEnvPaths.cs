//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial interface IEnvPaths : ITablePaths
    {
        EnvData Env {get;}

        FS.FolderName PartFolder(PartId part)
            => FS.folder(part.Format());

        FS.FilePath ControlScript(FS.FileName src)
            => Env.Control + FS.folder(".cmd") + src;

        string AppName
            => Assembly.GetEntryAssembly().GetSimpleName();
    }
}