//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;
    using static FS;

    partial interface IEnvPaths
    {
        FolderPath ParsedExtractRoot()
            => Env.Db + FS.folder(capture) + FS.folder(parsed);

        FS.Files ParsedExtractPaths()
            => ParsedExtractRoot().Files(PCsv);

        FS.FilePath ParsedExtractPath(FS.FileName name)
            => ParsedExtractRoot() + name;

        FS.FilePath ParsedExtractPath(ApiHostUri host)
            => ParsedExtractPath(ApiFiles.filename(host, PCsv));

        FS.FilePath ParsedExtractPath(FS.FolderPath root, ApiHostUri host)
            => root + PartFolder(host.Part) + HostFile(host, PCsv);

        FS.Files ParsedExtractPaths(PartId part)
            => ParsedExtractPaths().Where(f => f.IsOwner(part));
    }
}