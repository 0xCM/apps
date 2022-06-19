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
        public Index<CollectedEncoding> Collect(ICompositeDispenser symbols, IPart src)
            => collect(MethodEntryPoints.create(ApiJit.JitPart(src)), EventLog, symbols);

        public static Index<CollectedEncoding> collect(IApiPartCatalog src, WfEventLogger log, ICompositeDispenser dst)
            => collect(MethodEntryPoints.create(ApiJit.jit(src, log)), log, dst);

        public static Index<CollectedEncoding> collect(ReadOnlySpan<MethodEntryPoint> src, WfEventLogger log, ICompositeDispenser dispenser)
            => divine(collect(dispenser, src), log);

        static Index<RawMemberCode> collect(ICompositeDispenser symbols, ReadOnlySpan<MethodEntryPoint> entries)
        {
            var count = entries.Length;
            var code = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var buffer = Cells.alloc(w64).Bytes;
                ByteReader.read5(entry.Location.Ref<byte>(), buffer);
                collect(symbols, entry, out seek(code, i));
            }
            return code;
        }

        static void collect(ICompositeDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var target = stub(entry.Location, out dst.StubCode);
            dst.Target = target;
            if(target != entry.Location)
            {
                dst.Disp = AsmRel32.disp(dst.StubCode.Bytes);
                dst.Stub = new JmpStub(entry.Location, target);
                dst.Token = token(symbols, entry, target);
            }
            else
                dst.Token = token(symbols, entry);
        }

        static Index<CollectedEncoding> divine(ReadOnlySpan<RawMemberCode> src, WfEventLogger log)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var dst = dict<ApiHostUri,CollectedCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var raw = ref skip(src,i);
                var uri = raw.Uri;
                if(raw.StubCode != raw.Stub.Encoding)
                {
                    Errors.Throw("Stub code mismatch");
                    break;
                }

                if(uri.Host != host)
                    host = uri.Host;

                var extract = slice(buffer,0, Bytes.readz(ZeroLimit, raw.Target, buffer));
                var extracted = new CollectedCodeExtract(raw, extract.ToArray());
                if(dst.TryGetValue(host, out var extracts))
                    extracts.Include(extracted);
                else
                    dst[host] = new CollectedCodeExtracts(extracted);
            }

            return lookup(dst, log).Emit();
        }

        static CollectedEncodings lookup(Dictionary<ApiHostUri,CollectedCodeExtracts> src, WfEventLogger log)
        {
            log(running(Msg.ParsingHosts.Format(src.Count)));
            var buffer = alloc<byte>(Pow2.T14);
            var parser = EncodingParser.create(buffer);
            var dst = new CollectedEncodings();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                log(running(Msg.ParsingHostMembers.Format(host)));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    dst.Include(new CollectedEncoding(extract.Token, parser.Parsed));
                    counter++;
                }
                log(ran(Msg.ParsedHostMembers.Format(extracts.Count, host)));
            }

            log(ran(Msg.ParsedHosts.Format(counter, src.Keys.Count)));
            return dst;
        }
    }
}