//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ApiCode : WfSvc<ApiCode>
    {
        ApiHex ApiHex => Wf.ApiHex();

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints()
            => MethodEntryPoints.create(ClrJit.members(ApiRuntimeCatalog, EventLog));

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints(ApiHostUri src)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiRuntimeCatalog.FindHost(src, out var host))
               dst = MethodEntryPoints.create(ClrJit.members(host, EventLog));
            return dst;
        }

        public ReadOnlySeq<MethodEntryPoint> CalcEntryPoints(PartId part)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(ApiRuntimeCatalog.FindPart(part, out var src))
                dst = MethodEntryPoints.create(ClrJit.members(src, EventLog));
            return dst;
        }

        public ReadOnlySeq<ApiHexIndexRow> EmitIndex(SortedIndex<ApiCodeBlock> src, IApiPack dst)
            => EmitIndex(SortedSpans.define(src.Storage), dst.Targets().Path("api.index", FileKind.Csv));

        public Index<ApiCodeRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<ApiMemberCode> src, IApiPack dst)
            => ApiHex.EmitApiCode(uri, src, dst.HexExtractPath(uri));

        public SortedIndex<ApiCodeBlock> LoadBlocks(IApiPack src)
            => blocks(src.HexExtracts());

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

        public ReadOnlySeq<CollectedEncoding> Collect(IPart part, ICompositeDispenser symbols, IApiPack dst)
        {
            var collected = Collect(symbols, part);
            Emit(part.Id, collected, dst);
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser symbols, ApiHostUri src, IApiPack dst)
        {
            var entries = CalcEntryPoints(src);
            var collected = ReadOnlySeq<CollectedEncoding>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = collect(entries, EventLog, symbols);
                Emit(collected, dst.HexExtractPath(src), dst.CsvExtractPath(src));
            }
            else
                Warn($"{src} has no exposed methods");
            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ICompositeDispenser symbols, PartId src, IApiPack dst)
        {
            var entries = CalcEntryPoints(src);
            var collected = ReadOnlySeq<CollectedEncoding>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = collect(entries, EventLog, symbols);
                Emit(collected, dst.HexExtractPath(src), dst.CsvExtractPath(src));
            }
            else
                Warn($"{src} has no exposed methods");

            return collected;
        }

        public ReadOnlySeq<CollectedEncoding> Collect(ApiHostUri src, IApiPack dst)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols, src, dst);
        }

        public ReadOnlySeq<CollectedEncoding> Collect(PartId src, IApiPack dst)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols,src, dst);
        }

        public void Emit(PartId part, ReadOnlySeq<CollectedHost> src, IApiPack dst)
        {
            iter(src, code => Emit(code,dst), true);
        }

        void Emit(CollectedHost src, IApiPack dst)
        {
            EmitHex(src.Blocks, dst.HexExtractPath(src.Host));
            EmitCsv(src.Blocks, dst.CsvExtractPath(src.Host));
        }

        public ReadOnlySeq<EncodedMember> Emit(PartId part, ReadOnlySeq<CollectedEncoding> src, IApiPack dst)
            => Emit(src, dst.HexExtractPath(part), dst.CsvExtractPath(part));

        ByteSize EmitHex(ReadOnlySeq<CollectedEncoding> src, FS.FilePath dst)
        {
            var count = src.Count;
            var emitting = EmittingFile(dst);
            var size = ApiCode.hex(src, dst);
            EmittedFile(emitting,count);
            return size;
        }

        void EmitCsv(ReadOnlySeq<CollectedEncoding> src, FS.FilePath dst)
        {
            var count = src.Count;
            var buffer = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = member(src[i]);
            var rebase = min(buffer.Select(x => (ulong)x.EntryAddress).Min(), buffer.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(buffer,i).EntryRebase = skip(buffer,i).EntryAddress - rebase;
                seek(buffer,i).TargetRebase = skip(buffer,i).TargetAddress - rebase;
            }

            TableEmit(buffer, dst);
        }

        Seq<EncodedMember> LoadMember(IApiPack src, PartId part)
        {
            var dst = Seq<EncodedMember>.Empty;
            var result = index(src.CsvExtractPath(part), out dst);
            if(result.Fail)
            {
                Write(result.Message,FlairKind.Warning);
                Errors.Throw($"{part.Format()} member load failure");
            }
            return dst;
        }

        BinaryCode LoadCode(IApiPack src, PartId part)
        {
            var dst = BinaryCode.Empty;
            var result = hex(src.HexExtractPath(part), out dst);
            if(result.Fail)
            {
                Error(result.Message);
                Errors.Throw(result.Message);
            }
            return dst;
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
        ReadOnlySeq<ApiHexIndexRow> EmitIndex(SortedReadOnlySpan<ApiCodeBlock> src, FS.FilePath dst)
        {
            var flow = EmittingTable<ApiHexIndexRow>(dst);
            var blocks = src.View;
            var count = blocks.Length;
            var buffer = alloc<ApiHexIndexRow>(count);
            var target = span(buffer);
            var parts = PartNames.Lookup();
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