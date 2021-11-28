//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = AsciBlocks;

    public readonly struct AsciBlock<N>
        where N : unmanaged, ITypeNat
    {
        readonly Index<AsciCode> Data;

        [MethodImpl(Inline)]
        internal AsciBlock(AsciCode[] data)
        {
            Data = data;
        }

        public ref AsciCode this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref AsciCode this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<AsciCode> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<AsciCode> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }
        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static implicit operator AsciBlock<N>(string src)
            => api.create<N>(src);
    }
}