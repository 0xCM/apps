//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/bitmasks")]
        public Outcome EmitBitmasks(CmdArgs args)
        {
            EmitBitmasks();
            return true;
        }
    }
}