//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public class Symbols<K> : ISymIndex<K>
        where K : unmanaged
    {
        readonly Index<Sym<K>> Data;

        readonly Dictionary<string,Sym<K>> SymLookup;

        readonly Index<K> SymKinds;

        readonly SymIndex _Untyped;

        Symbols()
        {

        }

        [MethodImpl(Inline)]
        internal Symbols(Index<Sym<K>> src, Dictionary<string,Sym<K>> lookup, SymIndex untyped)
        {
            Data = src;
            SymLookup = lookup;
            SymKinds = src.Select(x => x.Kind);
            _Untyped = untyped;
        }

        public ref readonly Sym<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly Sym<K> this[K index]
        {
            [MethodImpl(Inline)]
            get => ref Data[bw16(index)];
        }

        public bool Lookup(SymExpr src, out Sym<K> dst)
            => SymLookup.TryGetValue(src.Text, out dst);

        /// <summary>
        /// Presents an untyped view of the source data
        /// </summary>
        [MethodImpl(Inline)]
        public SymIndex Untyped()
            => _Untyped;

        public ReadOnlySpan<K> Kinds
        {
            [MethodImpl(Inline)]
            get => SymKinds;
        }

        public Sym<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref Sym<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ReadOnlySpan<Sym<K>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator Sym<K>[](Symbols<K> src)
            => src.Data;
    }
}