//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCodeFiles : WfSvc<ApiCodeFiles>
    {
        public IApiPack ApiPack(FS.FolderPath dst, Timestamp ts)
            => new ApiPack(dst, ts);

        public IApiPack ApiPack(Timestamp ts)
            => ApiPack(AppDb.Capture().Targets(ts.Format()).Root, ts);

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

        // public FS.FilePath Path(string spec, FS.FileExt ext)
        // {
        //     if(text.nonempty(spec))
        //     {
        //         var i = text.index(spec, Chars.FSlash);
        //         if(i>0)
        //             return Path(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)), ext);
        //         else
        //             return Path(ApiParsers.part(spec), ext);
        //     }
        //     else
        //         return Path(ext);
        // }
    }
}