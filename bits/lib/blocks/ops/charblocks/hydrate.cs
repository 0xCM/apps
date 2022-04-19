//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static ref T hydrate<T>(StringAddress src, out T dst)
            where T : unmanaged, ICharBlock<T>
        {
            dst = default;
            var i=0u;
            src.Render(ref i, dst.Data);
            return ref dst;
        }
    }
}