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
            => CaptureRoot() + FS.folder(extracts);

        FS.Files RawExtractPaths()
            => RawExtractRoot().TopFiles;

        FS.FilePath RawExtractPath(FS.FileName name)
            => RawExtractRoot() + name;

        FS.FilePath RawExtractPath(FS.FolderPath root, ApiHostUri host)
            => root + PartFolder(host.Part) + HostFile(host, FS.XCsv);

        FS.FilePath RawExtractPath(ApiHostUri host)
            => RawExtractPath(HostFile(host, FS.XCsv));

        FS.Files RawExtractFiles(PartId part)
            => RawExtractPaths().Where(f => f.IsOwner(part));
    }
}