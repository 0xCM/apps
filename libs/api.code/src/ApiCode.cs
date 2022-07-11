//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ApiCode : WfSvc<ApiCode>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiHex ApiHex => Wf.ApiHex();

        new ApiCodeFiles Files => Wf.ApiCodeFiles();

        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FolderPath dst)
            => ApiHex.EmitRows(uri, src, dst);

        public Index<ApiHexRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
            => ApiHex.EmitRows(uri, src, dst);

        public SortedIndex<ApiCodeBlock> LoadBlocks()
            => blocks(Files.HexFiles());

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

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints()
            => MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog));

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints(ApiHostUri src)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiRuntimeCatalog.FindHost(src, out var host))
               dst = MethodEntryPoints.create(ApiJit.JitHost(host));
            return dst;
        }

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints(PartId part)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiRuntimeCatalog.FindPart(part, out var src))
                dst = MethodEntryPoints.create(ApiJit.JitPart(src));
            return dst;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser dst)
        {
            var collected = collect(CalcEntryPoints(), EventLog, dst);
            Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(IPart part, ICompositeDispenser symbols, IApiPack dst)
        {
            var collected = Collect(symbols, part);
            Emit(part.Id, collected, dst);
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser symbols, ApiHostUri src)
        {
            var entries = CalcEntryPoints(src);
            var collected = ReadOnlySeq<CollectedEncoding>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = collect(entries, EventLog, symbols);
                Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
            }
            else
                Warn($"{src} has no exposed methods");
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser symbols, PartId src)
        {
            var entries = CalcEntryPoints(src);
            var collected = ReadOnlySeq<CollectedEncoding>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = collect(entries, EventLog, symbols);
                Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
            }
            else
                Warn($"{src} has no exposed methods");

            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect()
        {
            using var symbols = Dispense.composite();
            var collected = collect(CalcEntryPoints(), EventLog, symbols);
            Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser symbols, string spec)
        {
            var emitted = ReadOnlySeq<CollectedEncoding>.Empty;
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

        public ReadOnlySeq<CollectedEncoding> Collect(ApiHostUri src)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols, src);
        }

        public ReadOnlySeq<CollectedEncoding> Collect(PartId src)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols, src);
        }

        public ReadOnlySeq<CollectedEncoding> Collect(string spec)
        {
            var emitted = ReadOnlySeq<CollectedEncoding>.Empty;
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

        public void Emit(PartId part, ReadOnlySeq<ApiHostCode> src, IApiPack dst)
        {
            iter(src, code => Emit(code,dst), true);
        }

        void Emit(ApiHostCode src, IApiPack dst)
        {
            EmitHex(src.Blocks, dst.HexExtractPath(src.Host));
            EmitCsv(src.Blocks, dst.CsvExtractPath(src.Host));
        }

        public ReadOnlySeq<EncodedMember> Emit(PartId part, ReadOnlySeq<CollectedEncoding> src, IApiPack dst)
            => Emit(src, dst.HexExtractPath(part), dst.CsvExtractPath(part));

        public ByteSize EmitHex(ReadOnlySeq<CollectedEncoding> src, FS.FilePath dst)
        {
            var count = src.Count;
            var emitting = EmittingFile(dst);
            var size = ApiCode.hex(src, dst);
            EmittedFile(emitting,count);
            return size;
        }

        public ReadOnlySeq<EncodedMember> EmitCsv(ReadOnlySeq<CollectedEncoding> collected, FS.FilePath dst)
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

            TableEmit(buffer, dst);
            return buffer;
        }

        void Load(out Seq<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.Path(FS.Hex), out data).Require();
            ApiCode.index(Files.Path(FS.Csv), out index).Require();
        }

        Seq<EncodedMember> LoadMember(PartId src)
        {
            var dst = Seq<EncodedMember>.Empty;
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

        void Load(PartId src, out Seq<EncodedMember> index, out BinaryCode data)
        {
            index = LoadMember(src);
            data = LoadCode(src);
        }

        void Load(ApiHostUri src, out Seq<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.HexPath(src), out data).Require();
            ApiCode.index(Files.CsvPath(src), out index).Require();
        }

        ReadOnlySeq<EncodedMember> Emit(ReadOnlySeq<CollectedEncoding> src, FS.FilePath hex, FS.FilePath csv)
        {
            var collected = src;
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

            TableEmit(encoded, csv);
            return encoded;
        }

        [Op]
        public ReadOnlySeq<ApiHexIndexRow> EmitIndex(SortedIndex<ApiCodeBlock> src, FS.FilePath dst)
            => EmitIndex(SortedSpans.define(src.Storage), dst);

        [Op]
        ReadOnlySeq<ApiHexIndexRow> EmitIndex(SortedReadOnlySpan<ApiCodeBlock> src, FS.FilePath dst)
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