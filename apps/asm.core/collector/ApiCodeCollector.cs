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
                    var entry = new MethodEntryPoint(block.OpUri, MethodDisplaySig.Empty, block.BaseAddress);
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
                writer.WriteLine(member.Code.Format());
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

        bool CollectRaw(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref entry.Location.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                var encoded = AsmHexCode.load(slice(buffer,0,5));
                var target = AsmRel32.target((entry.Location, 5), encoded.Bytes);
                dst.Target = target;
                dst.StubCode = encoded;
                dst.Disp = AsmRel32.disp(encoded.Bytes);
                dst.Stub = new JmpStub(entry.Location, target);
                dst.Token = ApiToken.create(symbols, entry, target);
                return true;
            }
            else
                dst.Token = ApiToken.create(symbols, entry);
            return false;
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