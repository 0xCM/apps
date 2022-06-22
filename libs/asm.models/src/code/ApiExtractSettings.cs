//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ApiExtractSettings :  ISettings<ApiExtractSettings>
    {
        public static Outcome timestamp(FS.FolderPath src, out Timestamp dst)
        {
            dst = default;
            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return (false, "Path separator not found");
            return Time.parse(fmt.RightOfIndex(idx), out dst);
        }

        public FS.FolderPath ExtractRoot;

        public bool EmitContext;

        public bool Analyze;


        public Timestamp Timestamp;

        public static ApiExtractSettings init(FS.FolderPath root)
        {
            var dst = new ApiExtractSettings();
            timestamp(root, out dst.Timestamp);
            dst.Analyze = true;
            dst.EmitContext = true;
            dst.ExtractRoot =  root;
            return dst;
        }
    }
}