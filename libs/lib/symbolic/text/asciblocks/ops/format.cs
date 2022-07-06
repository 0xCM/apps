//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct AsciBlocks
    {
        public static string format<N>(AsciBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var dst = span<char>(src.View.Length);
            var count = render(src,dst);
            return new string(slice(dst,0,count));
        }

        [MethodImpl(Inline)]
        public static uint render<N>(AsciBlock<N> src, Span<char> dst)
            where N : unmanaged, ITypeNat
                => decode(src.View, dst);
    }
}