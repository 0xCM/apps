//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScalarValue : ISizedValue, IScalarExpr, INullary
    {
        bool INullity.IsEmpty
            => false;

        bool INullity.IsNonEmpty
            => false;

        string IExpr.Format()
            => "";
    }

    [Free]
    public interface IScalarValue<T> : IScalarValue, ISizedValue<T>, IScalarExpr
        where T : unmanaged
    {
        T IValue<T>.Value
            => core.@as<IScalarValue<T>,T>(this);
    }
}