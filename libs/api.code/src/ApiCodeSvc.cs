//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ApiCodeSvc : WfSvc<ApiCodeSvc>
    {
        ApiHex ApiHex => Wf.ApiHex();

        public ReadOnlySeq<ApiHexIndexRow> EmitHexIndex(SortedIndex<ApiCodeBlock> src, IApiPack dst)
            => EmitIndex(SortedSpans.define(src.Storage), dst.Targets().Path("api.index", FileKind.Csv));

        public Index<ApiCodeRow> EmitApiHex(ApiHostUri uri, ReadOnlySpan<MemberCodeBlock> src, IApiPack dst)
            => ApiHex.EmitApiCode(uri, src, dst.HexExtractPath(uri));

        public ReadOnlySeq<ApiEncoded> Collect(IPart part, ICompositeDispenser symbols, IApiPack dst)
        {
            var collected = ApiCode.collect(symbols, part, EventLog);
            Emit(part.Id, collected, dst);
            return collected;
        }

        public ReadOnlySeq<EncodedMember> Emit(PartId part, ReadOnlySeq<ApiEncoded> src, IApiPack dst)
            => Emit(src, dst.HexExtractPath(part), dst.CsvExtractPath(part));

        public ReadOnlySeq<ApiEncoded> Collect(ICompositeDispenser symbols, ApiHostUri src, IApiPack dst)
        {
            var entries = ApiCode.entries(ApiRuntimeCatalog, src, EventLog);
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = ApiCode.gather(entries, symbols, EventLog);
                Emit(collected, dst.HexExtractPath(src), dst.CsvExtractPath(src));
            }
            else
                Warn($"{src} has no exposed methods");
            return collected;
        }

        public ReadOnlySeq<ApiEncoded> Collect(ICompositeDispenser symbols, PartId src, IApiPack dst)
        {
            var entries = ApiCode.entries(ApiRuntimeCatalog, src, EventLog);
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            if(entries.IsNonEmpty)
            {
                collected = ApiCode.gather(entries, symbols, EventLog);
                Emit(collected, dst.HexExtractPath(src), dst.CsvExtractPath(src));
            }
            else
                Warn($"{src} has no exposed methods");

            return collected;
        }

        public ReadOnlySeq<ApiEncoded> Collect(ApiHostUri src, IApiPack dst)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols, src, dst);
        }

        public ReadOnlySeq<ApiEncoded> Collect(PartId src, IApiPack dst)
        {
            using var symbols = Dispense.composite();
            return Collect(symbols,src, dst);
        }

        // public void Emit(PartId part, IEnumerable<CollectedHost> src, IApiPack dst, bool pll)
        //     => iter(src, code => Emit(code,dst), pll);

        public void Emit(PartId part, ReadOnlySpan<CollectedHost> src, IApiPack dst, bool pll)
            => iter(src, code => Emit(code,dst), pll);

        void Emit(CollectedHost src, IApiPack dst)
        {
            EmitHex(src.Blocks, dst.HexExtractPath(src.Host));
            //EmitCsv(src.Blocks, dst.CsvExtractPath(src.Host));
        }

        ByteSize EmitHex(ReadOnlySeq<ApiEncoded> src, FS.FilePath dst)
        {
            var count = src.Count;
            var emitting = EmittingFile(dst);
            var size = ApiCode.hex(src, dst);
            EmittedFile(emitting,count);
            return size;
        }


        ReadOnlySeq<EncodedMember> Emit(ReadOnlySeq<ApiEncoded> src, FS.FilePath hex, FS.FilePath csv)
        {
            var collected = src;
            var count = collected.Count;
            var emitting = EmittingFile(hex);
            var size = ApiCode.hex(collected, hex);
            EmittedFile(emitting,count);
            var encoded = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(encoded,i) = ApiCode.member(collected[i]);
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