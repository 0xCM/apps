//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class ApiCode
    {
        [MethodImpl(Inline), Op]
        public static ApiCodeBlock block(in ApiCodeRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);

        [Op]
        public static Index<ApiHostBlocks> blocks(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts, bool pll = true)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(blocks(host, csv(src,host))), pll);
            return dst.ToIndex();

            static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
                => src + host.FileName(FS.PCsv);
        }

        [Op]
        public static ApiHostBlocks blocks(ApiHostUri host, FS.FilePath src)
            => new ApiHostBlocks(host, blocks(src));

        [Op]
        public static SortedIndex<ApiCodeBlock> blocks(IApiPack src)
            => blocks(src.HexExtracts());

        [Op]
        public static SortedIndex<ApiCodeBlock> blocks(FS.Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(ApiHex.rows(file), row => dst.Add(block(row))), pll);
            return SortedIndex<ApiCodeBlock>.sort(dst.Array());
        }

        [Op]
        public static Index<ApiCodeBlock> blocks(FS.FilePath src)
        {
            var rows = ApiHex.rows(src);
            var count = rows.Count;
            var dst = sys.alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = block(rows[j]);
            return dst;
        }
    }
}