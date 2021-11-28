//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Calcs;

    [ApiHost]
    public readonly partial struct CalcClients
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public bit dotprod<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvdot<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> gather<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvgather<T>().Invoke(x,y);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> nor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvnor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> not<T>(BitVector<T> x)
            where T : unmanaged
                => bvnot<T>().Invoke(x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> xnor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvxnor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> xor<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvxor<T>().Invoke(x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public int width<T>(BitVector<T> x)
            where T : unmanaged
                => bveffwidth<T>().Invoke(x);
    }
}