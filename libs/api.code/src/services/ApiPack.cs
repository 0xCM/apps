//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPack : IApiPack
    {
        public static bool parse(FS.FolderPath src, out ApiPack dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            var result =Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(result)
                dst = new ApiPack(src,ts);
            else
                dst = new ApiPack(FS.FolderPath.Empty, Timestamp.Zero);
            return result;

        }

        public FS.FolderPath Root {get;}

        public Timestamp Timestamp {get;}

        public ApiPack(FS.FolderPath root, Timestamp ts)
        {
            Root = root;
            Timestamp = ts;
        }

        FS.FileName DumpFile(Process process)
            => FS.file(ProcDumpName.create(process,Timestamp).Format(), FS.Dmp);

        public FS.FilePath ProcDumpPath(Process process)
            => Root + DumpFile(process);

        public string Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        public override string ToString()
            => Format();
    }
}