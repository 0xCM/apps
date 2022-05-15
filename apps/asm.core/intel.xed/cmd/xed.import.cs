//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("xed/import")]
        Outcome RunImport(CmdArgs args)
        {
            Xed.Import.Run();
            return true;
        }
    }
}