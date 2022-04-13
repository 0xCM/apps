//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static void read<T>(Span<T> src, Action<T> dst)
            where T : unmanaged
        {
            fixed(T* pSrc = src)
            {
                var it = reader(pSrc, src.Length);
                while(it.Next(out T current))
                    dst(current);
            }
        }
    }
}