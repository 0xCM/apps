//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct DataLayouts
    {
        [MethodImpl(Inline), Op]
        public static LayoutIdentity identify(uint index, ulong kind)
            => new LayoutIdentity(index, kind);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static LayoutIdentity<T> identify<T>(uint index, T kind)
            where T : unmanaged
                => new LayoutIdentity<T>(index, kind);
    }
}