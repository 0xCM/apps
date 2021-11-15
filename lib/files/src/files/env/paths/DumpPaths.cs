//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EnvFolders;

    using System.Diagnostics;

    partial interface IEnvPaths
    {
        DumpArchive DumpArchive()
            => new DumpArchive(DumpRoot());

        DumpArchive DumpArchive(FS.FolderPath root)
            => new DumpArchive(root);

        DumpPaths DumpPaths()
            => new DumpPaths(DumpRoot(), DbTableRoot() + FS.folder("dumps.tables"));

        FS.FilePath DumpPath(string id)
            => DumpArchive().DumpPath(id);

        FS.FilePath DumpPath(Process process, Timestamp ts)
            => DumpArchive().DumpPath(process,ts);

        FS.FilePath DumpPath(FS.FolderPath dst, Process process, Timestamp ts)
            => DumpArchive(dst).DumpPath(process,ts);

        DumpArchive RefImageDumps()
            => DumpArchive(CacheRoot() + FS.folder(dumps) + FS.folder(images));

        DumpArchive DotNetImageDumps()
            => DumpArchive(RefImageDumps().DumpRoot() + FS.folder(dotnet));
    }
}