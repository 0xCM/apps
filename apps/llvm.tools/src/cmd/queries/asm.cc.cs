//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("asm/cc")]
        Outcome ShowCC(CmdArgs args)
        {
            var conditions = list<RecordEntity>();
            var entities = DataProvider.SelectEntities();
            entities.Traverse((i,e) =>{
                if(e.NameBeginsWith("X86_COND_"))
                {
                    conditions.Add(e);
                }
            });

            foreach(var cc in conditions)
            {
                Write(string.Format("{0,-16} {1}", cc.EntityName, cc["Fragments"]));
            }

            return true;
        }
    }
}
