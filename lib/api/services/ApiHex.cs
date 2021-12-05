//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public class ApiHex : AppService<ApiHex>
    {
        const char SegSep = Chars.Colon;

        static Fence<char> SegFence = ('[',']');

        static Fence<char> DataFence = ('<', '>');

        [Flow]
        public static MemoryBlocks blocks(ReadOnlySpan<ApiMemberExtract> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var buffer = alloc<MemoryBlock>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                var encoded = code.Block.Encoded;
                seek(dst,i) = new MemoryBlock(code.Origin, encoded);
            }

            buffer.Sort();
            return new MemoryBlocks(buffer);
        }

        [MethodImpl(Inline), Flow]
        public static MemoryBlock block(in ApiMemberExtract src)
            => new MemoryBlock(src.Block.Origin, src.Block.Encoded);

        [Load]
        public static Outcome load(FS.FilePath src, out MemoryBlocks dst)
        {
            dst = MemoryBlocks.Empty;
            var result = Outcome<MemoryBlocks>.Success;
            var unpacked = Outcome<ByteSize>.Success;
            var size  = ByteSize.Zero;
            var buffer = list<MemoryBlock>();
            var counter = z16;
            using var reader = src.AsciReader();
            var data = reader.ReadLine();
            while(result.Ok && text.nonempty(data))
            {
                unpacked = parse(counter++, data, out var block);
                if(unpacked.Fail)
                    result = (false, unpacked.Message);
                else
                {
                    buffer.Add(block);
                    size += unpacked.Data;
                    data = reader.ReadLine();
                }
            }

            if(result.Fail)
                return result;

            dst = new MemoryBlocks(buffer.ToArray());
            return true;
        }

        static Outcome<ByteSize> parse(ushort index, string src, out MemoryBlock dst)
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

        public FS.FolderPath HexRoot()
            => Db.ParsedExtractRoot();

        public FS.FolderPath HexRoot(FS.FolderPath root)
            => Db.ParsedExtractRoot(root);

        [Op]
        public FS.Files Files()
            => HexRoot().Files(FS.PCsv);

        [Op]
        public FS.Files Files(FS.FolderPath root)
            => HexRoot(root).Files(FS.PCsv);

        [Op]
        public SortedIndex<ApiCodeBlock> ReadBlocks()
            => ReadBlocks(Db.ParsedExtractPaths());

        public SortedIndex<ApiCodeBlock> ReadBlocks(FS.FolderPath src)
            => ReadBlocks(Db.ParsedExtractPaths(src));

        [Op]
        ApiCodeBlock LoadBlock(ApiHexRow src)
        {
            if(src.Uri.IsEmpty)
                Wf.Warn(string.Format("The operation uri for method based at {0} is empty", src.Address));
            return new ApiCodeBlock(src.Address, src.Uri, src.Data);
        }

        public ReadOnlySpan<ApiHostBlocks> ReadHostBlocks(ReadOnlySpan<ApiHostUri> src)
        {
            var count = src.Length;
            var dst = list<ApiHostBlocks>();
            for(var i=0; i<count; i++)
                dst.Add(ReadBlocks(skip(src,i)));
            return dst.ViewDeposited();
        }

        public Index<ApiHostBlocks> ReadHostBlocks(FS.FolderPath root, ReadOnlySpan<ApiHostUri> src)
        {
            var count = src.Length;
            var dst = list<ApiHostBlocks>();
            for(var i=0; i<count; i++)
                dst.Add(ReadBlocks(root, skip(src,i)));
            return dst.ToArray();
        }

        public ReadOnlySpan<ApiHostBlocks> ReadHostBlocks()
            => ReadHostBlocks(HexRoot());

        public ReadOnlySpan<ApiHostBlocks> ReadHostBlocks(FS.FolderPath root)
        {
            var flow = Wf.Running(string.Format("Loading host blocks from {0}", root));
            var files = Files(root).View;
            var count = files.Length;
            var dst = list<ApiHostBlocks>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref skip(files,i);
                if(InferHost(file.FileName, out var host))
                {
                    var blocks = ReadBlocks(root, host);
                    dst.Add(blocks);
                    counter += blocks.Count;
                }
                else
                    Wf.Warn(string.Format("Unable to infer host for {0}", file.ToUri()));
            }

            var deposited = dst.ViewDeposited();
            Wf.Ran(flow,string.Format("Loaded {0} blocks from {1} hosts", counter, deposited.Length));

            return deposited;
        }

        [Op]
        public ApiHostBlocks ReadBlocks(ApiHostUri host)
            => new ApiHostBlocks(host, ReadBlocks(Db.ParsedExtractPath(host)));

        [Op]
        public ApiHostBlocks ReadBlocks(FS.FolderPath root, ApiHostUri host)
            => new ApiHostBlocks(host, ReadBlocks(Db.ParsedExtractPath(root,host)));

        [Op]
        public Index<ApiCodeBlock> ReadBlocks(FS.FilePath src)
        {
            var flow = Wf.Flow(string.Format("Reading blocks from {0}", src.ToUri()));
            var loaded = ReadRows(src);
            var rowcount = loaded.Length;
            var blocks = list<ApiCodeBlock>(256);
            if(rowcount != 0)
            {
                var rows = loaded;
                for(var j=0; j<rowcount; j++)
                    blocks.Add(LoadBlock(skip(rows, j)));
            }
            Wf.Ran(flow, string.Format("Read {0} blocks from {1}", blocks.Count, src));
            return blocks.ToArray();
        }

        [Op]
        public Count ReadBlocks(FS.FilePath src, List<ApiCodeBlock> dst)
        {
            var rows = new DataList<ApiHexRow>(1600);
            var count = ReadRows(src, rows);
            for(var i=0; i<count; i++)
                dst.Add(LoadBlock(rows[i]));
            return count;
        }

        [Op]
        public SortedIndex<ApiCodeBlock> ReadBlocks(FS.Files src)
        {
            var count = src.Length;
            if(count == 0)
                return SortedIndex<ApiCodeBlock>.Empty;

            var flow = Wf.Running(Msg.LoadingHexFileBlocks.Format(count));
            var view = src.View;
            var blocks = list<ApiCodeBlock>(32000);
            var counter = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(view,i);
                var loaded = ReadRows(path);
                var rowcount = loaded.Length;
                if(rowcount != 0)
                {
                    var rows = loaded;
                    for(var j=0; j<rowcount; j++)
                        blocks.Add(LoadBlock(skip(rows, j)));
                }

                counter += rowcount;
            }

            Wf.Ran(flow, Msg.LoadedHexBlocks.Format(counter));

            return SortedIndex<ApiCodeBlock>.sort(blocks.ToArray());
        }

        [Op]
        public Index<ApiHexRow> WriteBlocks(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var content = rows(uri, src);
                var path = Db.ParsedExtractPath(dst, uri);
                var emitting = Wf.EmittingTable<ApiHexRow>(path);
                emit(content, path);
                Wf.EmittedTable(emitting,count);
                return content;
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
                var emitting = Wf.EmittingTable<ApiHexRow>(dst);
                var rows = alloc<ApiHexRow>(count);
                fill(uri, src, rows);
                emit(rows, dst);
                Wf.EmittedTable(emitting, count);
                return rows;
            }
            else
                return array<ApiHexRow>();
        }

        [Op]
        public ReadOnlySpan<ApiHexRow> ReadRows(FS.FilePath src)
        {
            var data = src.ReadLines().Storage.ToReadOnlySpan();
            var header = first(data);
            var count = data.Length - 1;
            var buffer = alloc<ApiHexRow>(count);
            ref var dst = ref first(buffer);
            var flow = Wf.Running(string.Format("Reading hex rows from {0}", src.ToUri()));
            for(var i=0; i<count; i++)
            {
                var input = skip(data, i + 1);
                var result = ParseRow(input, out var row);
                if(result)
                    seek(dst,i) = row;
                else
                {
                    Wf.Error(string.Format("{0}:{1}", src.ToUri(), result.Message));
                    return default;
                }
            }
            Wf.Ran(flow,string.Format("Read {0} hex rows from {1}", buffer.Length, src.ToUri()));
            return buffer;
        }

        [Op]
        public Count ReadRows(FS.FilePath src, DataList<ApiHexRow> dst)
        {
            var result = Outcome.Success;
            var data = @readonly(src.ReadLines().Storage.Skip(1));
            var count = data.Length;
            var buffer = list<ApiHexRow>(count);
            var j=0;
            for(var i=0; i<count; i++)
            {
                var input = skip(data,i);

                result = ParseRow(input, out var row);
                if(result)
                {
                    dst.Add(row);
                    j++;
                }
                else
                {
                    Wf.Error(result.Message);
                    return 0;
                }
            }
            return count;
        }

        [Op]
        public Outcome ParseRow(string src, out ApiHexRow dst)
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
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.SourceSeq);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Address);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Length);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.eparse(fields[index++], out dst.TermCode);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Uri);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));

                result = DataParser.parse(fields[index++], out dst.Data);
                if(result.Fail)
                    return (false, ParseFailure.Format(nameof(dst.Data), fields[index-1]));
                return result;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        static MsgPattern<Name,string> ParseFailure => DataParser.ParseFailure;

        [Op]
        public ReadOnlySpan<ApiHexIndexRow> EmitIndex(SortedIndex<ApiCodeBlock> src, FS.FilePath dst)
        {
            return EmitIndex(Spans.sorted(src.View), dst);
        }

        [Op]
        ReadOnlySpan<ApiHexIndexRow> EmitIndex(SortedReadOnlySpan<ApiCodeBlock> src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<ApiHexIndexRow>(dst);
            var blocks = src.View;
            var count = blocks.Length;
            var buffer = alloc<ApiHexIndexRow>(count);
            var target = span(buffer);
            var parts = PartNames.NameLookup();

            using var writer = dst.Utf8Writer();
            var formatter = Tables.formatter<ApiHexIndexRow>(array<byte>(10, 16, 20, 20, 20, 120));
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

            Wf.EmittedTable(flow, count);
            return buffer;
        }

        [Op]
        static ApiHexRow[] rows(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src)
        {
            var count = src.Length;
            var buffer = alloc<ApiHexRow>(count);
            if(count != 0)
            {
                ref var dst = ref first(buffer);
                for(var i=0u; i<count; i++)
                    fill(skip(src, i), i, out seek(dst, i));
            }
            return buffer;
        }

        [Op]
        static void fill(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src, Span<ApiHexRow> dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                for(var i=0u; i<count; i++)
                    fill(skip(src, i), i, out seek(dst, i));
            }
        }

        [Op]
        static void fill(in ApiMemberCode src, uint seq, out ApiHexRow dst)
        {
            dst.Seq = (int)seq;
            dst.SourceSeq = (int)src.Sequence;
            dst.Address = src.Address;
            dst.Length = src.Encoded.Length;
            dst.TermCode = src.TermCode;
            dst.Uri = src.OpUri;
            dst.Data = src.Encoded;
        }

        [Op]
        static Count emit(ReadOnlySpan<ApiHexRow> src, FS.FilePath dst)
            => src.Length != 0 ? Tables.emit(src, dst) : 0;

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