//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/hexpacks")]
        Outcome EmitHexPack(CmdArgs args)
        {
            ApiHexPacks.Emit(Blocks());
            return true;
        }
    }
}