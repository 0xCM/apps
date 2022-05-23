//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/asm/cc")]
        void QueryCC()
        {
            var conditions = list<LlvmEntity>();
            var entities = DataProvider.SelectEntities();
            iter(entities.View, e =>{
                if(e.NameBeginsWith("X86_COND_"))
                    conditions.Add(e);
            });

            var specs = @readonly(conditions.Map(x => string.Format("{0,-16} {1}", x.EntityName, x["Fragments"])));
            Query.FileEmit("llvm/asm/cc", specs);
        }
    }
}
