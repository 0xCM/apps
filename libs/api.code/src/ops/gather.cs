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
        public static ReadOnlySeq<CollectedEncoding> gather(ReadOnlySpan<MethodEntryPoint> src, IWfEventTarget log, ICompositeDispenser dispenser)
            => gather(gather(dispenser, src), log).Sort();

        public static void gather(IApiPartCatalog src, IWfEventTarget log, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst)
        {
            var members = list<ApiHostMembers>();
            var collected = list<CollectedHost>();
            iter(src.ApiHosts,
                host => {
                    var jitted = ClrJit.jit(host, log);
                    if(jitted.IsNonEmpty)
                        members.Add(jitted);
                }
                );

            iter(src.ApiTypes, type => {
                var jitted = ApiQuery.members(ClrJit.jit(type, log));
                if(jitted.IsNonEmpty)
                    members.Add(new ApiHostMembers(type.HostUri, jitted));
                }
                );
            iter(members, m => dst.Add(gather(m, log, dispenser)));

        }

        public static CollectedHost gather(ApiHostMembers src, IWfEventTarget log, ICompositeDispenser dst)
            => new CollectedHost(src, gather(MethodEntryPoints.create(src.Members), log, dst));

        static Index<RawMemberCode> gather(ICompositeDispenser symbols, ReadOnlySpan<MethodEntryPoint> src)
        {
            var count = src.Length;
            var code = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                var buffer = Cells.alloc(w64).Bytes;
                ByteReader.read5(entry.Location.Ref<byte>(), buffer);
                gather(symbols, entry, out seek(code, i));
            }
            return code;
        }

        static void gather(ICompositeDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var target = stub(entry.Location, out dst.StubCode);
            dst.Target = target;
            if(target != entry.Location)
            {
                dst.Disp = AsmRel.disp32(dst.StubCode.Bytes);
                dst.Stub = AsmRel.stub32(entry.Location, target);
                dst.Token = token(symbols, entry, target);
            }
            else
                dst.Token = token(symbols, entry);
        }

        static Index<CollectedEncoding> gather(ReadOnlySpan<RawMemberCode> src, IWfEventTarget log)
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
                    log.Deposit(Events.error("StubCodeMismatch", result.Message));
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

            return lookup(dst, log).Emit();
        }

        static Outcome gather(in RawMemberCode raw, Span<byte> buffer, out CollectedCodeExtract dst)
        {
            var result = Outcome.Success;
            var uri = raw.Uri;
            if(raw.StubCode != raw.Stub.Encoding)
            {
                result = (false,$"Stub code mismatch for ${uri}: neq(stub:{raw.StubCode}, stub.encoding:{raw.Stub.Encoding}");
                dst = CollectedCodeExtract.Empty;
            }
            else
            {
                var code = slice(buffer, 0, Bytes.readz(ZeroLimit, raw.Target, buffer));
                dst = new CollectedCodeExtract(raw, code.ToArray());
            }

            return result;
        }

        static CollectedEncodings lookup(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfEventTarget log)
        {
            log.Deposit(running(Msg.ParsingHosts.Format(src.Count)));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new CollectedEncodings();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log.Deposit(running(Msg.ParsingHostMembers.Format(host)));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    dst.Include(new CollectedEncoding(extract.Token, parser.Parsed));
                    counter++;
                }
                log.Deposit(ran(Msg.ParsedHostMembers.Format(extracts.Count, host)));
            }

            log.Deposit(ran(Msg.ParsedHosts.Format(counter, src.Keys.Count)));
            return dst;
        }
    }
}