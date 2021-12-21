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

        readonly Dictionary<SymVal,Sym> _ValueMap;

        readonly Index<SymVal> _Values;

        SymIndex()
        {
            Data = array<Sym>();
            _Kinds = array<ulong>();
            _SymbolMap = new();
            _ValueMap = new();
            _Values = Index<SymVal>.Empty;
        }

        [MethodImpl(Inline)]
        internal SymIndex(Index<Sym> src, Dictionary<string,Sym> symMap, Dictionary<SymVal,Sym> valMap)
        {
            Data = src;
            _Kinds = src.Select(x => x.Kind);
            _SymbolMap = symMap;
            _ValueMap = valMap;
            _Values = _ValueMap.Keys.Array();
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

        public bool MapValue(SymVal src, out Sym dst)
            => _ValueMap.TryGetValue(src, out dst);

        public bool MapExpr(SymExpr src, out Sym dst)
            => _SymbolMap.TryGetValue(src.Text, out dst);

        public ReadOnlySpan<ulong> Kinds
        {
            [MethodImpl(Inline)]
            get => _Kinds;
        }

        public ReadOnlySpan<SymVal> Values
        {
            [MethodImpl(Inline)]
            get => _Values;
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