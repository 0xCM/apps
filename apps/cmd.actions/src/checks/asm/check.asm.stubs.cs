//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [Free]
        public interface ICalc64
        {
            ulong Add(ulong a, ulong b);

            ulong Sub(ulong a, ulong b);

            ulong Mul(ulong a, ulong b);

            ulong Mod(ulong a, ulong b);
        }

        public readonly struct Calc64 : ICalc64
        {
            [Op]
            public ulong Add(ulong a, ulong b)
                => math.add(a,b);

            [Op]
            public ulong Mod(ulong a, ulong b)
                => math.mod(a,b);

            [Op]
            public ulong Mul(ulong a, ulong b)
                => math.mul(a,b);

            [Op]
            public ulong Sub(ulong a, ulong b)
                => math.sub(a,b);
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

        [CmdOp("check/capture")]
        Outcome CheckLiveStubs(CmdArgs args)
        {
            using var symbols = SymbolDispenser.alloc();
            var lively = JmpStubs.SearchLive(symbols);
            var count = lively.Count;
            var unparsed = span<byte>(Pow2.T16);
            var part = PartId.None;
            var host = ApiHostUri.Empty;
            var blocks = new ApiCodeLookup();
            var extracts = dict<ApiHostUri,MemberCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                unparsed.Clear();
                ref readonly var live = ref lively[i];
                var uri = live.Uri;

                if(live.StubCode != live.Stub.Encoding)
                {
                    Error("Stub code mismatch");
                    break;
                }

                if(uri.Host != host)
                {
                    if(host.IsNonEmpty)
                        Status(string.Format("Collected {0}", host));
                    host = uri.Host;
                }

                var extract = slice(unparsed,0, ApiExtracts.extract(live.Target, unparsed));
                var extracted = new MemberCodeExtract(live, extract.ToArray());
                if(extracts.TryGetValue(host, out var hosted))
                {
                    hosted.Include(extracted);
                }
                else
                {
                    extracts[host] = new MemberCodeExtracts(extracted);
                }
            }

            var members = Parse(extracts).Emit().Sort();
            Emit(members);
            return true;
        }

        static string host(string uri)
        {
            const string UriMarker = "://";
            var i = text.index(uri,UriMarker);
            if(i > 0)
            {
                var j = text.index(uri, Chars.Question);
                if(j > i)
                {
                    var host = text.inside(uri,i + UriMarker.Length - 1, j);
                    return host;
                }
            }
            return uri;
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
                {
                    dst.Disp = AsmValues.disp32(token.EntryAddress + JmpRel32.InstSize, token.TargetAddress);
                }
                dst.CodeSize = (ushort)member.Code.Size;
                dst.Sig = token.Sig.Format();
                dst.Uri = token.Uri.Format();
                dst.Host = host(dst.Uri);
            }

            TableEmit(@readonly(buffer), EncodedMemberInfo.RenderWidths, ProjectDb.ApiTablePath<EncodedMemberInfo>());
        }


        [CmdOp("check/stubs/dispatch")]
        Outcome CheckStubDispatch(CmdArgs args)
        {
            var stubs = JmpStubs.create(Wf);
            if(stubs.Create<ulong>(0))
            {
                var encoded = stubs.EncodeDispatch(0);
                Write(encoded.FormatHexData());
            }

            return true;

        }

        [CmdOp("check/stubs/captured")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            void Api()
            {
                using var symbols = SymbolDispenser.alloc();
                var stubs = JmpStubs.SearchCaptured(symbols, ApiHostUri.from(typeof(cpu)));
                foreach(var stub in stubs)
                {
                    var jmp = AsmRel32.from(stub);
                    Write(jmp.Format());
                }
            }

            void Search()
            {
                using var symbols = SymbolDispenser.alloc();
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                var stubs = JmpStubs.SearchLive(symbols,host);
                //Write(stubs.View, LiveMemberCode.RenderWidths);
                var imap = Clr.imap(host,contract);
                Write(imap.Format());
            }

            Api();
            Search();

            return true;
        }
    }
}