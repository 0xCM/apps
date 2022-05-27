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
        public static MemoryBlock memory(in ApiHexRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);

        [MethodImpl(Inline), Op]
        public static MemoryBlock memory(in ApiMemberExtract src)
            => new MemoryBlock(src.Block.Origin, src.Block.Encoded);

        public static MemoryBlocks memory(ReadOnlySpan<ApiHexRow> src)
        {
            var count = src.Length;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ApiCodeBlock code(in ApiHexRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);

        [MethodImpl(Inline), Op]
        public static ApiHexRow hex(in ApiMemberCode src, uint seq)
        {
            var dst = ApiHexRow.Empty;
            dst.Seq = (int)seq;
            dst.SourceSeq = (int)src.Sequence;
            dst.Address = src.Address;
            dst.Length = src.Encoded.Length;
            dst.TermCode = src.TermCode;
            dst.Uri = src.OpUri;
            dst.Data = src.Encoded;
            return dst;
        }

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

        public static SortedIndex<ApiCodeBlock> code(FS.Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(hex(file), row => dst.Add(code(row))), pll);
            return new (dst.Array());
        }

        public static ApiHostBlocks code(ApiHostUri host, FS.FilePath src)
            => new ApiHostBlocks(host, code(src));

        public static Index<ApiHostBlocks> code(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts, bool pll = true)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(code(host, csv(src,host))), pll);
            return dst.ToIndex();
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

        public static MemoryBlocks memory(ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                var encoded = code.Block.Encoded;
                seek(dst,i) = new MemoryBlock(code.Origin, encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }

        public static MemoryBlocks memory(FS.FilePath src)
        {
            var dst = MemoryBlocks.Empty;
            var result = Outcome<MemoryBlocks>.Success;
            var unpacked = Outcome<ByteSize>.Success;
            var size  = ByteSize.Zero;
            var buffer = list<MemoryBlock>();
            var counter = z16;
            using var reader = src.AsciReader();
            var data = reader.ReadLine();
            var block = MemoryBlock.Empty;
            while(result.Ok && text.nonempty(data))
            {
                unpacked = parse(counter++, data, out block);
                if(unpacked.Fail)
                {
                    result = (false, unpacked.Message);
                    Errors.Throw(unpacked.Message);
                }
                else
                {
                    buffer.Add(block);
                    size += unpacked.Data;
                    data = reader.ReadLine();
                }
            }

            dst = buffer.ToArray();
            return dst;
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

        public static Outcome<ByteSize> parse(ushort index, string src, out MemoryBlock dst)
        {
            var count = src.Length;
            var line = index + 1;
            var result = Outcome.Success;
            dst = default;
            if(count == 0)
            {
                dst = MemoryBlock.Empty;
                return (false, "The input, it is empty");
            }

            if(first(src) != 'x')
                return(false, $"Line {src} does not begin with the required character 'x'");

            var i = src.IndexOf('h');
            if(i == NotFound)
                return(false, $"Line {src} does not contain address terminator 'h'");

            result = AddressParser.parse(text.slice(src, 1, i-1), out MemoryAddress @base);
            if(result.Fail)
                return (false, $"{result.Message} | Could not parse address from '{src}'");

            if(!text.unfence(src, SegFence, out var seg))
                return (false, $"Line {src} does not contain segment fence");

            if(!text.unfence(src, DataFence, out var data))
                return (false, $"Line {src} does not contain data fence");

            var segparts = text.split(seg, SegSep);
            if(segparts.Length != 2)
                return (false, $"Line {src} segement specifier does not have the required 2 components");

            var segLeft = skip(segparts,0);
            DataParser.parse(segLeft, out ushort segidx);
            if(segidx != index)
                return (false, $"Line {line} number does not correspond to the segement index {segidx}");

            var segRight = skip(segparts,1);
            result = DataParser.parse(segRight, out ByteSize segsize);
            if(result.Fail)
                return (false, $"{result.Message} | Could not parse segment size from {segRight}");

            result = Hex.parse(data, out BinaryCode code);

            if(result.Fail)
                return (false, $"{result.Message} | Could not parse code from {data}");

            if(code.IsEmpty)
                return (false, $"Line {src} contains no data");

            if(segsize != code.Length)
                return (false, $"Expected {segsize} bytes but parsed {code.Length}");

            dst = new MemoryBlock(@base, segsize, code);

            return segsize;
        }

        const char SegSep = Chars.Colon;

        static Fence<char> SegFence = ('[',']');

        static Fence<char> DataFence = ('<', '>');

        ApiPacks ApiPacks => Service(Wf.ApiPacks);

        IApiPack ApiPack => ApiPacks.Current();

        public FS.FolderPath ParsedExtractRoot()
            => ApiPack.ParsedExtractRoot();

        public FS.Files ParsedExtracts()
            => ParsedExtractRoot().Files(FS.PCsv);

        public FS.FilePath ParsedExtracts(ApiHostUri host)
            => ParsedExtractRoot() + host.FileName(FS.PCsv);

        public FS.FilePath ParsedExtracts(Type host)
            => ParsedExtractRoot() + ApiHostUri.from(host).FileName(FS.PCsv);

        [Op]
        public SortedIndex<ApiCodeBlock> ReadBlocks()
            => ReadBlocks(ParsedExtracts());

        public ReadOnlySpan<ApiHostBlocks> ReadHostBlocks(ReadOnlySpan<ApiHostUri> src, bool pll = true)
            => code(ParsedExtractRoot(), src, pll);

        public ReadOnlySpan<ApiHostBlocks> ReadHostBlocks()
        {
            var flow = Running("Loading host blocks");
            var files = ParsedExtracts().View;
            var count = files.Length;
            var dst = list<ApiHostBlocks>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref skip(files,i);
                if(InferHost(file.FileName, out var host))
                {
                    var blocks = ReadBlocks(host);
                    dst.Add(blocks);
                    counter += blocks.Count;
                }
                else
                    Warn(string.Format("Unable to infer host for {0}", file.ToUri()));
            }

            var deposited = dst.ViewDeposited();
            Ran(flow,string.Format("Loaded {0} blocks from {1} hosts", counter, deposited.Length));

            return deposited;
        }

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            =>  src + host.FileName(FS.PCsv);

        [Op]
        public ApiHostBlocks ReadBlocks(ApiHostUri host)
            => code(host, ParsedExtracts(host));

        [Op]
        public Index<ApiCodeBlock> ReadBlocks(FS.FilePath src)
            => code(src);

        [Op]
        public Count ReadBlocks(FS.FilePath src, List<ApiCodeBlock> dst)
        {
            var data = hex(src);
            var count = data.Count;
            for(var i=0; i<count; i++)
                dst.Add(code(data[i]));
            return count;
        }

        [Op]
        public SortedIndex<ApiCodeBlock> ReadBlocks(FS.Files src, bool pll = true)
            => code(src,pll);

        [Op]
        public Index<ApiHexRow> WriteBlocks(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = hex(skip(src, i), i);

                var path = Db.ParsedExtractPath(dst, uri);
                TableEmit(@readonly(buffer), path);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        [Op]
        public Index<ApiHexRow> WriteBlocks(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = hex(skip(src, i), i);

                TableEmit(@readonly(buffer), dst);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        [Op]
        public ReadOnlySpan<ApiHexRow> ReadRows(FS.FilePath src)
        {
            var data = src.ReadLines().Storage.ToReadOnlySpan();
            var count = data.Length - 1;
            var dst = alloc<ApiHexRow>(count);
            for(var i=0; i<count; i++)
            {
                var result = parse(skip(data, i + 1), out seek(dst,i));
                if(result.Fail)
                    Errors.Throw(string.Format("{0}:{1}", src.ToUri(), result.Message));
            }
            return dst;
        }

        [Op]
        public Count ReadRows(FS.FilePath src, DataList<ApiHexRow> dst)
        {
            var result = Outcome.Success;
            var data = src.ReadLines().Storage.Skip(1);
            var count = data.Length;

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
            return count;
        }

        [Op]
        public ReadOnlySpan<ApiHexIndexRow> EmitIndex(SortedIndex<ApiCodeBlock> src, FS.FilePath dst)
            => EmitIndex(Spans.sorted(src.View), dst);

        [Op]
        ReadOnlySpan<ApiHexIndexRow> EmitIndex(SortedReadOnlySpan<ApiCodeBlock> src, FS.FilePath dst)
        {
            var flow = EmittingTable<ApiHexIndexRow>(dst);
            var blocks = src.View;
            var count = blocks.Length;
            var buffer = alloc<ApiHexIndexRow>(count);
            var target = span(buffer);
            var parts = PartNames.NameLookup();

            using var writer = dst.Utf8Writer();
            var formatter = Tables.formatter<ApiHexIndexRow>();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                ref var record = ref seek(target, i);
                record.Seqence = i;
                record.Address = block.BaseAddress;
                parts.TryGetValue(block.OpUri.Part, out var name);
                record.Component = name.IsEmpty ? block.OpUri.Part.Format() : name.Format();
                record.HostName = block.OpUri.Host.HostName;
                record.MethodName = block.OpId.Name;
                record.Uri = block.OpUri;
                writer.WriteLine(formatter.Format(record));
            }

            EmittedTable(flow, count);
            return buffer;
        }

        static Outcome InferHost(FS.FileName src, out ApiHostUri host)
        {
            var components = @readonly(src.Name.Text.Remove(".p.csv").SplitClean(Chars.Dot));
            var count = components.Length;
            if(count >= 2)
            {
                if(ApiParsers.part(first(components), out var part))
                {
                    host =  new ApiHostUri(part, slice(components,1).Join(Chars.Dot));
                    return true;
                }
            }
            host = ApiHostUri.Empty;
            return false;
        }
    }
}