//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp("api/parts")]
        Outcome ShowApiParts(CmdArgs args)
        {
            var src = ApiRuntimeLoader.catalog();
            var parts = src.Components;
            iter(parts,  p => Write(p.PartName()));
            return true;
        }
    }
}