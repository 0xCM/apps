//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        public static OpUri Uri(this MethodInfo src)
            => ApiUri.define(ApiUriScheme.Located, ApiHostUri.from(src.DeclaringType), src.Name, src.Identify());
    }

    public readonly struct MethodEntryPoints
    {
        [Op]
        public static MethodEntryPoint entry(MethodInfo src)
            => new MethodEntryPoint(ClrJit.jit(src), src.Uri(), src.DisplaySig());

        [Op]
        public static MethodEntryPoint entry(ApiMember src)
            => new MethodEntryPoint(src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig());

        [Op]
        public static Index<MethodEntryPoint> create(Identifier name, ReadOnlySpan<MethodInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = entry(skip(src,i));
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
                seek(dst,i) = entry(skip(view,i));
            return buffer;
        }
    }
}