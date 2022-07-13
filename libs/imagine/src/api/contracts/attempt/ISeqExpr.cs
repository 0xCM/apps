//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISeqExpr<T> : IExprDeprecated
    {
        ReadOnlySpan<T> Terms {get;}

        string IExpr.Format()
            => String.Join(" ", Terms.MapArray(t => t.ToString()));
    }
}