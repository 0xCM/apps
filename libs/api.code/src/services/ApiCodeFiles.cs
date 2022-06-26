//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCodeFiles : WfSvc<ApiCodeFiles>
    {
        public DumpArchive DumpArchive
            => Wf.DumpArchive();

        public IApiPack ApiPack(FS.FolderPath dst, Timestamp ts)
            => new ApiPack(dst, ts);

        public IApiPack ApiPack(Timestamp ts)
            => ApiPack(AppDb.Capture().Targets(ts.Format()).Root, ts);

        public FS.FilePath Path(Timestamp ts, PartId part, FileKind kind)
            => ApiPack(ts).Path(part, kind);

        public FS.FilePath Path(Timestamp ts, ApiHostUri host, FileKind kind)
            => ApiPack(ts).Path(host, kind);

        public FS.FilePath HexPath(Timestamp ts, PartId src)
            => ApiPack(ts).HexPath(src);

        public FS.FilePath HexPath(Timestamp ts, ApiHostUri src)
            => ApiPack(ts).HexPath(src);

        public FS.Files HexFiles(Timestamp ts)
            => ApiPack(ts).Files(FileKind.HexDat);

        public FS.Files HexFiles(Timestamp ts, PartId src)
            => ApiPack(ts).HexFiles(src);

        public FS.FilePath CsvPath(Timestamp ts, PartId src)
            => ApiPack(ts).CsvPath(src);

        public FS.FilePath CsvPath(Timestamp ts, ApiHostUri src)
            => ApiPack(ts).CsvPath(src);

        public FS.FilePath AsmPath(Timestamp ts, PartId src)
            => ApiPack(ts).AsmPath(src);

        public FS.FilePath AsmPath(Timestamp ts, ApiHostUri src)
            => ApiPack(ts).AsmPath(src);

        public FS.Files AsmFiles(Timestamp ts)
            => ApiPack(ts).Files(FileKind.Asm);

        public FS.Files AsmFiles(Timestamp ts, PartId src)
            => ApiPack(ts).AsmFiles(src);

        public FS.Files CsvFiles(Timestamp ts)
            => ApiPack(ts).Files(FileKind.Csv);

        public FS.Files CsvFiles(Timestamp ts, PartId src)
            => ApiPack(ts).CsvFiles(src);

        public IDbTargets MemoryBlocks(Timestamp ts)
            => new DbTargets(ApiPack(ts).Root);

        public ApiPartFiles PartFiles(Timestamp ts, PartId src)
            => new ApiPartFiles(src, ApiPack(ts).Root);

        public IDbTargets MemoryBlocks()
            => AppDb.Capture();

        public FS.Files HexFiles()
            => AppDb.Capture().Files(FileKind.Hex);

        public FS.FilePath HexPath(ApiHostUri host)
            => AppDb.Capture().Path(host.FileName(FS.Hex));

        public ApiPartFiles PartFiles(PartId part)
            => new ApiPartFiles(part, AppDb.Capture().Root);

        public FS.FilePath AsmPath(ApiHostUri host)
            => AppDb.Capture().Path(host.FileName(FS.Asm));

        public FS.FilePath AsmPath(PartId part)
            => AppDb.Capture().Path(FS.file(part.Format(), FS.Asm));

        public FS.FilePath HexPath(PartId part)
            => AppDb.Capture().Path(FS.file(part.Format(), FS.Hex));

        public FS.FilePath CsvPath(PartId part)
            => AppDb.Capture().Path(FS.file(part.Format(), FS.Csv));

        public FS.FilePath CsvPath(ApiHostUri host)
            => AppDb.Capture().Path(host.FileName(FS.Csv));

        public FS.FilePath Path(FS.FileExt ext)
            => AppDb.Capture().Path(FS.file("api", ext));

        public FS.FilePath Path(PartId part, FS.FileExt ext)
            => AppDb.Capture().Path(FS.file(part.Format(), ext));

        public FS.FilePath Path(ApiHostUri host, FS.FileExt ext)
            => AppDb.Capture().Path(host.FileName(ext));

        public FS.FilePath Path(string spec, FS.FileExt ext)
        {
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return Path(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)), ext);
                else
                    return Path(ApiParsers.part(spec), ext);
            }
            else
                return Path(ext);
        }
    }
}