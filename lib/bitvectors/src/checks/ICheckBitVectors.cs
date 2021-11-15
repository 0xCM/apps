//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    using Claims = BvClaims;

    public interface ICheckBitVectors : ICheckPrimal, ICheckInvariant
    {
        ICheckPrimal Primal => this;

        void eq(BitVector4 x, BitVector4 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector8 x, BitVector8 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector16 x, BitVector16 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector32 x, BitVector32 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Claims.eq(x, y, caller, file, line);

        void eq(BitVector64 x, BitVector64 y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Primal.eq(x.State, y.State, caller, file, line);

        void eq<T>(BitVector<T> x, BitVector<T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);

        void eq<N,T>(BitVector128<N,T> x, BitVector128<N,T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);

        void eq<N,T>(BitVector<N,T> x, BitVector<N,T> y, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Claims.eq(x, y, caller, file, line);
    }
}