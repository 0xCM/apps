//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Resources
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRes<E> @string<E>(E id, StringAddress address, ByteSize size)
            where E : unmanaged
                => new StringRes<E>(id, address, size);
    }
}