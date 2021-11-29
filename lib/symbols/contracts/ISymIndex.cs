//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISymIndex
    {
        SymIndex Untyped();

        uint Count {get;}

        bool Lookup(SymExpr src, out Sym dst);
    }

    public interface ISymIndex<K> : ISymIndex
        where K : unmanaged
    {
        ReadOnlySpan<K> Kinds {get;}

        ReadOnlySpan<Sym<K>> View {get;}

        bool Lookup(SymExpr src, out Sym<K> dst);

        bool ISymIndex.Lookup(SymExpr src, out Sym dst)
        {
            if(Lookup(src, out Sym<K> _dst))
            {
                dst = _dst;
                return true;
            }
            dst = default;
            return false;
        }

        ref readonly Sym<K> this[uint index] {get;}

        ref readonly Sym<K> this[K index] {get;}
    }
}