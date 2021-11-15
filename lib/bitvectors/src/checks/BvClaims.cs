//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public readonly struct BvClaims : ICheckPrimal, ICheckInvariant
    {
        static ICheckPrimal Primal => default(BvClaims);

        static ICheckInvariant Invariant => default(BvClaims);

        [MethodImpl(Inline)]
        public static void eq(BitVector4 x, BitVector4 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        [MethodImpl(Inline)]
        public static void eq(BitVector8 x, BitVector8 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        [MethodImpl(Inline)]
        public static void eq(BitVector16 x, BitVector16 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        [MethodImpl(Inline)]
        public static void eq(BitVector32 x, BitVector32 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        [MethodImpl(Inline)]
        public static void eq(BitVector64 x, BitVector64 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        [MethodImpl(Inline)]
        public static void eq<T>(BitVector<T> x, BitVector<T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => Invariant.yea(gmath.eq(x.State, y.State), $"{x} != {y}", caller, file, line);

        [MethodImpl(Inline)]
        public static void eq<N,T>(BitVector128<N,T> x, BitVector128<N,T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Invariant.yea(x.Equals(y), $"{x} != {y}", caller, file, line);

        [MethodImpl(Inline)]
        public static void eq<N,T>(BitVector<N,T> x, BitVector<N,T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Invariant.yea(x.Equals(y), $"{x} != {y}", caller, file, line);
    }
}