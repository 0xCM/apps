//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Refs;
    using static Scalars;
    using static Spans;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct AsciBlocks
    {
        [MethodImpl(Inline)]
        public static ref T load<T>(ReadOnlySpan<C> src, out T target)
            where T : unmanaged, IAsciBlock<T>
        {
            target = default(T);
            var count = min(src.Length,target.Size);
            ref var dst = ref @as<C>(target.First);
            for(var i=0; i<count; i++)
                seek(dst, i) = skip(src, i);
            return ref target;
        }

        [MethodImpl(Inline)]
        public static ref T load<T>(ReadOnlySpan<S> src, out T target)
            where T : unmanaged, IAsciBlock<T>
        {
            target = default(T);
            var count = min(src.Length,target.Size);
            ref var dst = ref @as<S>(target.First);
            for(var i=0; i<count; i++)
                seek(dst, i) = skip(src, i);
            return ref target;
        }

        public static AsciBlock<N> load<N>(S[] src, N n = default)
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(src.Length);
            return new AsciBlock<N>(src);
        }
    }
}
