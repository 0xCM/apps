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

        FS.FolderPath Codebase(PartId part)
            => Env.ZDev + FS.folder("src") + PartFolder(part);

        FS.FilePath ControlScript(FS.FileName src)
            => ControlScripts() + src;

        FS.FolderName SubjectFolder<S>(S src)
            => FS.folder(src.ToString().ToLowerInvariant());

        string AppName
            => Assembly.GetEntryAssembly().GetSimpleName();
    }
}