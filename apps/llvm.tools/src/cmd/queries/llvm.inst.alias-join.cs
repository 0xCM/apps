//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string InstAliasJoinQuery = "llvm/inst/alias-join";

        [CmdOp(InstAliasJoinQuery)]
        Outcome RunInstAliasJoinQuery(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities();
            var count = entities.Length;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    specs.Add(string.Format("{0,-24} | {1,-16} | {2}", alias.InstName, alias.Mnemonic, alias.AsmString));
                }
                else if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(inst.isCodeGenOnly || inst.isPseudo)
                        continue;

                    specs.Add(string.Format("{0,-24} | {1,-16} | {2}", inst.InstName, inst.Mnemonic, inst.AsmString));
                }
            }

            var results = specs.ToArray().Sort();
            Flow(InstAliasJoinQuery, results);
            return true;
        }
    }
}