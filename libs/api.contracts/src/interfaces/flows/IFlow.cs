//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlow : IExpr
    {
    }

    public interface IFlow<S,T> : IFlow, IArrow<S,T>
    {

    }
}