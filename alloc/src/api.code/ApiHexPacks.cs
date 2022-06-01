//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiHexPacks : AppService<ApiHexPacks>
    {

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

        public static Index<ApiCodeBlock> code(FS.FilePath src)
        {
            var rows = hex(src);
            var count = rows.Count;
            var dst = alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = code(rows[j]);
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

        [MethodImpl(Inline), Op]
        public static MemoryBlock memory(in ApiMemberExtract src)
            => new MemoryBlock(src.Block.Origin, src.Block.Encoded);

        public static MemoryBlock memory(in ApiHexRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);

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

        public static SortedIndex<ApiCodeBlock> code(FS.Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(hex(file), row => dst.Add(code(row))), pll);
            return SortedIndex<ApiCodeBlock>.sort(dst.Array());
        }

        public static MemoryBlocks memory(ReadOnlySpan<ApiHexRow> src)
        {
            var count = src.Length;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        public static ApiHostBlocks code(ApiHostUri host, FS.FilePath src)
            => new ApiHostBlocks(host, code(src));

        public static FS.FilePath csv(FS.FolderPath src, ApiHostUri host)
            =>  src + host.FileName(FS.PCsv);


        [Op]
        public Count ReadBlocks(FS.FilePath src, List<ApiCodeBlock> dst)
        {
            var data = hex(src);
            var count = data.Count;
            for(var i=0; i<count; i++)
                dst.Add(code(data[i]));
            return count;
        }

        public static Index<ApiHostBlocks> code(FS.FolderPath src, ReadOnlySpan<ApiHostUri> hosts, bool pll = true)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(code(host, csv(src,host))), pll);
            return dst.ToIndex();
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

        // x7ffb651869e0[00012:00017]=<c5f8776690c5f857c0c5f91101488bc1c3>
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

        public ConstLookup<FS.FilePath,MemoryBlocks> LoadParsed(FS.FolderPath src)
            => Load(src.Files(".parsed", FS.XPack, true));

        public MemoryBlocks LoadBlocks(FS.FolderPath root)
        {
            var entries = LoadParsed(root).Entries;
            var count = entries.Length;
            var buffer = list<MemoryBlock>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                ref readonly var pack = ref entry.Value;
                var blocks = pack.View;
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);
                    buffer.Add(block);
                }
            }

            buffer.Sort();
            return new MemoryBlocks(buffer.ToArray());
        }

        public ConstLookup<FS.FilePath,MemoryBlocks> Load(FS.Files src)
        {
            var flow = Running(string.Format("Loading {0} packs", src.Length));
            var lookup = new Lookup<FS.FilePath,MemoryBlocks>();
            var errors = new Lookup<FS.FilePath,Outcome>();
            iter(src, path => lookup.Include(path, memory(path)), true);
            var result = lookup.Seal();
            var count = result.EntryCount;
            var entries = result.Entries;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var path = entry.Key;
                var blocks = entry.Value.View;
                var blockCount = (uint)blocks.Length;
                var host = path.FileName.Format().Remove(".extracts.parsed.xpack").Replace(".","/");
                Write(string.Format("Loaded {0} blocks from {1}", blockCount, path.ToUri()));
                counter += blockCount;
            }

            Ran(flow, string.Format("Loaded {0} total blocks", counter));

            return result;
        }

        [Op]
        public Index<HexPacked> Pack(SortedIndex<ApiCodeBlock> src, bool validate = false)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = alloc<HexPacked>(count);
            var chars = alloc<char>(BufferLength);
            ref var dst = ref first(packs);
            var size = ApiBlocks.pack(blocks, packs, chars);
            if(validate)
            {
                var buffer = span<HexDigitValue>(BufferLength);
                var flow = Running("Validating pack");
                for(var i=0; i<count; i++)
                {
                    buffer.Clear();
                    ref readonly var pack = ref skip(dst,i);
                    var outcome = Hex.digits(pack.Data,buffer);
                    if(!outcome)
                    {
                        Error("Reconstitution failed");
                        break;
                    }
                }
                Ran(flow,$"Validated {count} packs");
            }

            return packs;
        }

        [Op]
        public Index<HexPacked> Emit(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        {
            var _dst = dst ?? Env.Db + FS.folder(EnvFolders.tables) + FS.file("apihex", FS.ext("xpack"));
            var result = Pack(src, validate);
            var packed = result.View;
            var emitting = EmittingFile(_dst);
            using var writer = _dst.Writer();
            var count = packed.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(packed,i).Format());
            EmittedFile(emitting, count);
            return result;
        }

        [Op]
        public ByteSize Emit(in MemoryBlocks src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = MemoryStore.emit(src, writer);
            EmittedFile(flow, (uint)total);
            return total;
        }

        [Op]
        public ByteSize Emit(in MemoryBlock src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = MemoryStore.emit(MemoryStore.pack(src), writer);
            EmittedFile(flow, (uint)total);
            return total;
        }
    }
}