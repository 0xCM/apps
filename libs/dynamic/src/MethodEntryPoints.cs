//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct MethodEntryPoints
    {
        public static ReadOnlySeq<MethodEntryPoint> calc(IApiCatalog catalog, ApiHostUri src, IWfEventTarget log)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(catalog.FindHost(src, out var host))
               dst = create(ClrJit.members(host, log));
            return dst;
        }

        public static ReadOnlySeq<MethodEntryPoint> calc(IApiCatalog catalog, PartId src, IWfEventTarget log)
        {
            var dst = sys.empty<MethodEntryPoint>();
            if(catalog.FindPart(src, out var part))
                dst = create(ClrJit.members(part, log));
            return dst;
        }

        [Op]
        public static MethodEntryPoint create(MethodInfo src)
            => new MethodEntryPoint(ClrJit.jit(src), src.Uri(), src.DisplaySig().Format());

        [Op]
        public static MethodEntryPoint create(ApiMember src)
            => new MethodEntryPoint(src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig().Format());

        [Op]
        public static Index<MethodEntryPoint> create(Identifier name, ReadOnlySpan<MethodInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = create(skip(src,i));
            return buffer;
        }

        [Op]
        public static Index<MethodEntryPoint> create(ApiMembers src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            var view = src.View;
            for(var i=0; i<count; i++)
                seek(dst,i) = create(skip(view,i));
            return buffer;
        }
    }
}