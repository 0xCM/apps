//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct strings
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, ulong index, ulong length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, long index, long length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, ulong index, ulong length)
            => new StringRef(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, long index, long length)
            => new StringRef(src.Address(index), (uint)length);
    }
}