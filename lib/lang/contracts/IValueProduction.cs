//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IValueProduction<T> : IProduction, IRule<Value<T>>
    {
        IExpr IArrow<IExpr,IExpr>.Source
            => (this as IArrow<Value<T>,Value<T>>).Source;

        IExpr IArrow<IExpr,IExpr>.Target
            => (this as IArrow<Value<T>,Value<T>>).Target;

    }

    public interface IValueProduction<S,T> : IProduction, IRule<Value<S>,Value<T>>
    {
        IExpr IArrow<IExpr,IExpr>.Source
            => (this as IArrow<Value<S>,Value<T>>).Source;

        IExpr IArrow<IExpr,IExpr>.Target
            => (this as IArrow<Value<S>,Value<T>>).Target;
    }
}