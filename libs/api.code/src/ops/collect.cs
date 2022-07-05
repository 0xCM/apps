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

        public static ReadOnlySpan<byte> parse(in RawMemberCode src, Span<byte> dst)
        {
            if(src.StubCode != src.Stub.Encoding)
                Errors.Throw("Stub code mismatch");
            return slice(dst,0, Bytes.readz(ZeroLimit, src.Target, dst));
        }

        public static MemoryAddress stub(MemoryAddress src, out AsmHexCode stub)
        {
            stub = AsmHexCode.Empty;
            var target = src;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref src.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = AsmHexCode.load(slice(buffer,0,5));
                target = AsmRel.target((src, 5), stub.Bytes);
            }
            return target;
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
                dst.Disp = AsmRel.disp32(dst.StubCode.Bytes);
                dst.Stub = AsmRel.stub32(entry.Location, target);
                dst.Token = token(symbols, entry, target);
            }
            else
                dst.Token = token(symbols, entry);
        }


        static Index<CollectedEncoding> original(ReadOnlySpan<RawMemberCode> src, WfEventLogger log)
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

        static Outcome extract(in RawMemberCode raw, Span<byte> buffer, out CollectedCodeExtract dst)
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
                var extracted = CollectedCodeExtract.Empty;
                var extracts = CollectedCodeExtracts.Empty;
                ref readonly var raw = ref skip(src,i);
                var result = ApiCode.extract(raw, buffer, out extracted);
                if(result.Fail)
                {
                    log(Events.error("StubCodeMismatch", result.Message));
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