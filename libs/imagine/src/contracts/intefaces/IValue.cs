//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IValue : IExpr, INullity
    {
        dynamic Value {get;}

        string ITextual.Format()
            => Value?.ToString() ?? string.Empty;
    }

    [Free]
    public interface IValue<T> : IValue
    {
        new T Value {get;}

        dynamic IValue.Value
            => Value;
    }
}