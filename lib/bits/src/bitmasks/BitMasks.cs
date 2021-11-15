//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public partial class BitMasks
    {
        const NumericKind Closure = UnsignedInts;

        public static string[] names()
            => typeof(BitMaskLiterals).LiteralFields().Select(x => x.Name);

        public readonly struct Specs
        {
            [MethodImpl(Inline)]
            public static JsbMask<F,D,T> jsb<F,D,T>(F f = default, D d = default, T t = default)
                where F : unmanaged, ITypeNat
                where D : unmanaged, ITypeNat
                where T : unmanaged
                    => default;

            [MethodImpl(Inline)]
            public static MsbMask<F,D,T> msb<F,D,T>(F f = default, D d = default, T t = default)
                where F : unmanaged, ITypeNat
                where D : unmanaged, ITypeNat
                where T : unmanaged
                    => default;

            [MethodImpl(Inline)]
            public static LsbMask<F,D,T> lsb<F,D,T>(F f = default, D d = default, T t = default)
                where F : unmanaged, ITypeNat
                where D : unmanaged, ITypeNat
                where T : unmanaged
                    => default;

            [MethodImpl(Inline)]
            public static CentralMask<F,D,T> central<F,D,T>(F f = default, D d = default, T t = default)
                where F : unmanaged, ITypeNat
                where D : unmanaged, ITypeNat
                where T : unmanaged
                    => default;

            [MethodImpl(Inline)]
            public static IndexMask<N,T> index<N,T>(N n = default, T t = default)
                where N : unmanaged, ITypeNat
                where T : unmanaged
                    => default;

            [MethodImpl(Inline)]
            public static MaskSpec describe<F,D,T>(BitMaskKind m, F f = default, D d = default, T t = default)
                where F : unmanaged, ITypeNat
                where D : unmanaged, ITypeNat
                where T : unmanaged
                    => new MaskSpec(m, NumericKinds.kind<T>(), (uint)TypeNats.value<F>(), (uint)TypeNats.value<D>());
        }
    }
}