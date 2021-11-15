//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct FacetIndex : IIndex<Facet>
    {
        readonly Index<Facet> Data;

        [MethodImpl(Inline)]
        public FacetIndex(Facet[] src)
        {
            Data = src;
        }

        public Facet[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<Facet> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<Facet> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref Facet this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Facet this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator FacetIndex(Facet[] src)
            => new FacetIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator Facet[](FacetIndex src)
            => src.Data.Storage;
    }
}