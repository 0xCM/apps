//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        const byte ZeroLimit = 10;

        class ApiEncodings
        {
            readonly ConcurrentDictionary<uint,ApiEncoded> Data;

            public ApiEncodings()
            {
                Data = new();
            }

            public bool Include(in ApiEncoded src)
                => Data.TryAdd(src.Token.EntryId,src);

            public Index<ApiEncoded> Emit(bool clear = true)
            {
                var members = Data.Values.Array();
                if(clear)
                    Data.Clear();
                return members;
            }
        }    
        
        static ApiEncodings parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfEventTarget log)
        {
            log.Deposit(running(Msg.ParsingHosts.Format(src.Count)));
            var buffer = sys.alloc<byte>(Pow2.T14);
            var parser = ApiCode.parser(buffer);
            var dst = new ApiEncodings();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log.Deposit(running(Msg.ParsingHostMembers.Format(host)));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    dst.Include(new ApiEncoded(extract.Token, parser.Parsed));
                    counter++;
                }
                log.Deposit(ran(Msg.ParsedHostMembers.Format(extracts.Count, host)));
            }

            log.Deposit(ran(Msg.ParsedHosts.Format(counter, src.Keys.Count)));
            return dst;
        }

        static Outcome parse(FS.FilePath src, out Seq<EncodedMember> dst)
        {
            var result = Outcome.Success;
            var lines = src.ReadLines(true);
            var count = lines.Count - 1;
            dst = alloc<EncodedMember>(count);
            for(var i=0u; i<count; i++)
            {
                result = parse(i + 1, lines[i + 1], out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        static Outcome parse(LineNumber line, string src, out EncodedMember dst)
        {
            const byte FieldCount = EncodedMember.FieldCount;
            dst = default;
            var cells = text.split(src, Chars.Pipe);
            var count = cells.Length;
            if(count != FieldCount)
                return (false,string.Format("\n{0,-12} \n{1}", line, text.trim(cells).Delimit('\n').Format()));

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
    }
}