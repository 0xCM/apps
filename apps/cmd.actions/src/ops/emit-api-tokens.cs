//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("emit-api-tokens")]
        protected Outcome EmitApiTokens(CmdArgs args)
        {
            Service(Wf.ApiMetadata).EmitApiTokens();
            return true;
        }
    }
}