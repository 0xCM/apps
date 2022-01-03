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
        protected Outcome EmitApiTokens(CmdArgs args)
        {
            var tokens = ApiMetadata.EmitApiTokens();
            return true;
        }
    }
}