//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitfieldCell<T> cell<T>(T value)
            where T : unmanaged
                => new BitfieldCell<T>(value);
    }
}