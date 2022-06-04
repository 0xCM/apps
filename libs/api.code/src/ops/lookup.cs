//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static EventFactory;

    partial class ApiCode
    {
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

        static EncodingLookup lookup(Dictionary<ApiHostUri,CollectedCodeExtracts> src, Action<IWfEvent> log)
        {
            log(running(typeof(ApiCode), "Running", Msg.ParsingHosts.Format(src.Count)));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new EncodingLookup();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log(running(typeof(ApiCode), "Running", Msg.ParsingHostMembers.Format(host)));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    dst.Include(new CollectedEncoding(extract.Token, parser.Parsed));
                    counter++;
                }
                log(ran(typeof(ApiCode),Msg.ParsedHostMembers.Format(extracts.Count, host)));
            }

            log(ran(typeof(ApiCode),Msg.ParsedHosts.Format(counter, src.Keys.Count)));
            return dst;
        }
    }
}