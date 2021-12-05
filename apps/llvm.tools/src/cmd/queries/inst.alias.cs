//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("inst/alias")]
        Outcome ShowInstAlias(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities().Members;
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);

                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    Write(string.Format("{0,-24} | {1,-16} | {2}", alias.InstName, alias.Mnemonic, alias.AsmString));
                }
            }

            return true;
        }
    }
}