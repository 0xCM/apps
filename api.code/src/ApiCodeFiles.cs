//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCodeFiles : AppService<ApiCodeFiles>
    {
        AppDb AppDb => Wf.AppDb();

        DbTargets Targets()
            => AppDb.ApiTargets("capture");

        DbSources Sources()
            => Targets().ToSource();

        public FS.FolderPath TargetRoot()
            => Targets();

        public FS.Files HexFiles()
            => Sources().Files(FileKind.Hex);

        public FS.Files HexFiles(PartId part)
            => Sources().Files(FileKind.Hex).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public FS.FilePath HexPath(ApiHostUri host)
            => Sources().Path(host.FileName(FS.Hex));

        public FS.Files AsmFiles()
            => Sources().Files(FileKind.Asm);

        public FS.Files AsmFiles(PartId part)
            => Sources().Files(FileKind.Asm).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public ApiPartFiles PartFiles(PartId part)
            => new ApiPartFiles(part, Sources());

        public FS.FilePath AsmPath(ApiHostUri host)
            => Sources().Path(host.FileName(FS.Asm));

        public FS.FilePath AsmPath(PartId part)
            => Sources().Path(FS.file(part.Format(), FS.Asm));

        public FS.FilePath HexPath(PartId part)
            => Sources().Path(FS.file(part.Format(), FS.Hex));

        public FS.FilePath CsvPath(PartId part)
            => Sources().Path(FS.file(part.Format(), FS.Csv));

        public FS.Files CsvFiles()
            => Sources().Files(FileKind.Csv);

        public FS.Files CsvFiles(PartId part)
            => Sources().Files(FileKind.Csv).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public FS.FilePath CsvPath(ApiHostUri host)
            => Sources().Path(host.FileName(FS.Csv));

        public FS.FilePath Path(FS.FileExt ext)
            => Targets().Path(FS.file("api", ext));

        public FS.FilePath Path(PartId part, FS.FileExt ext)
            => Targets().Path(FS.file(part.Format(), ext));

        public FS.FilePath Path(ApiHostUri host, FS.FileExt ext)
            => Targets().Path(host.FileName(ext));

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