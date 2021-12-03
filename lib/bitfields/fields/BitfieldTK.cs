//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential)]
    public struct Bitfield<T,K>
        where T : unmanaged
        where K : unmanaged
    {
        readonly Index<BitfieldSegModel<K>> _Segs;

        public T State;

        [MethodImpl(Inline)]
        public Bitfield(BitfieldSegModel<K>[] segs, T state)
        {
            State = state;
            _Segs = segs;
        }

        public ReadOnlySpan<BitfieldSegModel<K>> SegSpecs
        {
            [MethodImpl(Inline)]
            get => _Segs.View;
        }

        [MethodImpl(Inline)]
        public ref readonly BitfieldSegModel<K> SegSpec(byte index)
            => ref _Segs[index];

        [MethodImpl(Inline)]
        public T Read(byte index)
            => api.read(this, index);

        [MethodImpl(Inline)]
        public Bitfield<T,K> Store(byte index, T src)
        {
            api.store(src, index, ref this);
            return this;
        }

        [MethodImpl(Inline)]
        internal void Overwrite(T src)
            => State = src;
    }
}