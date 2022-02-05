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
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiHex ApiHex => Service(Wf.ApiHex);

        FS.FilePath MemberDataPath => ProjectDb.Api() + FS.file("api.members", FS.Hex);

        FS.FilePath MemberIndexPath => ProjectDb.ApiTablePath<EncodedMemberInfo>();


        AccessorCollector AccessorCollector => Service(() => AccessorCollector.create(Wf));

        public Index<CapturedAccessor> CaptureAccessors(SymbolDispenser symbols)
            => AccessorCollector.CaptureAccessors(symbols);

        public Outcome LoadCollected(SymbolDispenser symbols, out Index<EncodedMember> dst)
        {
            var result = Outcome.Success;
            var datasrc = MemberDataPath;
            dst = sys.empty<EncodedMember>();
            result = LoadIndex(out var index);
            result = LoadData(out var data);
            return result;
        }

        public Outcome LoadCollected(out Index<EncodedMemberInfo> index, out BinaryCode data)
        {
            var result = Outcome.Success;
            var rA = LoadIndex(out index);
            var rB = LoadData(out data);
            if(rA.Fail)
            {
                result = rA;
            }
            else
            {
                if(rB.Fail)
                    result = rB;
            }
            return result;
        }

        Outcome LoadIndex(out Index<EncodedMemberInfo> dst)
        {
            var result = Outcome.Success;
            var src = MemberIndexPath;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                result = parse(line, out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome LoadData(out BinaryCode dst)
        {
            var result = Outcome.Success;
            var cells = MemberDataPath.ReadLines().SelectMany(x => text.split(x,Chars.Space));
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
            result = DataParser.parse(skip(cells,i++), out dst.Disp);
            result = DataParser.parse(skip(cells,i++), out dst.CodeSize);
            result = DataParser.parse(skip(cells,i++), out dst.Host);
            result = DataParser.parse(skip(cells,i++), out dst.Sig);
            result = DataParser.parse(skip(cells,i++), out dst.Uri);
            return result;
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

        public Index<EncodedMember> Collect(SymbolDispenser symbols, Type host, FS.FilePath dst)
        {
            var uri = host.ApiHostUri();
            return Collect(symbols,uri, dst);
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, ApiHostUri src, FS.FilePath dst)
        {
            var entries = CollectRaw(symbols, src);
            var members = DivineCode(entries);
            Emit(members,dst);
            return members;
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, PartId src, FS.FilePath dst)
        {
            var entries = CollectRaw(symbols, src);
            var members = DivineCode(entries);
            Emit(members,dst);
            return members;
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols)
        {
            var members = Collect(symbols,MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog)));
            Emit(members);
            return members;
        }

        public Index<EncodedMember> Collect(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> src)
            => DivineCode(CollectRaw(symbols, src));

        Index<EncodedMember> DivineCode(ReadOnlySpan<RawMemberCode> src)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var lookup = dict<ApiHostUri,MemberCodeExtracts>();
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
            var datapath = MemberDataPath;
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
            TableEmit(@readonly(descriptions), EncodedMemberInfo.RenderWidths, MemberIndexPath);
        }

        static EncodedMemberInfo Describe(in EncodedMember member)
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

        static Index<EncodedMemberInfo> Describe(ReadOnlySpan<EncodedMember> src)
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

        Index<RawMemberCode> CollectRaw(SymbolDispenser symbols, ApiHostUri src)
        {
            if(ApiRuntimeCatalog.FindHost(src, out var host))
            {
                return CollectRaw(symbols, MethodEntryPoints.create(ApiJit.JitHost(host)));
            }
            else
            {
                Error(Msg.NotFound.Format(src.Format()));
                return sys.empty<RawMemberCode>();
            }
        }

        Index<RawMemberCode> CollectRaw(SymbolDispenser symbols, PartId src)
        {
            if(ApiRuntimeCatalog.FindPart(src, out var part))
            {
                return CollectRaw(symbols,MethodEntryPoints.create(ApiJit.JitPart(part)));
            }
            else
            {
                Error(Msg.NotFound.Format(src.Format()));
                return sys.empty<RawMemberCode>();
            }

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

        internal static MemoryAddress GetTargetAddress(MethodEntryPoint entry, out AsmHexCode stub)
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

        static void CollectRaw(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
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