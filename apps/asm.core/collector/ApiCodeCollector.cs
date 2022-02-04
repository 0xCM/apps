//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public class ApiCodeCollector : AppService<ApiCodeCollector>
    {

        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<byte> definition(SpanResAccessor src)
        {
            const byte size = 29;
            var block = ByteBlocks.alloc(w32);
            var storage = block.Bytes;
            var data = cover<byte>(src.Member.Location.Pointer<byte>(), 29);
            for(var i=0; i<size; i++)
                seek(storage,i) = skip(data,i);
            return slice(data,0,size);
        }

        /// <remarks>
        /// Each method is 29 bytes in length and similar to:
        /// 0000h nop dword ptr [rax+rax]        ; NOP r/m32           | 0F 1F /0        | 5   | 0f 1f 44 00 00
        /// 0005h mov rax,228ab7d8e44h           ; MOV r64, imm64      | REX.W B8+ro io  | 10  | 48 b8 44 8e 7d ab 28 02 00 00
        /// 000fh mov [rcx],rax                  ; MOV r/m64, r64      | REX.W 89 /r     | 3   | 48 89 01
        /// 0012h mov dword ptr [rcx+8],91h      ; MOV r/m32, imm32    | C7 /0 id        | 7   | c7 41 08 91 00 00 00
        /// 0019h mov rax,rcx                    ; MOV r64, r/m64      | REX.W 8B /r     | 3   | 48 8b c1
        /// 001ch ret                            ; RET                 | C3              | 1   | c3
        /// </remarks>
        [Op]
        public static MemorySeg capture(SpanResAccessor accessor)
        {
            var def = definition(accessor);
            var address = MemoryAddress.Zero;
            var size = ByteSize.Zero;
            for(var i=0; i<RegSegCount; i++)
            {
                if(i == 1)
                {
                    // MOV r64,imm64 : REX.W B8+ro io => [48 b8] [lo lo lo lo hi hi hi hi]
                    var start = skip(SpanResSegments, i) + 2;
                    var width = skip(SpanResSegments, i+1) - start;
                    address = bw64u(slice(def, start,width));
                }
                else if(i==3)
                {
                    // MOV r/m32, imm32 : C7 /0 id => [c7 41 08] [lo lo hi hi]
                    var start = skip(SpanResSegments, i) + 3;
                    var width = skip(SpanResSegments, i+1) - start;
                    size = bw32u(slice(def, start, width));
                }
            }

            return new MemorySeg(address, size);
        }


        const byte RegSegCount = 6;


        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiHex ApiHex => Service(Wf.ApiHex);

        public Index<EncodedMember> CollectCaptured(SymbolDispenser symbols)
        {
            var result = Outcome.Success;
            var dst = list<EncodedMember>();
            var paths = ApiHex.ParsedExtracts();
            foreach(var path in paths)
            {
                result = InferHost(path.FileName, FS.PCsv, out var host);
                if(result.Fail)
                {
                    result = (false,string.Format("Unable to infer host from {0}", path.ToUri()));
                    break;
                }
            }

            if(result.Fail)
            {
                Error(result.Message);
                return sys.empty<EncodedMember>();
            }

            return dst.ToArray();
        }

        public Index<EncodedMember> CollectCaptured(SymbolDispenser symbols, ApiHostUri host)
        {
            var src = ApiHex.ParsedExtracts(host);
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return sys.empty<EncodedMember>();
            }

            var members = list<EncodedMember>();
            CollectCaptured(symbols, host, members);
            return members.ToArray();
        }

        public Index<EncodedMember> CollectLive(SymbolDispenser symbols, Type host, FS.FilePath dst)
        {
            var uri = host.ApiHostUri();
            return CollectLive(symbols,uri, dst);
        }

        public Index<EncodedMember> CollectLive(SymbolDispenser symbols, ApiHostUri uri, FS.FilePath dst)
        {
            var entries = CollectRaw(symbols, uri);
            var members = DivineCode(entries);
            Emit(members,dst);
            return members;
        }

        public Index<EncodedMember> CollectLive(SymbolDispenser symbols)
        {
            var src = CollectRaw(symbols);
            var count = src.Count;
            var buffer = span<byte>(Pow2.T16);
            var part = PartId.None;
            var host = ApiHostUri.Empty;
            var lookup = dict<ApiHostUri,MemberCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var raw = ref src[i];
                var uri = raw.Uri;

                if(raw.StubCode != raw.Stub.Encoding)
                {
                    Error("Stub code mismatch");
                    break;
                }

                if(uri.Host != host)
                    host = uri.Host;

                var extract = slice(buffer,0, ApiExtracts.extract(raw.Target, buffer));
                var extracted = new MemberCodeExtract(raw, extract.ToArray());
                if(lookup.TryGetValue(host, out var extracts))
                    extracts.Include(extracted);
                else
                    lookup[host] = new MemberCodeExtracts(extracted);
            }

            var members = Parse(lookup).Emit();
            Emit(members);
            return members;
        }

        Index<EncodedMember> DivineCode(Index<RawMemberCode> src)
        {
            var count = src.Count;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var lookup = dict<ApiHostUri,MemberCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var raw = ref src[i];
                var uri = raw.Uri;

                if(raw.StubCode != raw.Stub.Encoding)
                {
                    Error("Stub code mismatch");
                    break;
                }

                if(uri.Host != host)
                    host = uri.Host;

                var extract = slice(buffer,0, ApiExtracts.extract(raw.Target, buffer));
                var extracted = new MemberCodeExtract(raw, extract.ToArray());
                if(lookup.TryGetValue(host, out var extracts))
                    extracts.Include(extracted);
                else
                    lookup[host] = new MemberCodeExtracts(extracted);
            }

            return Parse(lookup).Emit();
        }

        void CollectCaptured(SymbolDispenser symbols, ApiHostUri host, List<EncodedMember> members)
        {
            var src = ApiHex.ParsedExtracts(host);
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return;
            }

            var blocks = ApiHex.ReadBlocks(src);
            var count = blocks.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                if(JmpRel32.test(block.Encoded))
                {
                    var entry = new MethodEntryPoint(block.BaseAddress, block.OpUri, MethodDisplaySig.Empty);
                    var encoding = slice(block.Encoded.View,0, JmpRel32.InstSize);
                    var source = block.BaseAddress;
                    var token = ApiToken.create(symbols, entry, AsmRel32.target((source,JmpRel32.InstSize), encoding));
                    members.Add(new EncodedMember(token, encoding.ToArray()));
                }
            }
        }

        public Index<CapturedAccessor> CaptureAccessors(SymbolDispenser symbols)
        {
            var accessors = ApiRuntimeCatalog.SpanResAccessors;
            var count = accessors.Length;
            var buffer = alloc<CapturedAccessor>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = CaptureAccessor(symbols, skip(accessors,i));
            return buffer;
        }

        CapturedAccessor CaptureAccessor(SymbolDispenser symbols, SpanResAccessor src)
        {
            var target = GetTargetAddress(src.Member, out var stubcode);
            var token = ApiToken.create(symbols, src.Member, target);
            var seg = accessor(target);
            var code = seg.View.ToArray();
            var encoded = new EncodedMember(token,code);
            return new CapturedAccessor(encoded, src.Kind);
        }

        static ReadOnlySpan<byte> SpanResSegments
            => new byte[RegSegCount]{0,5,0xf,0x12,0x18,0x1c};

        // 24 bytes: [48 b8 c0 f3 bf 2b 38 01 00 00] [48 89 01] [c7 41 08 20 00 00 00] [48 8b c1 c3]
        // 0 | 00 | mov r64,imm64       # 10        | [48 b8] [c0 f3 bf 2b 38 01 00 00]
        // 1 | 10 | mov [rcx],rax       # 3         | 48 89 01
        // 2 | 13 | mov r/m32, imm32    # 7         | [c7 41 08] 20 00 00 00
        // 3 | 20 | mov r64, r/m64      # 3         | 48 8b c1
        // 4 | 23 ret                   # 1         | c3
        static unsafe MemorySeg accessor(MemoryAddress target)
        {
            var data = cover(target.Pointer<byte>(), 24);
            var address = @as<MemoryAddress>(slice(data,2,8));
            var size = @as<uint>(slice(data, 13 + 3, 4));
            return new MemorySeg(address,size);
        }

        Index<EncodedMemberInfo> Emit(ReadOnlySpan<EncodedMember> src, FS.FilePath path)
        {
            var descriptions = Describe(src).Sort();
            TableEmit(descriptions.View, EncodedMemberInfo.RenderWidths, path);
            return descriptions;
        }

        void Emit(Index<EncodedMember> src)
        {
            var options = HexFormatSpecs.options();
            var members = src.Sort();
            var datapath = ProjectDb.Api() + FS.file("api.members", FS.Hex);
            var emitting = EmittingFile(datapath);
            using var writer = datapath.AsciWriter();
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
            TableEmit(@readonly(descriptions), EncodedMemberInfo.RenderWidths, ProjectDb.ApiTablePath<EncodedMemberInfo>());
        }

        EncodedMemberInfo Describe(in EncodedMember member)
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
            dst.Host = host(dst.Uri);
            return dst;
        }

        Index<EncodedMemberInfo> Describe(ReadOnlySpan<EncodedMember> src)
        {
            var members = src;
            var count = src.Length;
            var buffer = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = Describe(skip(src,i));
            return buffer;
        }

        EncodedMembers Parse(Dictionary<ApiHostUri,MemberCodeExtracts> src)
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
                    dst.Include(new EncodedMember(extract.Token, parser.Parsed));
                    counter++;
                }
                Ran(parsing, Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            Ran(running, Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }

        Index<RawMemberCode> CollectRaw(SymbolDispenser symbols)
        {
            var running = Running(Msg.CollectingEntryPoints.Format());
            var entries = MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog));
            Ran(running, Msg.CollectedEntryPoints.Format(entries.Count));
            return CollectRaw(symbols, entries);
        }

        Index<RawMemberCode> CollectRaw(SymbolDispenser symbols, ApiHostUri uri)
        {
            if(ApiRuntimeCatalog.FindHost(uri, out var host))
            {
                var entries = MethodEntryPoints.create(ApiJit.JitHost(host));
                return CollectRaw(symbols,entries);
            }
            else
            {
                Error(string.Format("Host '{0}' not found", uri));
                return sys.empty<RawMemberCode>();
            }
        }

        Index<RawMemberCode> CollectRaw(SymbolDispenser symbols, Index<MethodEntryPoint> entries)
        {
            var count = entries.Count;
            var code = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                var buffer = Cells.alloc(w64).Bytes;
                ref var data = ref entry.Location.Ref<byte>();
                ByteReader.read5(data, buffer);
                ref var dst = ref seek(code,i);
                CollectRaw(symbols, entry, out seek(code, i));
            }
            return code;
        }

        MemoryAddress GetTargetAddress(MethodEntryPoint entry, out AsmHexCode stub)
        {
            stub = AsmHexCode.Empty;
            var target = entry.Location;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref entry.Location.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = AsmHexCode.load(slice(buffer,0,5));
                target = AsmRel32.target((entry.Location, 5), stub.Bytes);
            }
            return target;
        }

        void CollectRaw(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var target = GetTargetAddress(entry, out dst.StubCode);
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

        static string host(string uri)
        {
            const string UriMarker = "://";
            var i = text.index(uri,UriMarker);
            if(i > 0)
            {
                var j = text.index(uri, Chars.Question);
                if(j > i)
                    return text.inside(uri,i + UriMarker.Length - 1, j);
            }
            return uri;
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
    }
}