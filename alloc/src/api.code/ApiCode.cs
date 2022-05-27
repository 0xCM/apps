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

        ApiHex ApiHex => Service(Wf.ApiHex);

        new ApiCodeFiles Files => Wf.ApiCodeFiles();

        AppSvcOps AppSvc => Wf.AppSvc();

        public EncodedMembers Load(SymbolDispenser symbols)
        {
            Load(out var index, out var code);
            return members(symbols, index, code);
        }

        public EncodedMembers Load(SymbolDispenser symbols, string spec)
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

        public EncodedMembers Load(SymbolDispenser symbols, ApiHostUri src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        public EncodedMembers Load(SymbolDispenser symbols, PartId src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols)
        {
            var collected = Collect(symbols, MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            return Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                var collected = Collect(symbols, MethodEntryPoints.create(ApiJit.JitHost(host)));
                return Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
            }
            else
            {
                Errors.Throw(AppMsg.NotFound.Format(src.Format()));
                return sys.empty<EncodedMember>();
            }
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, PartId src)
        {
            if(ApiRuntimeCatalog.FindPart(src, out var part))
            {
                var collected = Collect(symbols, MethodEntryPoints.create(ApiJit.JitPart(part)));
                var emitted = Emit(collected, Files.Path(src, FS.Hex), Files.Path(src, FS.Csv));
                return emitted;
            }
            else
            {
                Errors.Throw(AppMsg.NotFound.Format(src.Format()));
                return sys.empty<EncodedMember>();
            }
        }

        public Index<EncodedMember> Collect()
        {
            using var symbols = Alloc.symbols();
            var collected = Collect(symbols, MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            return Emit(collected, Files.Path(FS.Csv), Files.Path(FS.Hex));
        }

        void Load(out Index<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.Path(FS.Hex), out data).Require();
            ApiCode.index(Files.Path(FS.Csv), out index).Require();
        }

        void Load(PartId src, out Index<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.index(Files.Path(src, FS.Csv), out index).Require();
            hex(Files.Path(src, FS.Hex), out data).Require();
        }

        void Load(ApiHostUri src, out Index<EncodedMember> index, out BinaryCode data)
        {
            ApiCode.hex(Files.Hex(src), out data).Require();
            ApiCode.index(Files.Csv(src), out index).Require();
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, string spec)
        {
            var emitted = Index<EncodedMember>.Empty;
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

        public Index<EncodedMember> Collect(ApiHostUri src)
        {
            using var symbols = Alloc.symbols();
            return Collect(symbols, src);
        }

        public Index<EncodedMember> Collect(PartId src)
        {
            using var symbols = Alloc.symbols();
            return Collect(symbols, src);
        }

        public Index<EncodedMember> Collect(string spec)
        {
            var emitted = Index<EncodedMember>.Empty;
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