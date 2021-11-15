//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

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

        public bool EmitStatements;

        public Timestamp Timestamp;

        public static ApiExtractSettings init(FS.FolderPath root, Timestamp ts)
        {
            var dst = new ApiExtractSettings();
            dst.Timestamp = ts;
            dst.Analyze = true;
            dst.EmitContext = false;
            dst.EmitStatements = true;
            dst.ExtractRoot = ts == null ? root : root + FS.folder(dst.Timestamp.Format());
            return dst;
        }

        public static ApiExtractSettings init(FS.FolderPath root)
        {
            var dst = new ApiExtractSettings();
            timestamp(root, out dst.Timestamp);
            dst.Analyze = true;
            dst.EmitContext = true;
            dst.EmitStatements = true;
            dst.ExtractRoot =  root;
            return dst;
        }
    }
}