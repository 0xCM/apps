//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ApiHex : AppService<ApiHex>
    {
        [MethodImpl(Inline), Op]
        public static ApiCodeBlock code(in ApiHexRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);

        // [MethodImpl(Inline), Op]
        // public static ApiHexRow hex(in ApiMemberCode src, uint seq)
        // {
        //     var dst = ApiHexRow.Empty;
        //     dst.Seq = (int)seq;
        //     dst.SourceSeq = (int)src.Sequence;
        //     dst.Address = src.Address;
        //     dst.Length = src.Encoded.Length;
        //     dst.TermCode = src.TermCode;
        //     dst.Uri = src.OpUri;
        //     dst.Data = src.Encoded;
        //     return dst;
        // }

        public static Index<ApiCodeBlock> code(FS.FilePath src)
        {
            var rows = hex(src);
            var count = rows.Count;
            var dst = alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
            {
                seek(dst,j) = code(rows[j]);
            }
            return dst;
        }

        // public static SortedIndex<ApiCodeBlock> code(FS.Files src, bool pll = true)
        // {
        //     var dst = bag<ApiCodeBlock>();
        //     iter(src, file => iter(hex(file), row => dst.Add(code(row))), pll);
        //     return new (dst.Array());
        // }

        // public static ApiHostBlocks code(ApiHostUri host, FS.FilePath src)
        //     => new ApiHostBlocks(host, code(src));

        // public static Index<ApiHostBlocks> code(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts, bool pll = true)
        // {
        //     var dst = bag<ApiHostBlocks>();
        //     iter(hosts, host => dst.Add(code(host, csv(src,host))), pll);
        //     return dst.ToIndex();
        // }

        [Op]
        public static Index<ApiHexRow> hex(FS.FilePath src)
        {
            var result = Outcome.Success;
            var data = src.ReadLines().Storage.Skip(1);
            var count = data.Length;
            var dst = list<ApiHexRow>();
            var j=0;
            for(var i=0; i<count; i++)
            {
                result = parse(skip(data,i), out var row);
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

        [Op]
        public static Outcome parse(string src, out ApiHexRow dst)
        {
            dst = new ApiHexRow();
            var result = Outcome.Success;
            try
            {
                if(empty(src))
                    return (false, "No text!");

                var fields = src.SplitClean(FieldDelimiter);
                var count = fields.Length;
                if(count !=  (uint)ApiHexRow.FieldCount)
                    return (false,Tables.FieldCountMismatch.Format(ApiHexRow.FieldCount, count));

                var index = 0;
                result = DataParser.parse(fields[index++], out dst.Seq);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.SourceSeq);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Address);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Length);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.eparse(fields[index++], out dst.TermCode);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Uri);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Data);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Data), fields[index-1]));
                return result;
            }
            catch(Exception e)
            {
                return e;
            }
        }


        // const char SegSep = Chars.Colon;

        // static Fence<char> SegFence = ('[',']');

        // static Fence<char> DataFence = ('<', '>');


        [Op]
        public Index<ApiCodeBlock> ReadBlocks(FS.FilePath src)
            => code(src);

        // [Op]
        // public Index<ApiHexRow> WriteBlocks(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        // {
        //     var count = src.Length;
        //     if(count != 0)
        //     {
        //         var buffer = alloc<ApiHexRow>(count);
        //         for(var i=0u; i<count; i++)
        //             seek(buffer, i) = hex(skip(src, i), i);

        //         var path = Db.ParsedExtractPath(dst, uri);
        //         TableEmit(@readonly(buffer), path);
        //         return buffer;
        //     }
        //     else
        //         return array<ApiHexRow>();
        // }

        // [Op]
        // public Index<ApiHexRow> WriteBlocks(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        // {
        //     var count = src.Length;
        //     if(count != 0)
        //     {
        //         var buffer = alloc<ApiHexRow>(count);
        //         for(var i=0u; i<count; i++)
        //             seek(buffer, i) = hex(skip(src, i), i);

        //         TableEmit(@readonly(buffer), dst);
        //         return buffer;
        //     }
        //     else
        //         return array<ApiHexRow>();
        // }

        // [Op]
        // public ReadOnlySpan<ApiHexRow> ReadRows(FS.FilePath src)
        // {
        //     var data = src.ReadLines().Storage.ToReadOnlySpan();
        //     var count = data.Length - 1;
        //     var dst = alloc<ApiHexRow>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         var result = parse(skip(data, i + 1), out seek(dst,i));
        //         if(result.Fail)
        //             Errors.Throw(string.Format("{0}:{1}", src.ToUri(), result.Message));
        //     }
        //     return dst;
        // }

        // [Op]
        // public Count ReadRows(FS.FilePath src, DataList<ApiHexRow> dst)
        // {
        //     var result = Outcome.Success;
        //     var data = src.ReadLines().Storage.Skip(1);
        //     var count = data.Length;

        //     var j=0;
        //     for(var i=0; i<count; i++)
        //     {
        //         result = parse(skip(data,i), out var row);
        //         if(result)
        //         {
        //             dst.Add(row);
        //             j++;
        //         }
        //         else
        //             Errors.Throw(result.Message);
        //     }
        //     return count;
        // }
   }
}