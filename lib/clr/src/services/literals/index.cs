//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline)]
        public static EnumValues<E,T> index<E,T>(EnumValue<E,T>[] src)
            where E : unmanaged, Enum
            where T : unmanaged
                => new EnumValues<E,T>(src);
    }
}