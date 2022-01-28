//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISeqRule : IRuleExpr
    {
        Index<IRuleExpr> Terms {get;}
    }
}