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
        static Index<CollectedEncoding> divine(ReadOnlySpan<RawMemberCode> src, Action<IWfEvent> log)
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
    }
}