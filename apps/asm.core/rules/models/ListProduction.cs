//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListProduction : Production<IRuleExpr, SeqExpr>, ISeqProduction<IRuleExpr>
    {
        public ListProduction(IRuleExpr src, SeqExpr dst)
            : base(src, dst)
        {

        }
    }
}