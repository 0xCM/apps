//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    public interface IApiPack : IRootedArchive, IExpr
    {
        Timestamp Timestamp {get;}

        string Label {get;}

        bool INullity.IsEmpty
            => Timestamp == 0;

        string IExpr.Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        FS.FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(), FileKind.Dmp);

        IImmArchive ImmArchive()
            => new ImmArchive(Root + FS.folder("imm"));

        FS.FilePath DumpPath(Process process)
            => Targets().Path(DumpFile(process)).CreateParentIfMissing();

        FS.FilePath Path(PartId part, FileKind kind)
            => Targets().Path(FS.file(part.Format(), kind));

        FS.FilePath Path(ApiHostUri host, FileKind kind)
            => Targets().Path(FS.file(host, kind));

        IDbTargets Metadata()
            => Targets("meta");

        IDbTargets Metadata(string scope)
            => Metadata().Targets(scope);

        IApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FS.FilePath HexPath(PartId src)
            => Path(src, FileKind.HexDat);

        FS.FilePath CsvPath(PartId part)
            => Path(part, FileKind.Csv);

        FS.FilePath AsmPath(PartId part)
            => Path(part, FileKind.Asm);

        FS.FilePath HexPath(ApiHostUri src)
            => Path(src, FileKind.HexDat);

        FS.FilePath CsvPath(ApiHostUri src)
            => Path(src, FileKind.Csv);

        FS.FilePath AsmPath(ApiHostUri src)
            => Path(src, FileKind.Asm);

        FS.FileName RegionFile()
            => FS.file("memory.regions", FileKind.Csv);

        FS.FileName RegionHashFile()
            => FS.file("memory.regions.hash", FileKind.Csv);

        FS.FileName PartitionFile()
            => FS.file("process.partitions", FileKind.Csv);

        FS.FileName PartitionHashFile()
            => FS.file("process.partitions.hash", FileKind.Csv);

        FS.FilePath PartitionPath()
            => Targets().Path(PartitionFile());

        FS.FilePath RegionPath()
            => Targets().Path(RegionFile());

        FS.FilePath RegionHashPath()
            => Targets().Path(RegionHashFile());

        FS.FilePath PartitionHashPath()
            => Targets().Path(PartitionHashFile());
    }
}