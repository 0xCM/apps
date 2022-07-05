//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IValued : IExpr, INullity
    {

    }

    [Free]
    public interface IValued<T> : IValued
    {
        T Value {get;}

        string IExpr.Format()
            => Value?.ToString() ?? string.Empty;
    }
}