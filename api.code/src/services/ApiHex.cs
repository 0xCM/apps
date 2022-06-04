//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class ApiHex : AppService<ApiHex>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        [MethodImpl(Inline), Op]
        public static ApiHexRow row(in ApiMemberCode src, uint seq)
        {
            var dst = ApiHexRow.Empty;
            dst.Seq = seq;
            dst.SourceSeq = src.Sequence;
            dst.Address = src.Address;
            dst.CodeSize = src.Encoded.Size;
            dst.TermCode = src.TermCode;
            dst.Uri = src.OpUri;
            dst.Data = src.Encoded;
            return dst;
        }

        public static Index<ApiHexRow> rows(FS.FilePath src)
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

        public MemoryBlocks LoadMemoryBlocks(FS.FolderPath root)
        {
            var _blocks = LoadMemoryBlocks(root.Files(".parsed", FS.XPack, true));
            var entries = _blocks.Entries;
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

        [Op]
        public Index<ApiHexRow> EmitRows(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = ApiHex.row(skip(src, i), i);

                var path = Db.ParsedExtractPath(dst, uri);
                AppSvc.TableEmit(buffer, path);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        public Index<ApiHexRow> EmitRows(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = ApiHex.row(skip(src, i), i);

                AppSvc.TableEmit(buffer, dst);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        public ConstLookup<FS.FilePath,MemoryBlocks> LoadMemoryBlocks(FS.Files src)
        {
            var flow = Running(string.Format("Loading {0} packs", src.Length));
            var lookup = new Lookup<FS.FilePath,MemoryBlocks>();
            var errors = new Lookup<FS.FilePath,Outcome>();
            iter(src, path => lookup.Include(path, ApiHex.memory(path)), true);
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

        public Index<ApiHexPack> EmitPacks(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        {
            var _dst = dst ?? Env.Db + FS.folder(EnvFolders.tables) + FS.file("apihex", FS.ext("xpack"));
            var result = pack(src, validate);
            var packed = result.View;
            var emitting = EmittingFile(_dst);
            using var writer = _dst.Writer();
            var count = packed.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(packed,i).Format());
            EmittedFile(emitting, count);
            return result;
        }

        [MethodImpl(Inline), Op]
        public static ApiCodeBlock code(in ApiHexRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);

        [MethodImpl(Inline), Op]
        public static MemoryBlock memory(in ApiHexRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);

        public static MemoryBlocks memory(ReadOnlySpan<ApiHexRow> src)
        {
            var count = src.Length;
            var dst = alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        /// <summary>
        /// Materializes a <see cref='MemoryBlock'/> sequence from a file with lines of the form
        /// x7ffb651869e0[00012:00017]=<c5f8776690c5f857c0c5f91101488bc1c3>
        /// </summary>
        /// <param name="src"></param>
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

        [Parser]
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

                result = DataParser.parse(fields[index++], out dst.CodeSize);
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

        [Op]
        public Index<ApiCodeBlock> ReadBlocks(FS.FilePath src)
            => code(src);
    }
}