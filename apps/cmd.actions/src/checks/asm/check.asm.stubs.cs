//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;


    public class EncodedMember
    {
        public OpUri Name;

        public LocatedSymbol EntryPoint;

        public LocatedSymbol CodeBase;

        public BinaryCode Code;
    }



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

        [CmdOp("check/stubs/live")]
        Outcome CheckLiveStubs(CmdArgs args)
        {
            var stubs = JmpStubs.SearchLive();
            var count = stubs.Count;
            var unparsed = span<byte>(Pow2.T16);
            var parsed = alloc<byte>(Pow2.T16);
            var parser = EncodingParser.create(parsed);
            var part = PartId.None;
            var host = ApiHostUri.Empty;
            var blocks = new ApiCodeLookup();
            for(var i=0; i<count; i++)
            {
                unparsed.Clear();
                parsed.Clear();
                ref readonly var stub = ref stubs[i];
                ref readonly var uri = ref stub.Name;
                part = uri.Part;
                host = uri.Host;
                var extract = slice(unparsed,0, ApiExtracts.extract(stub.Target, unparsed));
                var result = parser.Parse(extract);
                if(result == EncodingParserState.Succeeded)
                {
                    var encoded = parser.Parsed;
                    var size = encoded.Length;
                    var block = new ApiCodeBlock(stub.Target.Location, uri, encoded);
                    if(blocks.TryAdd(uri,block))
                    {
                        Write(string.Format("{0} -> {1} [{2}] ({3})", stub.Entry.Location, stub.Target, (ByteSize)size, uri));
                    }
                    else
                    {
                        Warn("Duplicate key");
                    }
                }

            }
            return true;
        }

        [CmdOp("check/stubs/captured")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            void Api()
            {
                var stubs = JmpStubs.SearchCaptured(ApiHostUri.from(typeof(cpu)));
                foreach(var stub in stubs)
                {
                    var jmp = stub.ToModel();
                    Write(jmp.Format());
                }
            }

            void Search()
            {
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                var stubs = JmpStubs.SearchLive(host);
                Write(stubs.View, JmpStub.RenderWidths);
                var imap = Clr.imap(host,contract);
                Write(imap.Format());
            }

            void Encode()
            {
                var stubs = JmpStubs.create(Wf);
                if(stubs.Create<ulong>(0))
                {
                    var encoded = stubs.EncodeDispatch(0);
                    Write(encoded.FormatHexData());
                }
            }

            Api();
            Search();
            Encode();

            return true;
        }

        static Index<ApiHostUri> NestedHosts(Type src)
        {
            var dst = list<ApiHostUri>();
            var nested = @readonly(src.GetNestedTypes());
            var count = nested.Length;
            for(var i=0; i<count; i++)
            {
                var candidate = skip(nested,i);
                var uri = candidate.ApiHostUri();
                if(uri.IsNonEmpty)
                    dst.Add(uri);
            }
            return dst.ToArray();
        }

    }
}