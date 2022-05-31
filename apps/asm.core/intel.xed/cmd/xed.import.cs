//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedImport;
    partial class AsmCoreCmd
    {
        [CmdOp("xed/import")]
        Outcome RunImport(CmdArgs args)
        {
            Xed.Import.Run();
            return true;
        }

        [CmdOp("xed/import/check")]
        void CheckXedImports()
        {
            var blocks = Xed.Views.InstImports;
            ref readonly var lines = ref blocks.BlockLines;
            var forms = lines.Keys.Index().Sort();
            ref readonly var source = ref blocks.DataSource;
        }
    }
}