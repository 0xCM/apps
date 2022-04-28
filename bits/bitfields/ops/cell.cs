//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitfieldCell<T> cell<T>(BitfieldInterval i, T value)
            where T : unmanaged
                => new BitfieldCell<T>(i,value);
    }
}