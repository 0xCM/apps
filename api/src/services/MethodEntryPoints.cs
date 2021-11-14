//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    public readonly struct MethodEntryPoints
    {
        [Op]
        public static MethodEntryPoint entry(MethodInfo src)
            => new MethodEntryPoint(src.MetadataToken, ClrJit.jit(src));

        [Op]
        public static MethodEntryPoint entry(ApiMember src)
            => new MethodEntryPoint(src.Token, src.BaseAddress);

        [Op, Closures(UInt16k)]
        public static MethodEntryPoint<K> entry<K>(MethodInfo src, K kind)
            where K : unmanaged
                => new MethodEntryPoint<K>(src.MetadataToken, ClrJit.jit(src), kind);
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

        public static Index<MethodEntryPoint> create(PartId part, ApiMembers src)
            => create(part.Format(), src);

        [Op]
        public static Index<MethodEntryPoint> create(Identifier name, ApiMembers src)
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