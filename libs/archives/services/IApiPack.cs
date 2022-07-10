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
            => Extracts().Path(FS.file(part.Format(), kind));

        IDbTargets Extracts()
            => Targets("extracts");

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

        FS.FileName RegionHashFile(Process process)
            => FS.file(string.Format("{0}.{1}", "process.partitions.hash", process.ProcessName), FileKind.Csv);

        FS.FileName PartitionFile(Process process)
            => FS.file(string.Format("{0}.{1}", "process.partitions", process.ProcessName), FileKind.Csv);

        FS.FileName RegionFile(Process process)
            => FS.file(string.Format("{0}.{1}", "memory.regions", process.ProcessName), FileKind.Csv);

        FS.FilePath PartitionPath(Process process)
            => Targets().Path(PartitionFile(process));

        FS.FilePath RegionPath(Process process)
            => Targets().Path(RegionFile(process));

        FS.FilePath RegionHashPath(Process process)
            => Targets().Path(RegionHashFile(process));

        FS.FilePath PartitionHashPath(Process process)
            => Targets().Path(RegionHashFile(process));
    }
}