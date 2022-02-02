//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    public class ApiHexCollector : AppService<ApiHexCollector>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        ApiHex ApiHex => Service(Wf.ApiHex);

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
                if(AsmHexSpecs.isJmp32(block.Encoded))
                {
                    var entry = new MethodEntryPoint(block.OpUri, MethodDisplaySig.Empty, block.BaseAddress);
                    var encoding = slice(block.Encoded.View,0, JmpRel32.InstSize);
                    var source = block.BaseAddress;
                    var token = ApiToken.create(symbols, entry, AsmRel32.target((source,JmpRel32.InstSize), encoding));
                    members.Add(new EncodedMember(token, encoding.ToArray()));
                }
            }
        }

        public Index<RawMemberCode> CollectLive(SymbolDispenser symbols, Type host)
        {
            var uri = host.ApiHostUri();
            var methods = host.DeclaredMethods();
            var count = methods.Length;
            var entries = alloc<MemoryAddress>(count);
            var located = span<RawMemberCode>(count);
            ClrJit.jit(methods, entries);
            var j=0;
            for(var i=0; i<count; i++)
            {
                var encoded = Cells.alloc(w64).Bytes;
                ref readonly var method = ref skip(methods,i);
                ref readonly var entry = ref skip(entries,i);
                ref var data = ref entry.Ref<byte>();
                ByteReader.read5(data, encoded);
                if(AsmHexSpecs.isJmp32(encoded))
                {
                    var target = AsmRel32.target((entry,  JmpRel32.InstSize), encoded);
                    ref var stub = ref seek(located,j++);
                    stub.Entry = entry;
                    stub.Target = target;
                    stub.StubCode = AsmHexCode.load(slice(encoded,0,5));
                    stub.Disp = AsmHexSpecs.disp32(encoded);
                }
            }
            return slice(located,0,j).ToArray();
        }

        public Index<EncodedMember> CollectLive(SymbolDispenser symbols)
        {
            var entries = CollectEntryPoints(symbols);
            var count = entries.Count;
            var buffer = span<byte>(Pow2.T16);
            var part = PartId.None;
            var host = ApiHostUri.Empty;
            var blocks = new ApiCodeLookup();
            var lookup = dict<ApiHostUri,MemberCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var raw = ref entries[i];
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
                {
                    extracts.Include(extracted);
                    //Babble(string.Format("Parsed {0} bytes from {1} for {0}", extracted.Size, extracted.TargetAddress,  extracted.Sig));
                }
                else
                {
                    lookup[host] = new MemberCodeExtracts(extracted);
                }
            }

            var members = Parse(lookup).Emit().Sort();
            Emit(members);
            return members;
        }

        void Emit(Index<EncodedMember> src)
        {
            var members = src;
            var count = src.Count;
            var buffer = alloc<EncodedMemberInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref src[i];
                var token = member.Token;
                ref var dst = ref seek(buffer,i);
                dst.Id = token.Id;
                dst.EntryAddress = token.EntryAddress;
                dst.TargetAddress = token.TargetAddress;
                if(token.EntryAddress != token.TargetAddress)
                    dst.Disp = AsmRel32.disp((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
                dst.CodeSize = (ushort)member.Code.Size;
                dst.Sig = token.Sig.Format();
                dst.Uri = token.Uri.Format();
                dst.Host = host(dst.Uri);
            }

            TableEmit(@readonly(buffer), EncodedMemberInfo.RenderWidths, ProjectDb.ApiTablePath<EncodedMemberInfo>());
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

        Index<RawMemberCode> CollectEntryPoints(SymbolDispenser symbols)
        {
            var running = Running(string.Format("Collecting entry points"));
            var entries = MethodEntryPoints.create(ApiJit.JitCatalog(ApiRuntimeCatalog));
            var count = entries.Count;
            var located = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                var buffer = Cells.alloc(w64).Bytes;
                ref var data = ref entry.Location.Ref<byte>();
                ByteReader.read5(data, buffer);
                ref var dst = ref seek(located,i);
                Collect(symbols, entry, out seek(located, i));
            }

            Ran(running, string.Format("Collected {0} entry points", count));
            return located;
        }

        bool Collect(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref entry.Location.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(AsmHexSpecs.isJmp32(buffer))
            {
                var encoded = AsmHexCode.load(slice(buffer,0,5));
                var target = AsmRel32.target((entry.Location, 5), encoded.Bytes);
                dst.Target = target;
                dst.StubCode = encoded;
                dst.Disp = AsmHexSpecs.disp32(encoded.Bytes);
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
    }
}