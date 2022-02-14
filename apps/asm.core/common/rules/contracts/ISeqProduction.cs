//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IListProduction<S> : IProduction<S,SeqExpr>
        where S : IRuleExpr
    {

    }
}