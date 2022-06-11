//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ApiCode : AppService<ApiCode>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiMd ApiMd => Wf.ApiMetadata();

        ApiHex ApiHex => Wf.ApiHex();

        new ApiCodeFiles Files => Wf.ApiCodeFiles();

        AppSvcOps AppSvc => Wf.AppSvc();

        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
            => ApiHex.EmitRows(uri, src, dst);

        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
            => ApiHex.EmitRows(uri, src, dst);

        // public Index<ApiHexPack> EmitHexPack(SortedIndex<ApiCodeBlock> src, FS.FilePath? dst = null, bool validate = false)
        //     => ApiHex.EmitPacks(src,dst,validate);

        public SortedIndex<ApiCodeBlock> LoadBlocks()
            => blocks(Files.HexFiles());

        public MemoryBlocks LoadMemoryBlocks()
            => LoadMemoryBlocks(Files.Targets());

        public MemoryBlocks LoadMemoryBlocks(FS.FolderPath src)
            => ApiHex.LoadMemoryBlocks(src);

        [Op]
        public ByteSize Emit(in MemoryBlock src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            return ApiHex.pack(src, 0, writer);
        }

        [Op]
        public ByteSize Emit(in MemoryBlocks src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            var total = ApiHex.pack(src, writer);
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

        public Index<MethodEntryPoint> CalcEntryPoints(PartId part)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiMd.Catalog.FindPart(part, out var src))
                dst = MethodEntryPoints.create(ApiJit.JitPart(src));
            return dst;
        }

        public Index<CollectedEncoding> Collect(SymbolDispenser symbols)
        {
            var collected = Collect(symbols, CalcEntryPoints());
            Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
            return collected;
        }

        public Index<CollectedEncoding> Collect(IPart part, SymbolDispenser symbols, IApiPack dst)
        {
            var collected = Collect(symbols, part);
            Emit(part.Id, collected, dst);
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

        [Op]
        public static MemoryBlocks pack(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            var buffer = alloc<MemoryBlock>(count);
            return pack(src, buffer);
        }

        [Op]
        public static MemoryBlocks pack(ReadOnlySpan<ApiCodeBlock> src, Index<MemoryBlock> dst)
        {
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref skip(src,i);
                dst[i] = new MemoryBlock(code.BaseAddress, code.Size, code.Data);
            }

            return new MemoryBlocks(dst.Sort());
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
            using var symbols = Dispense.symbols();
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
            using var symbols = Dispense.symbols();
            return Collect(symbols, src);
        }

        public Index<CollectedEncoding> Collect(PartId src)
        {
            using var symbols = Dispense.symbols();
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

        Index<EncodedMember> Emit(PartId part, Index<CollectedEncoding> src, IApiPack dst)
            => Emit(src, dst.PartHex(part), dst.PartCsv(part));

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
                seek(buffer,i) = member(collected[i]);
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
                seek(encoded,i) = member(collected[i]);
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