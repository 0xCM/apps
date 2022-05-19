//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/tables")]
        Outcome EmitTableReport(CmdArgs args)
        {
            EmitTableReport();
            return true;
        }
    }
}