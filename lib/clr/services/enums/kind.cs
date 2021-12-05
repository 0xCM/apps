//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Enums
    {
        [Op]
        public static ClrEnumKind kind(Type e)
        {
            var tc = Type.GetTypeCode(e.GetEnumUnderlyingType());
            return (ClrEnumKind)PrimalBits.kind(tc);
        }

        [MethodImpl(Inline)]
        public static ClrEnumKind kind<E>(E e = default)
            where E : unmanaged, Enum, IEquatable<E>
                => kind(typeof(E));

        [MethodImpl(Inline)]
        public static unsafe E kind<E,T>(T v)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => Unsafe.Read<E>((E*)&v);
    }
}