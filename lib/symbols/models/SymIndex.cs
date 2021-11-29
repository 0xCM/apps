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

    public class SymIndex : ISymIndex
    {
        readonly Index<Sym> Data;

        readonly Index<ulong> _Kinds;

        readonly Dictionary<string,Sym> _SymbolMap;

        SymIndex()
        {
            Data = array<Sym>();
            _Kinds = array<ulong>();
            _SymbolMap = new();
        }

        [MethodImpl(Inline)]
        internal SymIndex(Index<Sym> src, Dictionary<string,Sym> lookup)
        {
            Data = src;
            _Kinds = src.Select(x => x.Kind);
            _SymbolMap = lookup;
        }

        [MethodImpl(Inline)]
        public SymIndex Untyped()
            => this;

        public ref readonly Sym this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public bool Lookup(SymExpr src, out Sym dst)
            => _SymbolMap.TryGetValue(src.Text, out dst);

        public ReadOnlySpan<ulong> Kinds
        {
            [MethodImpl(Inline)]
            get => _Kinds;
        }

        public Sym[] Storage
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

        public ref Sym First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ReadOnlySpan<Sym> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator Sym[](SymIndex src)
            => src.Data;
    }
}