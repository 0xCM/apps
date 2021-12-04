//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    using static core;
    partial class LlvmCmd
    {
        [CmdOp("inst")]
        public Outcome ShowInst(CmdArgs args)
        {
            var entities = DataLoader.LoadEntities().Members;
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    Write(string.Format("{0,-24} | {1,-16} | {2}", inst.EntityName, inst.Mnemonic, inst.VariationCode));
                }
            }
            return true;
        }
    }
}