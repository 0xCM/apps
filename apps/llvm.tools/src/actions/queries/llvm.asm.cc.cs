//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using static core;

    partial class LlvmCmdProvider
    {
        const string CcQuery = "llvm/asm/cc";

        [CmdOp(CcQuery)]
        Outcome QueryCC(CmdArgs args)
        {
            var conditions = list<LlvmEntity>();
            var entities = DataProvider.SelectEntities();
            entities.Traverse((i,e) =>{
                if(e.NameBeginsWith("X86_COND_"))
                {
                    conditions.Add(e);
                }
            });

            var specs = @readonly(conditions.Map(x => string.Format("{0,-16} {1}", x.EntityName, x["Fragments"])));
            DataEmitter.EmitQueryResults(CcQuery, specs);

            return true;
        }
    }

    partial class XTend
    {
        public static void Traverse<T>(this Index<T> src, Action<int,T> f)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                f(i,src[i]);
        }
    }
}
