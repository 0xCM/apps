//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IValueCover : IExpr
    {
        dynamic Value {get;}

        string IExpr2.Format()
            => Value?.ToString() ?? string.Empty;
    }

    [Free]
    public interface IValueCover<T> : IValueCover
    {
        new T Value {get;}

        dynamic IValueCover.Value
            => Value;
    }
}