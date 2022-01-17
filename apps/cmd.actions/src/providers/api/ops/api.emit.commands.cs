//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/commands")]
        Outcome EmitCmdTypes(CmdArgs args)
        {
            EmitApiCommands();
            return true;
        }
    }
}