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
            => FS.file(ProcDumpName.create(process,Timestamp).Format(), FS.Dmp);

        FS.FilePath ProcDumpPath(Process process)
            => Root + DumpFile(process);

        IImmArchive ImmArchive()
            => new ImmArchive(Root + FS.folder("imm"));

        FS.FilePath Path(PartId part, FileKind kind)
            => Extracts().Path(FS.file(part.Format(), kind.Ext()));

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

        FS.FileName ProcessPartitionHashFile(string process, Identifier subject)
            => FS.file(string.Format("{0}.{1}.{2}.hashes", "image.process.partitions", process, Timestamp.Format()), FS.Csv);

        FS.FilePath ProcessPartitionHashPath(string process, Identifier subject)
            => Root + ProcessPartitionHashFile(process, subject);

        FS.FileName ProcessPartitionFile(Process process)
            => FS.file(string.Format("{0}.{1}.{2}", "image.process.partitions", process.ProcessName, Timestamp.Format()), FS.Csv);

        FS.FilePath ProcessPartitionPath(Process process)
            => Root + ProcessPartitionFile(process);

        FS.FilePath ProcessPartitionPath(FS.FolderPath dir, Process process)
            => dir + ProcessPartitionFile(process);

        FS.FileName MemoryRegionHashFile(string process, Identifier subject)
            => FS.file(string.Format("memory.hash.detail.{0}.{1}", process, Timestamp.Format()), FS.Csv);

        FS.FileName MemoryRegionFile(Process process)
            => FS.file(string.Format("{0}.{1}.{2}", "image.memory.regions", process.ProcessName, Timestamp.Format()), FS.Csv);

        FS.FilePath MemoryRegionPath(Process process)
            => Root + MemoryRegionFile(process);

        FS.FilePath MemoryRegionPath(Process process, FS.FolderPath dir)
            => dir + MemoryRegionFile(process);

        FS.FilePath MemoryRegionHashPath(string process, Identifier subject)
            => Root + MemoryRegionHashFile(process, subject);

    }
}