//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    unsafe partial struct memory
    {
        public static MemoryList<T> list<T>(uint count)
            where T : unmanaged
                => new MemoryList<T>(native(count*size<T>()));
    }
}