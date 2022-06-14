//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiPack : IRootedArchive
    {
        ApiExtractSettings ExtractSettings {get;}

        FS.FilePath ProcDumpPath(Process process, Timestamp ts);

        FS.FolderPath IRootedArchive.Root
            => ExtractSettings.ExtractRoot;

        Timestamp Timestamp
            => ExtractSettings.Timestamp;

        IApiPackArchive Archive()
            => ApiPackArchive.create(ExtractSettings.ExtractRoot);

        FS.FilePath Path(PartId part, FileKind kind)
            => Targets().Path(FS.file(part.Format(), kind.Ext()));

        FS.FilePath Path(ApiHostUri host, FileKind kind)
            => Targets().Path(host.FileName(kind.Ext()));

        FS.FilePath HexPath(PartId src)
            => Path(src, FileKind.HexDat);

        FS.FilePath HexPath(ApiHostUri src)
            => Path(src, FileKind.HexDat);

        FS.Files HexFiles()
            => Targets().Files(FileKind.HexDat);

        FS.Files HexFiles(PartId part)
            => Targets().Files(FileKind.HexDat).Where(x => x.FileName.StartsWith(part.Format() + "."));

        FS.FilePath CsvPath(PartId part)
            => Path(part, FileKind.Csv);

        FS.FilePath CsvPath(ApiHostUri host)
            => Path(host, FileKind.Csv);

        FS.Files CsvFiles()
            => Targets().Files(FileKind.Csv);

        FS.Files CsvFiles(PartId part)
            => Targets().Files(FileKind.Csv).Where(x => x.FileName.StartsWith(part.Format() + "."));

        FS.FilePath AsmPath(PartId part)
            => Path(part, FileKind.Asm);

        FS.FilePath AsmPath(ApiHostUri src)
            => Path(src, FileKind.Asm);

        FS.Files AsmFiles()
            => Targets().Files(FileKind.Asm);

        FS.Files AsmFiles(PartId src)
            => Targets().Files(FileKind.Asm).Where(x => x.FileName.StartsWith(src.Format() + "."));
    }
}