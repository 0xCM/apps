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
            var entities = DataProvider.SelectEntities();
            var count = entities.Length;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    var str = alias.AsmString;
                    specs.Add(string.Format("{0,-24} | {1,-16} | {2}", str.InstName, str.Mnemonic, str.FormatPattern));
                }
            }

            Flow(InstAliasQuery, specs.ViewDeposited());

            return true;
        }
    }
}