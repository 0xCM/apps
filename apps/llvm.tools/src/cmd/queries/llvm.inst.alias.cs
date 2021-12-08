//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string InstAliasQuery = "llvm/inst/alias";

        [CmdOp(InstAliasQuery)]
        Outcome RunInstAliasQuery(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities().Members;
            var count = entities.Length;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    specs.Add(string.Format("{0,-24} | {1,-16} | {2}", alias.InstName, alias.Mnemonic, alias.AsmString));
                }
            }

            Flow(InstAliasQuery, specs.ViewDeposited());

            return true;
        }

    }
}