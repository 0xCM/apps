//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;
    using Asm;

    using static core;

    public class EncodedMembers
    {
        readonly ConcurrentDictionary<OpUri,EncodedMember> Data;

        public EncodedMembers()
        {
            Data = new();
        }

        public bool Include(EncodedMember src)
        {
            return Data.TryAdd(src.Name, src);
        }

        public ConstLookup<OpUri,EncodedMember> ToLookup()
            => Data;
    }


    public class EncodedMember
    {
        public OpUri Name;

        public LocatedSymbol Source;

        public LocatedSymbol Target;

        public BinaryCode Code;

        public EncodingParserState ResultCode;

        public EncodedMember(OpUri name, LocatedSymbol source, LocatedSymbol target, EncodingParserState result, BinaryCode code)
        {
            Name = name;
            Source = source;
            Target = target;
            ResultCode = result;
            Code = code;
        }
    }

    public class EncodedMemberExtract
    {
        public OpUri Name;

        public LocatedSymbol Source;

        public LocatedSymbol Target;

        public BinaryCode RawCode;



        public EncodedMemberExtract(OpUri name, LocatedSymbol source, LocatedSymbol target, BinaryCode code)
        {
            Name = name;
            Source = source;
            Target = target;
            RawCode = code;
        }
    }

    public class EncodedMemberExtracts : IEnumerable<EncodedMemberExtract>
    {
        readonly List<EncodedMemberExtract> Data;

        public EncodedMemberExtracts(params EncodedMemberExtract[] src)
        {
            Data = new(src);
        }

        public IEnumerator<EncodedMemberExtract> GetEnumerator()
        {
            return ((IEnumerable<EncodedMemberExtract>)Data).GetEnumerator();
        }

        public void Include(EncodedMemberExtract src)
        {
            Data.Add(src);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Data).GetEnumerator();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }
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

        EncodedMembers Parse(Dictionary<ApiHostUri,EncodedMemberExtracts> src)
        {
            var running = Running(string.Format("Parsing members from {0} hosts", src.Count));
            var buffer = alloc<byte>(Pow2.T13);
            var parser = EncodingParser.create(buffer);
            var dst = new EncodedMembers();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                var parsing = Running(string.Format("Parsing {0} ", host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    var result = parser.Parse(extract.RawCode);
                    dst.Include(new EncodedMember(extract.Name, extract.Source, extract.Target, result, parser.Parsed));
                    counter++;
                }
                Ran(parsing, string.Format("Parsed {0} {1} members", host, extracts.Count));
            }

            Ran(running, string.Format("Parsed {0} members", counter));
            return dst;

        }

        [CmdOp("check/capture")]
        Outcome CheckLiveStubs(CmdArgs args)
        {
            var stubs = JmpStubs.SearchLive();
            var count = stubs.Count;
            var unparsed = span<byte>(Pow2.T16);
            var part = PartId.None;
            var host = ApiHostUri.Empty;
            var blocks = new ApiCodeLookup();
            var extracts = dict<ApiHostUri,EncodedMemberExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                unparsed.Clear();
                ref readonly var stub = ref stubs[i];
                ref readonly var uri = ref stub.Name;

                if(uri.Host != host)
                {
                    if(host.IsNonEmpty)
                        Status(string.Format("Collected {0}", host));
                    host = uri.Host;
                }

                part = uri.Part;
                var extract = slice(unparsed,0, ApiExtracts.extract(stub.Target, unparsed));
                var extracted = new EncodedMemberExtract(uri, stub.Entry, stub.Target, extract.ToArray());
                if(extracts.TryGetValue(host, out var hosted))
                {
                    hosted.Include(extracted);
                }
                else
                {
                    extracts[host] = new EncodedMemberExtracts(extracted);
                }
            }

            var lookup = Parse(extracts).ToLookup();

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
                    var jmp = AsmRel32.from(stub);
                    Write(jmp.Format());
                }
            }

            void Search()
            {
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                var stubs = JmpStubs.SearchLive(host);
                Write(stubs.View, LiveMemberCode.RenderWidths);
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
    }
}