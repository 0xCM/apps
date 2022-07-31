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
        [Op]
        public static void gather(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfEventTarget log)
            => iter(jit(src, log), member => dst.Add(gather(member, dispenser, log)));

        [Op]
        public static ReadOnlySeq<ApiEncoded> gather(ReadOnlySpan<MethodEntryPoint> src, ICompositeDispenser dispenser, IWfEventTarget log)
            => parse(raw(dispenser, src, log), log).Values.Array().Sort();

        [Op]
        static void jit(IApiHost host, ConcurrentBag<ApiHostMembers> dst, IWfEventTarget log)
        {
            var jitted = ClrJit.jit(host, log);
            if(jitted.IsNonEmpty)
                dst.Add(jitted);
        }

        [Op]
        static void jit(ApiCompleteType src, ConcurrentBag<ApiHostMembers> dst, IWfEventTarget log)
        {
            var jitted = ClrJit.members(ClrJit.jit(src, log));
            if(jitted.IsNonEmpty)
                dst.Add(new ApiHostMembers(src.HostUri, jitted));
        }

        [Op]
        static ConcurrentBag<ApiHostMembers> jit(IApiPartCatalog src, IWfEventTarget log)
        {
            var members = bag<ApiHostMembers>();
            iter(src.ApiHosts, host => jit(host, members, log));
            iter(src.ApiTypes, type => jit(type, members, log));      
            return members;          
        }

        [Op]
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

        [Op]
        static CollectedHost gather(ApiHostMembers src, ICompositeDispenser dst, IWfEventTarget log)
            => new (src, gather(entries(src.Members), dst, log));

        [Op]
        static Index<RawMemberCode> raw(ICompositeDispenser dispenser, ReadOnlySpan<MethodEntryPoint> src, IWfEventTarget log)
        {
            var code = alloc<RawMemberCode>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var entry = ref skip(src,i);
                var buffer = Cells.alloc(w64).Bytes;
                ByteReader.read5(entry.Location.Ref<byte>(), buffer);
                seek(code, i) = raw(entry, dispenser, log);
            }
            return code;
        }

        [Op]
        static RawMemberCode raw(MethodEntryPoint src, ICompositeDispenser dispenser, IWfEventTarget log)
        {
            var dst = new RawMemberCode();
            dst.Entry = src.Location;
            dst.Uri = src.Uri;
            var target = stub(src.Location, out dst.StubCode);
            dst.Target = target;
            if(target != src.Location)
            {
                dst.Disp = AsmRel.disp32(dst.StubCode.Bytes);
                dst.Stub = AsmRel.stub32(src.Location, target);
                dst.Token = token(dispenser, src, target);
            }
            else
                dst.Token = token(dispenser, src);
            return dst;
        }
    }
}