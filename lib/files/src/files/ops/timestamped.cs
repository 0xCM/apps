//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial struct FS
    {
        public static Outcome timestamp(FS.FolderPath src, out Timestamp dst)
        {
            dst = Timestamp.Zero;
            if(src.IsEmpty)
                return false;

            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;

            var outcome = Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(outcome)
            {
                dst = ts;
                return true;
            }
            else
                return(false,outcome.Message);
        }

        [Op]
        public static FilePath timestamped(FilePath src)
        {
            var name = src.FileName.WithoutExtension;
            var ext = src.Ext;
            var stamped = file(string.Format("{0}.{1}.{2}", name, core.timestamp(), ext));
            return src.FolderPath + stamped;
        }
    }
}