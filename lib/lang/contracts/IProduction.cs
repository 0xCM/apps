//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface IProduction
    {
        ReadOnlySpan<IExpr> Terms(IExpr src);
    }

    public interface IProduction<T> : IProduction
        where T : IExpr
    {
        ReadOnlySpan<T> Terms(T src);

        ReadOnlySpan<IExpr> IProduction.Terms(IExpr src)
        {
            var terms = Terms((T)src);
            var count = terms.Length;
            var dst = alloc<IExpr>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(terms,i);
            return dst;
        }
    }

    public interface IProduction<S,T> : IProduction
        where S : IExpr
        where T : IExpr
    {
        ReadOnlySpan<T> Terms(S src);

        ReadOnlySpan<IExpr> IProduction.Terms(IExpr src)
        {
            var terms = Terms((S)src);
            var count = terms.Length;
            var dst = alloc<IExpr>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(terms,i);
            return dst;
        }
    }
}