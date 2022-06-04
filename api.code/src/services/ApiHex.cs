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


        [Op]
        public Index<ApiCodeBlock> ReadBlocks(FS.FilePath src)
            => code(src);
  }
}