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
        public static ApiCodeBlock apiblock(ApiCodeRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);
            
        [Op]
        public static ReadOnlySeq<ApiHostBlocks> apiblocks(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(apiblocks(host, src + host.FileName(FileKind.Csv))), AppData.get().PllExec());
            return dst.ToIndex();
        }

        [Op]
        public static ApiHostBlocks apiblocks(ApiHostUri host, FS.FilePath src)
            => new ApiHostBlocks(host, apiblocks(src));

        [Op]
        public static SortedIndex<ApiCodeBlock> apiblocks(IApiPack src)
            => apicode(src.HexExtracts());

        [Op]
        public static Index<ApiCodeBlock> apiblocks(FS.FilePath src)
        {
            var rows = apirows(src);
            var count = rows.Count;
            var dst = sys.alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = apiblock(rows[j]);
            return dst;
        }

        static Index<ApiCodeRow> apirows(FS.FilePath src)
        {
            var result = Outcome.Success;
            var data = src.ReadLines().Storage.Skip(1);
            var count = data.Length;
            var dst = list<ApiCodeRow>();
            var j=0;
            for(var i=0; i<count; i++)
            {
                result = parse(skip(data,i), out ApiCodeRow row);
                if(result)
                {
                    dst.Add(row);
                    j++;
                }
                else
                    Errors.Throw(result.Message);
            }
            return dst.Index();
        }
    }
}