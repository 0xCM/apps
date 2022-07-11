//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    partial interface IEnvPaths
    {
        FS.FolderPath RawExtractRoot()
            => Env.Db + FS.folder(capture) + FS.folder(extracts);

        FS.Files RawExtractPaths()
            => RawExtractRoot().TopFiles;

        FS.FilePath RawExtractPath(FS.FolderPath root, ApiHostUri host)
            => root + PartFolder(host.Part) + HostFile(host, FS.XCsv);
    }
}