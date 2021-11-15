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

    using api = vbits;

    public struct Bitfield256<E,T>
        where E : unmanaged
        where T : unmanaged
    {
        public Vector256<T> State;

        internal readonly Vector256<byte> Widths;

        [MethodImpl(Inline)]
        public Bitfield256(Vector256<byte> widths, Vector256<T> state)
        {
            State = state;
            Widths = default;
        }

        public T this[E index]
        {
            [MethodImpl(Inline)]
            get => Read(index);
        }

        [MethodImpl(Inline)]
        public byte SegWidth(E index)
            => api.segwidth(this, index);

        [MethodImpl(Inline)]
        public T Mask(E index)
            => vmask.mask(this, index);

        [MethodImpl(Inline)]
        public T Read(E index)
            => api.extract(this, index);

        [MethodImpl(Inline)]
        public void Write(T src, E index)
            => api.store(src, index, ref this);
    }
}