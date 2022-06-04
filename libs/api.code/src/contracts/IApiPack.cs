//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public interface IApiPack : IFileArchive
    {
        ApiExtractSettings ExtractSettings {get;}

        Timestamp Timestamp
            => ExtractSettings.Timestamp;

        FS.FilePath ProcDumpPath(Process process, Timestamp ts);

        IApiPackArchive Archive()
            => ApiPackArchive.create(ExtractSettings.ExtractRoot);

        FS.FilePath PartCsv(PartId part)
            => Archive().PartCsv(part);

        FS.FilePath PartAsm(PartId part)
            => Archive().PartAsm(part);

        FS.FilePath PartHex(PartId part)
            => Archive().PartHex(part);
    }
}