//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public class EncodingCollector : AppService<EncodingCollector>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiDataPaths DataPaths => Service(Wf.ApiDataPaths);

        public Index<CapturedAccessor> CaptureAccessors(SymbolDispenser symbols)
        {
            return sys.empty<CapturedAccessor>();
        }

        public Outcome Collect(SymbolDispenser symbols, ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                var members = Collect(symbols, MethodEntryPoints.create(ApiJit.JitHost(host)));
                Emit(members, DataPaths.Path(src, FS.Csv), DataPaths.Path(src, FS.Hex));
                return true;
            }
            else
            {
                return (false, Msg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                using var symbols = Alloc.symbols();
                var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitHost(host)));
                Emit(members, DataPaths.Path(src,FS.Csv), DataPaths.Path(src,FS.Hex));
                return true;
            }
            else
            {
                return (false,Msg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(PartId src)
        {
            if(ApiRuntimeCatalog.FindPart(src, out var part))
            {
                using var symbols = Alloc.symbols();
                var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitPart(part)));
                Emit(members, DataPaths.Path(src, FS.Csv), DataPaths.Path(src,FS.Hex));
                return true;
            }
            else
            {
                return (false,Msg.NotFound.Format(src.Format()));
            }
        }

        public Outcome Collect(SymbolDispenser symbols)
        {
            var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            Emit(members, DataPaths.Path(FS.Csv), DataPaths.Path(FS.Hex));
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
            var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            Emit(members, DataPaths.Path(FS.Csv), DataPaths.Path(FS.Hex));
            return true;
        }

        Index<CollectedEncoding> Collect(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> src)
            => DivineCode(CollectRaw(symbols, src));


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
            var descriptions = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref members[i];
                seek(descriptions,i) = Describe(member);
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
            TableEmit(@readonly(descriptions), EncodedMemberInfo.RenderWidths, index);
        }

        static EncodedMemberInfo Describe(in CollectedEncoding member)
        {
            var token = member.Token;
            var dst = new EncodedMemberInfo();
            dst.Id = token.Id;
            dst.EntryAddress = token.EntryAddress;
            dst.TargetAddress = token.TargetAddress;
            if(token.EntryAddress != token.TargetAddress)
            {
                dst.Disp = AsmRel32.disp((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
                dst.StubAsm = string.Format("jmp near ptr {0:x}h", (int)AsmRel32.reltarget(dst.Disp));
            }
            dst.CodeSize = (ushort)member.Code.Size;
            dst.Sig = token.Sig.Format();
            dst.Uri = token.Uri.Format();
            var result = ApiUri.parse(dst.Uri, out var uri);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(uri), dst.Uri));

            dst.Host = uri.Host.Format();
            return dst;
        }

        EncodedMembers Parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src)
        {
            var running = Running(Msg.ParsingHosts.Format(src.Count));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new EncodedMembers();
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

        static Index<RawMemberCode> CollectRaw(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> entries)
        {
            var count = entries.Length;
            var code = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var buffer = Cells.alloc(w64).Bytes;
                ref var data = ref entry.Location.Ref<byte>();
                ByteReader.read5(data, buffer);
                ref var dst = ref seek(code,i);
                CollectRaw(symbols, entry, out seek(code, i));
            }
            return code;
        }

        internal static MemoryAddress GetTargetAddress(MemoryAddress src, out AsmHexCode stub)
        {
            stub = AsmHexCode.Empty;
            var target = src;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref src.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = asm.asmhex(slice(buffer,0,5));
                target = AsmRel32.target((src, 5), stub.Bytes);
            }
            return target;
        }

        static void CollectRaw(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var target = GetTargetAddress(entry.Location, out dst.StubCode);
            dst.Target = target;
            if(target != entry.Location)
            {
                dst.Disp = AsmRel32.disp(dst.StubCode.Bytes);
                dst.Stub = new JmpStub(entry.Location, target);
                dst.Token = ApiToken.create(symbols, entry, target);
            }
            else
            {
                dst.Token = ApiToken.create(symbols, entry);
            }
        }

        static Outcome InferHost(FS.FileName src, FS.FileExt ext, out ApiHostUri host)
        {
            var components = @readonly(src.Name.Text.Remove(string.Format(".{0}", ext)).SplitClean(Chars.Dot));
            var count = components.Length;
            if(count >= 2)
            {
                if(ApiParsers.part(first(components), out var part))
                {
                    host =  new ApiHostUri(part, slice(components,1).Join(Chars.Dot));
                    return true;
                }
            }
            host = ApiHostUri.Empty;
            return false;
        }

        Outcome LoadCollected(out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(PartId src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src,FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src,FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadCollected(ApiHostUri src, out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(DataPaths.Path(src, FS.Csv), out index);
            var rB = LoadData(DataPaths.Path(src, FS.Hex), out data);
            if(rA.Fail)
                result = rA;
            else
                result = rB;
            return result;
        }

        Outcome LoadIndex(FS.FilePath src, out Index<EncodedMemberInfo> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i + 1];
                result = parse(line, out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome LoadData(FS.FilePath path, out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = path.ReadLines().SelectMany(x => text.split(x,Chars.Space));
            var count = cells.Count;
            var data = alloc<byte>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref cells[i];
                result = HexParser.parse8u(cell, out seek(data,i));
                if(result.Fail)
                    break;
            }
            if(result)
                dst = data;
            else
                dst = BinaryCode.Empty;
            return result;
        }

        static Outcome parse(string src, out EncodedMemberInfo dst)
        {
            const byte FieldCount = EncodedMemberInfo.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false, AppMsg.CsvDataMismatch.Format(FieldCount,count, src));

            var result = Outcome.Success;
            var i=0;
            result = DataParser.parse(skip(cells,i++), out dst.Id);
            result = DataParser.parse(skip(cells,i++), out dst.EntryAddress);
            result = DataParser.parse(skip(cells,i++), out dst.EntryRebase);
            result = DataParser.parse(skip(cells,i++), out dst.TargetAddress);
            result = DataParser.parse(skip(cells,i++), out dst.TargetRebase);
            result = DataParser.parse(skip(cells,i++), out dst.StubAsm);
            result = Disp32.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            dst.Host = text.trim(skip(cells,i++));
            dst.Sig = text.trim(skip(cells,i++));
            dst.Uri = text.trim(skip(cells,i++));
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
            => AccessorData(EncodingCollector.GetTargetAddress(src.Member.Location, out _));

        [Op]
        public static MemorySeg AccessorCode(SpanResAccessor src)
            => AccessorCode(EncodingCollector.GetTargetAddress(src.Member.Location, out _));

        static CapturedAccessor capture(SymbolDispenser symbols, SpanResAccessor src)
        {
            var target = EncodingCollector.GetTargetAddress(src.Member.Location, out _);
            var token = ApiToken.create(symbols, src.Member, target);
            var member = new CollectedEncoding(token, AccessorCode(target).View.ToArray());
            return new CapturedAccessor(member, AccessorData(target), src.Kind);
        }

        static Index<CapturedAccessor> capture(SymbolDispenser symbols, ReadOnlySpan<SpanResAccessor> accessors)
        {
            var count = accessors.Length;
            var buffer = alloc<CapturedAccessor>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = capture(symbols, skip(accessors,i));
            return buffer;
        }

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
                var location = ClrJit.jit(candidate);
                //var target = ApiCodeCollector.GetTargetAddress(ClrJit.jit(candidate), out _);
            }

            // return src.StaticProperties()
            //      .Ignore()
            //       .WithPropertyType(ResAccessorTypes)
            //       .Select(p => p.GetGetMethod(true))
            //       .Where(m  => m != null)
            //       .Concrete()
            //       .Select(x => new SpanResAccessor(x, ResKind(x.ReturnType)));
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
        class EncodedMembers
        {
            readonly ConcurrentDictionary<uint,CollectedEncoding> Data;

            public EncodedMembers()
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