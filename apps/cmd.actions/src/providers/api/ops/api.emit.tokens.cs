//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/tokens")]
        protected Outcome EmitApiTokens(CmdArgs args)
        {
            ApiMetadata.EmitApiTokens();
            return true;
        }
    }
}