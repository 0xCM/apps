//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SeqProduction : Production<Value<string>, SeqExpr>, ISeqProduction<Value<string>>
    {
        internal SeqProduction(string src, SeqExpr dst)
            : base(src, dst)
        {

        }
    }
}