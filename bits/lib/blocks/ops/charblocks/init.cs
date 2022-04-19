//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static ref T init<T>(ReadOnlySpan<char> src, out T dst)
            where T : unmanaged, ICharBlock<T>
        {
            dst = default;
            return ref Z0.text.copy(src, ref dst);
        }
    }
}