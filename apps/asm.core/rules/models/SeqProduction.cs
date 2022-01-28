//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SeqProduction : Production<RuleValue<string>, SeqExpr>, ISeqProduction<RuleValue<string>>
    {
        public SeqProduction(string src, SeqExpr dst)
            : base(src, dst)
        {

        }
    }
}