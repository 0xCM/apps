//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        public static ApiHostBlocks blocks(ApiHostUri host, FS.FilePath src)
            => new ApiHostBlocks(host, blocks(src));

        public static Index<ApiHostBlocks> blocks(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts, bool pll = true)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(blocks(host, csv(src,host))), pll);
            return dst.ToIndex();

            static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
                => src + host.FileName(FS.PCsv);
        }

        public static SortedIndex<ApiCodeBlock> blocks(FS.Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(apihex(file), row => dst.Add(block(row))), pll);
            return SortedIndex<ApiCodeBlock>.sort(dst.Array());
        }

        public static Index<ApiCodeBlock> blocks(FS.FilePath src)
        {
            var rows = apihex(src);
            var count = rows.Count;
            var dst = alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = block(rows[j]);
            return dst;
        }
    }
}