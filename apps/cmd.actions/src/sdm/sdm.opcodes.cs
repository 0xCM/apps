//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }
   }
}