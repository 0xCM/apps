//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
        public T Extract(byte field)
            => api.seg(this, field);

        [MethodImpl(Inline)]
        public Bitfield<T> Store(byte field, T src)
        {
            api.store(src, field, ref this);
            return this;
        }

        [MethodImpl(Inline)]
        internal void Overwrite(T src)
            => State = src;
    }
}