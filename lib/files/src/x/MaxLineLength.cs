//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static TextFileStats FileStats(this FS.FilePath src)
            => FS.stats(src);
    }
}