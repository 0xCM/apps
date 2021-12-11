//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string DagOpQuery = "llvm/defs/dagops";

        [CmdOp(DagOpQuery)]
        Outcome QueryDagOps(CmdArgs args)
        {
            var src = DataProvider.SelectEntities(e => e.IsDAGOperand()).Select(e => e.ToDAGOperand());
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                var name = entity.EntityName;
                var vt = entity.Type;
                var ot = entity.OperandType;
                var info = entity.MIOperandInfo;
                var fmt = string.Format("{0,-24} | {1,-16} | {2,-24} | {3}", name, vt, ot, info);
                Write(fmt);
            }

            return true;
        }
    }
}
