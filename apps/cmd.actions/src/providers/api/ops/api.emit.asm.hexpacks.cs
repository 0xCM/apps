//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/asm/hexpacks")]
        protected Outcome EmitHexPack(CmdArgs args)
        {
            ApiHexPacks.Emit(SortedBlocks());
            return true;
        }
    }
}