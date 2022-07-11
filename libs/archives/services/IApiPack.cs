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

        IImmArchive ImmArchive()
            => new ImmArchive(Root + FS.folder("imm"));

        IDbTargets ProcessContext()
            => Targets("context");

        IDbTargets Extracts()
            => Targets("extracts");

        IDbTargets Metadata()
            => Targets("metadata");

        FS.FilePath IlPath(ApiHostUri host)
            => Extracts().Path(FS.hostfile(host,FileKind.Msil.Ext()));

        IDbTargets Metadata(string scope)
            => Metadata().Targets(scope);

        FS.FilePath ExtractPath(PartId part, FileKind kind)
            => Extracts().Path(FS.file(part.Format(), kind));

        FS.FilePath ExtractPath(ApiHostUri host, FileKind kind)
            => Extracts().Path(FS.file(host, kind));

        IApiPackArchive Archive()
            => ApiPackArchive.create(Root);

        FS.FilePath HexExtractPath(PartId src)
            => ExtractPath(src, FileKind.HexDat);

        FS.FilePath CsvExtractPath(PartId part)
            => ExtractPath(part, FileKind.Csv);

        FS.FilePath AsmExtractPath(PartId part)
            => ExtractPath(part, FileKind.Asm);

        FS.FilePath HexExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.HexDat);

        FS.FilePath CsvExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Csv);

        FS.FilePath AsmExtractPath(ApiHostUri src)
            => ExtractPath(src, FileKind.Asm);

        FS.FileName RegionFile()
            => FS.file("memory.regions", FileKind.Csv);

        FS.FileName RegionHashFile()
            => FS.file("memory.regions.hash", FileKind.Csv);

        FS.FileName PartitionFile()
            => FS.file("process.partitions", FileKind.Csv);

        FS.FileName PartitionHashFile()
            => FS.file("process.partitions.hash", FileKind.Csv);

        FS.FilePath PartitionPath()
            => ProcessContext().Path(PartitionFile());

        FS.FilePath RegionPath()
            => ProcessContext().Path(RegionFile());

        FS.FilePath RegionHashPath()
            => ProcessContext().Path(RegionHashFile());

        FS.FilePath PartitionHashPath()
            => ProcessContext().Path(PartitionHashFile());

        FS.FilePath ProcessModules()
            => ProcessContext().Path("process.modules", FileKind.Csv);

        FS.FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(false), FileKind.Dmp);

        FS.FilePath DumpPath(Process process)
            => ProcessContext().Path(DumpFile(process)).CreateParentIfMissing();
    }
}