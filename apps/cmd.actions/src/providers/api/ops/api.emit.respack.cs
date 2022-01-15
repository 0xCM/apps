//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/respack")]
        Outcome EmitResPack(CmdArgs args)
        {
            ResPackEmitter.Emit(Blocks().Storage);
            return true;
        }
    }
}