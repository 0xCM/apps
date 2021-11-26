//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    partial class AsmCmdService
    {
        [CmdOp(".api-pdbs")]
        Outcome IndexApiPdbFiles(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components;
            var builder = Wf.PdbIndexBuilder();
            builder.IndexComponents(components);
            return true;
        }
    }
}