//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/tokens")]
        Outcome EmitApiTokens(CmdArgs args)
        {
            EmitApiTokens();
            return true;
        }


    }
}