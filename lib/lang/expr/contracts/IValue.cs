//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IValue : IExpr, ITerm
    {
        dynamic Value {get;}

        string ITextual.Format()
            => Value?.ToString() ?? string.Empty;

    }

    [Free]
    public interface IValue<T> : IValue, IExpr<T>
    {
        new T Value {get;}

        dynamic IValue.Value
            => Value;

        T IExpr<T>.Eval()
            => Value;
    }

    [Free]
    public interface IValue<K,T> : IValue<T>, IKinded<K>
        where K : unmanaged
    {

    }
}