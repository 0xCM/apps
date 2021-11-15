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
        [Op]
        public static string format(in StringRef src)
            => new string(src.View);

        public static string format<S>(in StringRef<S> src)
            where S : unmanaged
                => new string(core.recover<S,char>(src.View));

        [Op]
        public static string format(in StringRefs src)
            => new string(src.View);

        public static string format<S>(in StringRefs<S> src)
            where S : unmanaged
                => new string(core.recover<S,char>(src.View));

        [MethodImpl(Inline), Op]
        public static unsafe string format(StringAddress src)
            => new string(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static unsafe string format<N>(StringAddress<N> src)
            where N : unmanaged, ITypeNat
                => new string(src.Address.Pointer<char>());
    }
}