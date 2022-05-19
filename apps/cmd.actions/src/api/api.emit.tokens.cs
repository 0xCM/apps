//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/tokens")]
        Outcome EmitApiTokens(CmdArgs args)
        {
            EmitApiTokens();
            return true;
        }
    }
}