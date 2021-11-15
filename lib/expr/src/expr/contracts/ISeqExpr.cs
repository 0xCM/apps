//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISeqExpr<T> : IExpr
        where T : IExpr
    {
        ReadOnlySpan<T> Terms {get;}

        string ITextual.Format()
            => Terms.MapArray(t => t.Format()).Concat(" ");
    }
}