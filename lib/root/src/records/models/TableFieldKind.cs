//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableFieldKind<K>
        where K : unmanaged
    {
        public K Default => default;

        [MethodImpl(Inline)]
        public static implicit operator TableFieldKind<K>(K src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator K(TableFieldKind<K> src)
            => default;
    }
}