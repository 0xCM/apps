//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Expr;
    using Ops.Scalar;

    using static AsciLetterCode;

    public class ScalarMatchCheck : Checker<ScalarMatchCheck>
    {
        public void Check1()
        {
            var match = new ScalarMatch<c8<AsciLetterCode>, u64<ulong>>();
            match.Include(32, a, b, c);
            match.Include(64, d, e, f);
            match.Include(128, g, h, i);
            match.Include(256, j, k, l);

            //Write(match.Format());
        }
    }
}