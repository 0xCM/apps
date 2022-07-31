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
        const byte ZeroLimit = 10;

        protected static StatusEvent<T> write<T>(T msg, FlairKind flair = FlairKind.StatusData)
            => Events.status(typeof(ApiCode), msg, flair);

        protected static BabbleEvent<T> babble<T>(T msg)
            => Events.babble(typeof(ApiCode), msg);

        protected static StatusEvent<T> status<T>(T msg, FlairKind flair = FlairKind.Status)
            => Events.status(typeof(ApiCode), msg, flair);

        protected static WarnEvent<T> warn<T>(T msg)
            => Events.warn(typeof(ApiCode), msg);

        protected static ErrorEvent<string> error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Events.error(typeof(ApiCode), e, caller, file, line);

        protected static ErrorEvent<T> error<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Events.error(typeof(ApiCode), msg, Events.originate(typeof(ApiCode).Name,caller, file, line));

        protected static RunningEvent<T> running<T>(T msg)
            => Events.running(typeof(ApiCode), msg);

        protected static RanEvent<T> ran<T>(RunningEvent<T> src, T msg = default)
            => Events.ran(src, msg);

        protected static RanEvent<T> ran<T>(T msg)
            => Events.ran(typeof(ApiCode), msg);

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(ReadOnlySpan<RawMemberCode> src, IWfEventTarget log)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var dst = dict<ApiHostUri,CollectedCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                var extracted = CollectedCodeExtract.Empty;
                var extracts = CollectedCodeExtracts.Empty;
                ref readonly var raw = ref skip(src,i);
                var result = ApiCode.gather(raw, buffer, out extracted);
                if(result.Fail)
                {
                    Errors.Throw($"StubCodeMismatch:{result.Message}");
                }
                else
                {
                    ref readonly var uri = ref raw.Uri;
                    if(uri.Host != host)
                        host = uri.Host;

                    if(dst.TryGetValue(host, out extracts))
                        extracts.Include(extracted);
                    else
                        dst[host] = new CollectedCodeExtracts(extracted);
                }
            }

            return parse(dst, log);
        }

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfEventTarget log)
        {
            log.Deposit(running(Msg.ParsingHosts.Format(src.Count)));
            var buffer = sys.alloc<byte>(Pow2.T14);
            var parser = ApiCode.parser(buffer);
            var dst = new ConcurrentDictionary<ApiToken,ApiEncoded>();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log.Deposit(running(Msg.ParsingHostMembers.Format(host)));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    if(!dst.TryAdd(extract.Token,new ApiEncoded(extract.Token, parser.Parsed)))
                        log.Deposit(Events.warn(log.Host,$"Duplicate:{extract.Token}"));
                    else
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