//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/hex-packs")]
        protected Outcome EmitHexPack(CmdArgs args)
        {
            Service(Wf.ApiHexPacks).Emit(SortedBlocks());
            return true;
        }
    }
}