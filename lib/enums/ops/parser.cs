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
        [MethodImpl(Inline)]
        public static EnumParser<E> parser<E>()
            where E : unmanaged, Enum
                => new();
    }
}