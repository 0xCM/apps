//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        [Op]
        public static MemAlloc allocator(uint pages)
            => new MemAlloc(pages);
    }
}