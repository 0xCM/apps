//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string InstQuery = "llvm/inst";

        [CmdOp(InstQuery)]
        public Outcome ShowInst(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities().Members;
            var count = entities.Length;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(inst.isCodeGenOnly || inst.isPseudo)
                        continue;

                    specs.Add(string.Format("{0,-24} | {1,-16} | {2}", inst.InstName, inst.Mnemonic, inst.AsmString));
                }
            }
            Flow(InstQuery, specs.ViewDeposited());
            return true;
        }
    }
}