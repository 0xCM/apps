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
            => new DumpArchive(FS.dir("j:/dumps"));

        DumpArchive DumpArchive(FS.FolderPath root)
            => new DumpArchive(root);

        DumpPaths DumpPaths()
            => new DumpPaths(FS.dir("j:/dumps"), Env.Db + FS.folder(tables) + FS.folder("dumps.tables"));

        FS.FilePath DumpPath(string id)
            => DumpArchive(FS.dir("j:/dumps")).DumpPath(id);

        FS.FilePath DumpPath(Process process, Timestamp ts)
            => DumpArchive(FS.dir("j:/dumps")).DumpPath(process,ts);

        FS.FilePath DumpPath(FS.FolderPath dst, Process process, Timestamp ts)
            => DumpArchive(dst).DumpPath(process,ts);

        DumpArchive RefImageDumps()
            => DumpArchive(Env.CacheRoot + FS.folder(dumps) + FS.folder(images));

        DumpArchive DotNetImageDumps()
            => DumpArchive(RefImageDumps().DumpRoot() + FS.folder(dotnet));
    }
}