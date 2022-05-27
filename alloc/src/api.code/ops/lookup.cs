//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

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

        static EncodingLookup lookup(Dictionary<ApiHostUri,CollectedCodeExtracts> src, Action<string> log)
        {
            log(Msg.ParsingHosts.Format(src.Count));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new EncodingLookup();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log(Msg.ParsingHostMembers.Format(host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    var state = parser.Parse(extract.TargetExtract);
                    dst.Include(new CollectedEncoding(extract.Token, parser.Parsed));
                    counter++;
                }
                log(Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            log(Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }
    }
}