//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string CcQuery = "llvm/asm/cc";

        [CmdOp(CcQuery)]
        Outcome QueryCC(CmdArgs args)
        {
            var conditions = list<RecordEntity>();
            var entities = DataProvider.SelectEntities();
            entities.Traverse((i,e) =>{
                if(e.NameBeginsWith("X86_COND_"))
                {
                    conditions.Add(e);
                }
            });

            var specs = @readonly(conditions.Map(x => string.Format("{0,-16} {1}", x.EntityName, x["Fragments"])));
            Flow(CcQuery,specs);

            return true;
        }
    }
}
