//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;

    public interface IApiPack : IFileArchive
    {
        Timestamp Timestamp {get;}

        ApiExtractSettings ExtractSettings {get;}

        ApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FS.FilePath ProcDumpPath(Process process, Timestamp ts)
            => Archive().ProcDumpPath(process, ts);
    }
}