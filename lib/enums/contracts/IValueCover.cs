//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IValueCover : IExpr
    {
        dynamic Value {get;}

        string ITextual.Format()
            => Value?.ToString() ?? string.Empty;
    }

    public interface IValueCover<T> : IValueCover
    {
       new T Value {get;}

        dynamic IValueCover.Value
            => Value;
    }
}