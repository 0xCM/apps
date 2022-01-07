//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        [CmdOp("api/emit/respack")]
        Outcome EmitResPack(CmdArgs args)
        {
            ResPackEmitter.Emit(Blocks(),false);
            return true;
        }
    }
}