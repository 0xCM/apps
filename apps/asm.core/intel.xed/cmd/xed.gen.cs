//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/gen")]
        void GenXedCode()
        {
            var spec = SymTables.spec<IFormType>("IForm", "IFormStrings", "Z0.Strings", "Z0.Strings", false);
            var table = SymTables.names<IFormType>(spec);
        }
    }
}