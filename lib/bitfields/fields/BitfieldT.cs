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
    public struct Bitfield<T>
        where T : unmanaged
    {
        readonly BitfieldModel Model;

        public T State;

        [MethodImpl(Inline)]
        public Bitfield(BitfieldModel model, T state)
        {
            State = state;
            Model = model;
        }

        public ReadOnlySpan<BitfieldSegModel> SegSpecs
        {
            [MethodImpl(Inline)]
            get => Model.Segments;
        }

        [MethodImpl(Inline)]
        public T Read(byte index)
            => api.read(this, index);

        [MethodImpl(Inline)]
        public Bitfield<T> Store(byte index, T src)
        {
            api.store(src, index, ref this);
            return this;
        }

        [MethodImpl(Inline)]
        internal void Overwrite(T src)
            => State = src;
    }
}