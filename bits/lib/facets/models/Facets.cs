//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Faceted;

    public readonly struct Facets : IIndex<Facet>
    {
        public static Outcome parse(ReadOnlySpan<string> src, out Facets dst)
            => api.parse(src, out dst);

        readonly Index<Facet> Data;

        [MethodImpl(Inline)]
        public Facets(Facet[] src)
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

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Facets(Facet[] src)
            => new Facets(src);

        [MethodImpl(Inline)]
        public static implicit operator Facet[](Facets src)
            => src.Data.Storage;

        public static Facets Empty => new Facets(sys.empty<Facet>());
    }
}