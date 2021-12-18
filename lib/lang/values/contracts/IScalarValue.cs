//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalarValue : ISizedValue, IScalarExpr
    {
        string ITextual.Format()
            => "";
    }

    [Free]
    public interface IScalarValue<T> : IScalarValue, ISizedValue<T>, IScalarExpr<T>
        where T : unmanaged
    {
        T IExpr<T>.Eval()
            => Value;

        T IValue<T>.Value
            => core.@as<IScalarValue<T>,T>(this);
    }

    [Free]
    public interface IScalarValue<K,T> : IScalarValue<T>, IValue<K,T>, IScalarExpr<K,T>
        where T : unmanaged
        where K : unmanaged
    {

    }
}