//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential)]
    public struct Bitfield<T,K>
        where T : unmanaged
        where K : unmanaged
    {
        readonly BitfieldModel<K> Model;

        public T State;

        [MethodImpl(Inline)]
        public Bitfield(BitfieldModel<K> model, T state)
        {
            State = state;
            Model = model;
        }

        public ReadOnlySpan<BitfieldSegModel<K>> SegSpecs
        {
            [MethodImpl(Inline)]
            get => Model.Segments;
        }

        [MethodImpl(Inline)]
        public ref readonly BitfieldSegModel<K> SegSpec(byte index)
            => ref Model[index];

        [MethodImpl(Inline)]
        public T Read(byte index)
            => api.extract(this, index);

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