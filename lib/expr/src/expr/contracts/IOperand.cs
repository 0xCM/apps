//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOperand : IExpr
    {
        dynamic Resolve(IContext context);
    }

    public interface IOperand<T> : IOperand
    {
        new T Resolve(IContext context);

        dynamic IOperand.Resolve(IContext context)
            => Resolve(context);
    }
}