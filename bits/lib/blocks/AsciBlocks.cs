//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct AsciBlocks
    {
        const NumericKind Closure = UnsignedInts;

        public static AsciBlock<N> alloc<N>(N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = core.alloc<AsciCode>(Typed.value<N>());
            return new AsciBlock<N>(buffer);
        }

        public static AsciBlock<N> create<N>(string src, N n = default)
            where N : unmanaged, ITypeNat
        {
            var buffer = core.alloc<AsciCode>(value<N>());
            buffer.Clear();
            var chars = span(src);
            ref var dst = ref first(buffer);
            var count = min(buffer.Length, chars.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (AsciCode)skip(chars,i);
            return new AsciBlock<N>(buffer);
        }

        public static string format<N>(AsciBlock<N> src)
            where N : unmanaged, ITypeNat
        {
            var input = src.View;
            var dst = span<char>(input.Length);
            var count = decode(input,dst);
            return new string(slice(dst,0,count));
        }
    }
}