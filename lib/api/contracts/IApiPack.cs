//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public interface IApiPack : IFileArchive
    {
        Timestamp Timestamp {get;}

        ApiExtractSettings ExtractSettings {get;}

        ApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FS.FolderPath ParsedExtractRoot()
            => Root + FS.folder("parsed");

        FS.FilePath ParsedExtractPath(FS.FileName name)
            => ParsedExtractRoot() + name;

        FS.FilePath ProcDumpPath(Process process, Timestamp ts)
            => Archive().ProcDumpPath(process, ts);
    }
}