//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAppPaths : IFileArchive
    {
        string AppName
            => Assembly.GetEntryAssembly().GetSimpleName();

        /// <summary>
        /// The name of an application configuration file
        /// </summary>
        FS.FileName ConfigFileName
            => FS.file(AppName, FS.JsonConfig);

        /// <summary>
        /// The executing application's configuration file path
        /// </summary>
        FS.FilePath AppConfigPath
            => Root + FS.folder("config") + ConfigFileName;
    }
}