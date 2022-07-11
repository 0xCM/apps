//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiPack : IApiPack
    {
        public static bool timestamp(FS.FolderPath src, out Timestamp dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;
            return Time.parse(fmt.RightOfIndex(idx), out dst);
        }

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

        public string Label {get;}

        public ApiPack(FS.FolderPath root, Timestamp ts, string label = EmptyString)
        {
            Root = root;
            Timestamp = ts;
            Label = label;
        }

        public string Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        public override string ToString()
            => Format();
    }
}