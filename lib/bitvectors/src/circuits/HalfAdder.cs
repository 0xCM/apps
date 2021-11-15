//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class LegacyCircuits
    {
        [ApiHost]
        public readonly struct HalfAdder : IHalfAdder
        {
            [MethodImpl(Inline), Op]
            public ConstPair<bit> Invoke(bit a, bit b)
                => (Gates.xor().Invoke(a, b), Gates.and().Invoke(a, b));

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<T> Invoke<T>(T a, T b)
                where T : unmanaged
                    => half<T>().Invoke(a,b);

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector128<T>> Invoke<T>(Vector128<T> a, Vector128<T> b)
                where T : unmanaged
                    => half<T>().Invoke(a,b);

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector256<T>> Invoke<T>(Vector256<T> a, Vector256<T> b)
                where T : unmanaged
                    => half<T>().Invoke(a,b);

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector512<T>> Invoke<T>(in Vector512<T> a, in Vector512<T> b)
                where T : unmanaged
                    => half<T>().Invoke(a,b);
        }

        public readonly struct HalfAdder<T> : IHalfAdder<HalfAdder<T>,T>
            where T : unmanaged
        {
            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<T> Invoke(T a, T b)
                => (Gates.xor<T>().Invoke(a,b), Gates.and<T>().Invoke(a,b));

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector128<T>> Invoke(Vector128<T> a, Vector128<T> b)
                => (Gates.xor<T>().Invoke(a,b), Gates.and<T>().Invoke(a,b));

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector256<T>> Invoke(Vector256<T> a, Vector256<T> b)
                => (Gates.xor<T>().Invoke(a,b), Gates.and<T>().Invoke(a,b));

            [MethodImpl(Inline), Op, Closures(UnsignedInts)]
            public ConstPair<Vector512<T>> Invoke(in Vector512<T> a, in Vector512<T> b)
                => (Gates.xor<T>().Invoke(a,b), Gates.and<T>().Invoke(a,b));
        }

    }

}