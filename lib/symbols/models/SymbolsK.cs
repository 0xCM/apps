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

        readonly Dictionary<string,Sym<K>> ExprMap;

        readonly Dictionary<SymVal,Sym<K>> ValMap;

        readonly Index<K> SymKinds;

        readonly Index<SymVal> SymVals;

        readonly Dictionary<K,Sym<K>> KindMap;

        Symbols()
        {

        }

        [MethodImpl(Inline)]
        internal Symbols(Index<Sym<K>> src, Dictionary<string,Sym<K>> exprMap, Dictionary<SymVal,Sym<K>> valMap)
        {
            Data = src;
            ExprMap = exprMap;
            ValMap = valMap;
            SymKinds = src.Select(x => x.Kind);
            SymVals = valMap.Keys.Array();
            KindMap = src.Select(x => (x.Kind, x)).ToDictionary();
        }

        public ref readonly Sym<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly Sym<K> this[K kind]
        {
            [MethodImpl(Inline)]
            get => ref Data[bw32(kind)];
        }

        [MethodImpl(Inline)]
        public bool Includes(K index)
            => bw32(index) < Data.Count;

        public bool Lookup(SymExpr src, out Sym<K> dst)
            => ExprMap.TryGetValue(src.Text, out dst);

        public bool MapValue(SymVal src, out Sym<K> dst)
            => ValMap.TryGetValue(src, out dst);

        public bool MapExpr(SymExpr src, out Sym<K> dst)
            => ExprMap.TryGetValue(src.Text, out dst);

        public bool MakKind(K src, out Sym<K> dst)
            => KindMap.TryGetValue(src, out dst);

        public bool ExprKind(SymExpr src, out K dst)
        {
            dst = default;
            var result = MapExpr(src, out var sym);
            if(result)
                dst = sym.Kind;
            return result;
        }

        /// <summary>
        /// Presents an untyped view of the source data
        /// </summary>
        [MethodImpl(Inline)]
        public SymIndex Untyped()
            => SymIndexBuilder.untype(Data.Storage);

        public ReadOnlySpan<K> Kinds
        {
            [MethodImpl(Inline)]
            get => SymKinds;
        }

        public ReadOnlySpan<SymVal> Values
        {
            [MethodImpl(Inline)]
            get => SymVals;
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