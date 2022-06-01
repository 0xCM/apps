//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ApiCode : AppService<ApiCode>
    {
        const int DefaultBufferLength = Pow2.T14 + Pow2.T08;

        [Op]
        public static byte[] buffer(ByteSize? size = null)
            => alloc<byte>(size ?? DefaultBufferLength);

        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiHex ApiHex => Wf.ApiHex();

        ApiMd ApiMd => Wf.ApiMetadata();

        new ApiCodeFiles Files => Wf.ApiCodeFiles();

        AppSvcOps AppSvc => Wf.AppSvc();

        public SortedIndex<ApiCodeBlock> LoadBlocks()
            => blocks(Files.HexFiles());

        public MemoryBlocks LoadMemoryBlocks()
            => LoadMemoryBlocks(Files.TargetRoot());

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

        public ConstLookup<FS.FilePath,MemoryBlocks> LoadMemoryBlocks(FS.Files src)
        {
            var flow = Running(string.Format("Loading {0} packs", src.Length));
            var lookup = new Lookup<FS.FilePath,MemoryBlocks>();
            var errors = new Lookup<FS.FilePath,Outcome>();
            iter(src, path => lookup.Include(path, ApiCode.memory(path)), true);
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
        public Index<HexPacked> EmitHexPack(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        {
            var _dst = dst ?? Env.Db + FS.folder(EnvFolders.tables) + FS.file("apihex", FS.ext("xpack"));
            var result = ApiCode.pack(src, validate);
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
        public ByteSize Emit(in MemoryBlock src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = MemoryStore.emit(MemoryStore.pack(src), writer);
            EmittedFile(flow, (uint)total);
            return total;
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

        public Index<MethodEntryPoint> CalcEntryPoints()
            => MethodEntryPoints.create(ApiJit.JitCatalog(ApiMd.Catalog));

        public Index<MethodEntryPoint> CalcEntryPoints(ApiHostUri src)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiMd.Catalog.FindHost(src, out var host))
               dst = MethodEntryPoints.create(ApiJit.JitHost(host));
            return dst;
        }

        public Index<MethodEntryPoint> CalcEntryPoints(PartId id)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiMd.Catalog.FindPart(id, out var src))
                dst = MethodEntryPoints.create(ApiJit.JitPart(src));
            return dst;
        }

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols)
        {
            var collected = Collect(symbols, CalcEntryPoints());
            Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
            return collected;
        }

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols, ApiHostUri src)
        {
            var entries = CalcEntryPoints(src);
            var collected = sys.empty<CollectedEncoding>();
            if(entries.IsNonEmpty)
            {
                collected = Collect(symbols, entries);
                Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
            }
            else
                Warn($"{src} has no exposed methods");
            return collected;
        }

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols, IPart src)
            => Collect(symbols, MethodEntryPoints.create(ApiJit.JitPart(src)));

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols, PartId src)
        {
            var entries = CalcEntryPoints(src);
            var collected = sys.empty<CollectedEncoding>();
            if(entries.IsNonEmpty)
            {
                collected = Collect(symbols, entries);
                Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
            }
            else
                Warn($"{src} has no exposed methods");

            return collected;
        }

        public Index<CollectedEncoding> Collect()
        {
            using var symbols = Alloc.symbols();
            var collected = Collect(symbols, CalcEntryPoints());
            Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
            return collected;
        }

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols, string spec)
        {
            var emitted = Index<CollectedEncoding>.Empty;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    emitted = Collect(symbols, ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    emitted = Collect(symbols, ApiParsers.part(spec));
            }
            else
                emitted = Collect(symbols);

            return emitted;
        }

        public Index<CollectedEncoding> Collect(ApiHostUri src)
        {
            using var symbols = Alloc.symbols();
            return Collect(symbols, src);
        }

        public Index<CollectedEncoding> Collect(PartId src)
        {
            using var symbols = Alloc.symbols();
            return Collect(symbols, src);
        }

        public Index<CollectedEncoding> Collect(string spec)
        {
            var emitted = Index<CollectedEncoding>.Empty;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    emitted = Collect(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    emitted = Collect(ApiParsers.part(spec));
            }
            else
                emitted = Collect();

            return emitted;
        }

        public EncodedMembers Load()
            => Load(Alloc.dispenser(Alloc.symbols));

        public EncodedMembers Load(string spec)
            => Load(Alloc.dispenser(Alloc.symbols), spec);

        public EncodedMembers Load(PartId src)
        {
            Load(src, out var index, out var code);
            return members(Alloc.dispenser(Alloc.symbols), index, code);
        }

        EncodedMembers Load(SymbolDispenser symbols)
        {
            Load(out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers Load(SymbolDispenser symbols, string spec)
        {
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return Load(symbols, ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    return Load(symbols, ApiParsers.part(spec));
            }
            else
                return Load(symbols);
        }

        EncodedMembers Load(SymbolDispenser symbols, ApiHostUri src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers Load(SymbolDispenser symbols, PartId src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        public ByteSize EmitHex(Index<CollectedEncoding> src, FS.FilePath dst)
        {
            var count = src.Count;
            var emitting = EmittingFile(dst);
            var size = ApiCode.hex(src, dst);
            EmittedFile(emitting,count);
            return size;
        }

        public Index<EncodedMember> EmitCsv(Index<CollectedEncoding> collected, FS.FilePath dst)
        {
            var count = collected.Count;
            var buffer = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = describe(collected[i]);
            var rebase = min(buffer.Select(x => (ulong)x.EntryAddress).Min(), buffer.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(buffer,i).EntryRebase = skip(buffer,i).EntryAddress - rebase;
                seek(buffer,i).TargetRebase = skip(buffer,i).TargetAddress - rebase;
            }

            AppSvc.TableEmit(buffer, dst);
            return buffer;
        }

        void Load(out Index<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.Path(FS.Hex), out data).Require();
            ApiCode.index(Files.Path(FS.Csv), out index).Require();
        }

        Index<EncodedMember> LoadMember(PartId src)
        {
            var dst = Index<EncodedMember>.Empty;
            var result = index(Files.Path(src, FS.Csv), out dst);
            if(result.Fail)
            {
                Write(result.Message,FlairKind.Warning);
                Errors.Throw($"{src.Format()} member load failure");
            }
            return dst;
        }

        BinaryCode LoadCode(PartId src)
        {
            var dst = BinaryCode.Empty;
            var result = hex(Files.Path(src, FS.Hex), out dst);
            if(result.Fail)
            {
                Error(result.Message);
                Errors.Throw(result.Message);
            }
            return dst;
        }

        void Load(PartId src, out Index<EncodedMember> index, out BinaryCode data)
        {
            index = LoadMember(src);
            data = LoadCode(src);
        }

        void Load(ApiHostUri src, out Index<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.HexPath(src), out data).Require();
            ApiCode.index(Files.CsvPath(src), out index).Require();
        }

        Index<CollectedEncoding> Collect(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> src)
            => divine(collect(symbols, src), x => Write(x.Format(), x.Flair));

        Index<EncodedMember> Emit(Index<CollectedEncoding> src, FS.FilePath hex, FS.FilePath csv)
        {
            var collected = src.Sort();
            var count = collected.Count;
            var emitting = EmittingFile(hex);
            var size = ApiCode.hex(collected, hex);
            EmittedFile(emitting,count);
            var encoded = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(encoded,i) = describe(collected[i]);
            var rebase = min(encoded.Select(x => (ulong)x.EntryAddress).Min(), encoded.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(encoded,i).EntryRebase = skip(encoded,i).EntryAddress - rebase;
                seek(encoded,i).TargetRebase = skip(encoded,i).TargetAddress - rebase;
            }

            AppSvc.TableEmit(encoded, csv);
            return encoded;
        }

        [Op]
        public Index<ApiHexRow> WriteApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = apihex(skip(src, i), i);

                var path = Db.ParsedExtractPath(dst, uri);
                AppSvc.TableEmit(buffer, path);
                return buffer;
            }
            else
                return array<ApiHexRow>();
        }

        public Index<ApiHexRow> WriteApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                var buffer = alloc<ApiHexRow>(count);
                for(var i=0u; i<count; i++)
                    seek(buffer, i) = apihex(skip(src, i), i);

                AppSvc.TableEmit(buffer, dst);
                return buffer;
            }
            else
                return array<ApiHexRow>();
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

    }
}