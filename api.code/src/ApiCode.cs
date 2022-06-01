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

        ApiHex ApiHex => Wf.ApiHex();

        ApiMd ApiMd => Wf.ApiMetadata();

        new ApiCodeFiles Files => Wf.ApiCodeFiles();

        AppSvcOps AppSvc => Wf.AppSvc();

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
    }
}