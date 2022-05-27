//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using Asm;

    using static core;

    public partial class ApiCode : AppService<ApiCode>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiCodeFiles ApiCodeFiles => Wf.ApiCodeFiles();

        AppSvcOps AppSvc => Wf.AppSvc();

        public EncodedMembers Load()
        {
            var result = Load(out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return members(index,code);
        }

        public EncodedMembers Encoding(string spec)
        {
            var result = Outcome.Success;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return Load(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    return Load(ApiParsers.part(spec));
            }
            else
                return Load();
        }

        public EncodedMembers Load(PartId src)
        {
            var result = Load(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return members(index,code);
        }

        public EncodedMembers Load(ApiHostUri src)
        {
            var result = Load(src, out var index, out var code);
            if(result.Fail)
                Errors.Throw(result.Message);
            return members(index,code);
        }

        /// <summary>
        /// Determines whether an operation accepts an argument of specified numeric kind
        /// </summary>
        /// <param name="src">The encoded operation</param>
        /// <param name="match">The kind to match</param>
        [Op]
        public static bool accepts(ApiCodeBlock src, NumericKind match)
            => TypeIdentity.numeric(src.Id.Components.Skip(2)).Contains(match);

        public Outcome Collect(SymbolDispenser symbols, ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                var members = Collect(symbols, MethodEntryPoints.create(ApiJit.JitHost(host)));
                Emit(members, ApiCodeFiles.Csv(src), ApiCodeFiles.Hex(src));
                return true;
            }
            else
            {
                return (false, AppMsg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                using var symbols = Alloc.symbols();
                var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitHost(host)));
                Emit(members, ApiCodeFiles.Csv(src), ApiCodeFiles.Hex(src));
                return true;
            }
            else
            {
                return (false, AppMsg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(PartId src)
        {
            if(ApiRuntimeCatalog.FindPart(src, out var part))
            {
                using var symbols = Alloc.symbols();
                var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitPart(part)));
                Emit(members, ApiCodeFiles.Path(src, FS.Csv), ApiCodeFiles.Path(src,FS.Hex));
                return true;
            }
            else
            {
                return (false, AppMsg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(SymbolDispenser symbols)
        {
            var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            Emit(members, ApiCodeFiles.Path(FS.Csv), ApiCodeFiles.Path(FS.Hex));
            return true;
        }

        public Outcome Collect(string spec)
        {
            var result = Outcome.Success;
            var members = Index<CollectedEncoding>.Empty;
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    result = Collect(ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    result = Collect(ApiParsers.part(spec));
            }
            else
                result = Collect();

            return result;
        }

        public Outcome Collect()
        {
            using var symbols = Alloc.symbols();
            var members = Collect(symbols, MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            Emit(members, ApiCodeFiles.Path(FS.Csv), ApiCodeFiles.Path(FS.Hex));
            return true;
        }

        Index<CollectedEncoding> Collect(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> src)
            => DivineCode(collect(symbols, src));

        Index<CollectedEncoding> DivineCode(ReadOnlySpan<RawMemberCode> src)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var lookup = dict<ApiHostUri,CollectedCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var raw = ref skip(src,i);
                var uri = raw.Uri;

                if(raw.StubCode != raw.Stub.Encoding)
                {
                    Error("Stub code mismatch");
                    break;
                }

                if(uri.Host != host)
                    host = uri.Host;

                var extract = slice(buffer,0, ApiExtracts.extract(raw.Target, buffer));
                var extracted = new CollectedCodeExtract(raw, extract.ToArray());
                if(lookup.TryGetValue(host, out var extracts))
                    extracts.Include(extracted);
                else
                    lookup[host] = new CollectedCodeExtracts(extracted);
            }

            return Parse(lookup).Emit();
        }

        void Emit(Index<CollectedEncoding> src, FS.FilePath index, FS.FilePath data)
        {
            var options = HexFormatSpecs.options();
            var members = src.Sort();
            var emitting = EmittingFile(data);
            using var writer = data.AsciWriter();
            var count = members.Count;
            var descriptions = alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref members[i];
                seek(descriptions,i) = describe(member);
                writer.WriteLine(member.Code.Format(options));
            }

            var rebase = min(descriptions.Select(x => (ulong)x.EntryAddress).Min(), descriptions.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(descriptions,i);
                dst.EntryRebase = dst.EntryAddress - rebase;
                dst.TargetRebase = dst.TargetAddress - rebase;
            }

            EmittedFile(emitting, count);
            AppSvc.TableEmit(descriptions, index);
        }

        EncodingLookup Parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src)
        {
            var running = Running(Msg.ParsingHosts.Format(src.Count));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new EncodingLookup();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                var parsing = Running(Msg.ParsingHostMembers.Format(host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    var result = parser.Parse(extract.TargetExtract);
                    dst.Include(new CollectedEncoding(extract.Token, parser.Parsed));
                    counter++;
                }
                Ran(parsing, Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            Ran(running, Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }

        Outcome Load(out Index<EncodedMember> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = load(ApiCodeFiles.Path(FS.Csv), out index);
            var rB = load(ApiCodeFiles.Path(FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome Load(PartId src, out Index<EncodedMember> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = load(ApiCodeFiles.Path(src, FS.Csv), out index);
            var rB = load(ApiCodeFiles.Path(src, FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome Load(ApiHostUri src, out Index<EncodedMember> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = load(ApiCodeFiles.Csv(src), out index);
            var rB = load(ApiCodeFiles.Hex(src), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static unsafe byte AccessorCode(SpanResAccessor src, out ByteBlock16 dst)
        {
            dst = ByteBlock16.Empty;
            var seg = AccessorData(src);
            var size = (byte)seg.Size;
            var data = cover<byte>(seg.BaseAddress.Pointer<byte>(), seg.Size);
            for(var i=0; i<size; i++)
                dst[i] = skip(data,i);
            return size;
        }

        [Op]
        public static MemorySeg AccessorData(SpanResAccessor src)
            => AccessorData(stub(src.Member.Location, out _));

        [Op]
        public static MemorySeg AccessorCode(SpanResAccessor src)
            => AccessorCode(stub(src.Member.Location, out _));

        /// <summary>
        /// Queries the source type for ByteSpan property getters
        /// </summary>
        /// <param name="src">The type to query</param>
        [Op]
        public void FindAccessors(SymbolDispenser symbols, Type src, List<CapturedAccessor> dst)
        {
            var candidates = src.StaticProperties()
                 .Ignore()
                  .WithPropertyType(ResAccessorTypes)
                  .Select(p => p.GetGetMethod(true))
                  .Where(m  => m != null)
                  .Concrete();
            var count = candidates.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var candidate = ref skip(candidates,i);
                var target = ClrJit.jit(candidate);


                //var target = ApiCodeCollector.GetTargetAddress(ClrJit.jit(candidate), out _);
            }
        }

        [Op]
        static SpanResKind ResKind(Type match)
        {
            ref readonly var src = ref first(span(ResAccessorTypes));
            var kind = SpanResKind.None;
            if(skip(src,0).Equals(match))
                kind = SpanResKind.ByteSpan;
            else if(skip(src,1).Equals(match))
                kind = SpanResKind.CharSpan;
            return kind;
        }

        static Type ByteSpanAcessorType
            => typeof(ReadOnlySpan<byte>);

        static Type CharSpanAcessorType
            => typeof(ReadOnlySpan<char>);

        static Type[] ResAccessorTypes
            => new Type[]{ByteSpanAcessorType, CharSpanAcessorType};

        static unsafe bool IsAccessor(MemoryAddress target)
        {
            var data = cover(target.Pointer<byte>(), 24);
            var result = true;
            result &= skip(data,0) == 0x48;
            result &= skip(data,1) == 0xb8;
            result &= skip(data,10) == 0x48;
            result &= skip(data,11) == 0x89;
            result &= skip(data,20) == 0x48;
            result &= skip(data,21) == 0x8b;
            return result;
        }

        // 24 bytes: [48 b8 c0 f3 bf 2b 38 01 00 00] [48 89 01] [c7 41 08 20 00 00 00] [48 8b c1 c3]
        // 0 | 00 | mov r64,imm64       # 10        | [48 b8] [c0 f3 bf 2b 38 01 00 00]
        // 1 | 10 | mov [rcx],rax       # 3         | 48 89 01
        // 2 | 13 | mov r/m32, imm32    # 7         | [c7 41 08] 20 00 00 00
        // 3 | 20 | mov r64, r/m64      # 3         | 48 8b c1
        // 4 | 23 ret                   # 1         | c3
        static unsafe MemorySeg AccessorData(MemoryAddress target)
        {
            var data = cover(target.Pointer<byte>(), 24);
            var address = @as<MemoryAddress>(slice(data,2,8));
            var size = @as<uint>(slice(data, 13 + 3, 4));
            return new MemorySeg(address, size);
        }

        static unsafe MemorySeg AccessorCode(MemoryAddress target)
            => new MemorySeg(target, 24);

        class EncodingLookup
        {
            readonly ConcurrentDictionary<uint,CollectedEncoding> Data;

            public EncodingLookup()
            {
                Data = new();
            }

            public bool Include(in CollectedEncoding src)
                => Data.TryAdd(src.Token.EntryId,src);

            public Index<CollectedEncoding> Emit(bool clear = true)
            {
                var members = Data.Values.Array();
                if(clear)
                    Data.Clear();
                return members;
            }
        }
    }
}