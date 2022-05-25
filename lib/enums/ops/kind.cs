//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {

        [MethodImpl(Inline)]
        public static unsafe E kind<E,T>(T v)
            where E : unmanaged, Enum
            where T : unmanaged
                => Unsafe.Read<E>((E*)&v);
    }
}