//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public partial interface IEnvPaths : ITablePaths
    {
        EnvData Env {get;}

        FS.FolderName PartFolder(PartId part)
            => FS.folder(part.Format());

        FS.FilePath ControlScript(FS.FileName src)
            => ControlScripts() + src;

        string AppName
            => Assembly.GetEntryAssembly().GetSimpleName();
    }
}