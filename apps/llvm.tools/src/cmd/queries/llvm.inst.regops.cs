//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string RegOpQuery = "llvm/inst/regops";

        [CmdOp(RegOpQuery)]
        public Outcome ShowRegOps(CmdArgs args)
        {
            var src = DataProvider.SelectEntities().Where(x => x.IsRegOp()).Map(x => x.ToRegOp());
            iter(src, x => Write(string.Format("{0}:{1} {2}", x.EntityName, x.RegTypes, x.MemberList)));
            return true;
        }
    }
}
