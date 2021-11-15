//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct emath
    {
        [MethodImpl(Inline)]
        public static @enum<E,T> srl<E,T>(@enum<E,T> a, byte count)
            where E : unmanaged, Enum
            where T : unmanaged
                => new @enum<E,T>(gmath.srl(a.Scalar, count));

        [MethodImpl(Inline)]
        public static byte srl8<E>(E a, byte count)
            where E : unmanaged, Enum
                => gmath.srl(bw8(a), count);

        [MethodImpl(Inline)]
        public static ushort srl16<E>(E a, byte count)
            where E : unmanaged, Enum
                => gmath.srl(bw16(a), count);

        [MethodImpl(Inline)]
        public static uint srl32<E>(E a, byte count)
            where E : unmanaged, Enum
                => gmath.srl(bw32(a), count);

        [MethodImpl(Inline)]
        public static ulong srl64<E>(E a, byte count)
            where E : unmanaged, Enum
                => gmath.srl(bw64(a), count);
    }
}