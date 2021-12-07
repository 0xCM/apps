//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp("api/query/parts")]
        Outcome ShowApiParts(CmdArgs args)
        {
            var src = ApiRuntimeCatalog;
            var parts = src.Components;
            iter(parts,  p => Write(p.PartName()));
            return true;
        }
    }
}