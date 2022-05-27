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

        public FS.Files Hex()
            => Sources().Files(FileKind.Hex);

        public FS.Files Hex(PartId part)
            => Sources().Files(FileKind.Hex).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public FS.FilePath Hex(ApiHostUri host)
            => Sources().Path(host.FileName(FS.Hex));

        public FS.Files Asm()
            => Sources().Files(FileKind.Asm);

        public FS.Files Asm(PartId part)
            => Sources().Files(FileKind.Asm).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public FS.FilePath Asm(ApiHostUri host)
            => Sources().Path(host.FileName(FS.Asm));

        public FS.Files Csv()
            => Sources().Files(FileKind.Csv);

        public FS.Files Csv(PartId part)
            => Sources().Files(FileKind.Csv).Where(x => x.FileName.StartsWith(part.Format() + "."));

        public FS.FilePath Csv(ApiHostUri host)
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