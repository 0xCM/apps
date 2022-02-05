//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiDataPaths : AppService<ApiDataPaths>
    {
        public FS.FolderPath DataRoot => ProjectDb.Api() + FS.folder("capture");

        public FS.FilePath Path(FS.FileExt ext) => DataRoot + FS.file("api", ext);

        public FS.FilePath Path(PartId part, FS.FileExt ext) => DataRoot + FS.file(part.Format(), ext);

        public FS.FilePath Path(ApiHostUri host, FS.FileExt ext) => DataRoot + host.FileName(ext);

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