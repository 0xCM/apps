//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct AsciBlocks
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T load<T>(ReadOnlySpan<AsciCode> src, out T dst)
            where T : unmanaged, IAsciBlock<T>
        {
            dst = default(T);
            var count = min(src.Length,dst.Size);
            ref var target = ref @as<AsciCode>(dst.First);
            for(var i=0; i<count; i++)
                seek(target,i) = skip(src,i);
            return ref dst;
        }

        public static AsciBlock<N> load<N>(AsciCode[] src, N n = default)
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(src.Length);
            return new AsciBlock<N>(src);
        }
    }
}
