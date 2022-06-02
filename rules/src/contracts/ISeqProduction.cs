//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static Rules;

   public interface IListProduction<S> : IProduction<S,SeqExpr>
        where S : IRuleExpr
    {

    }
}