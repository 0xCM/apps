//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/datatypes")]
        Outcome EmitApiDataTypes(CmdArgs args)
        {
            EmitApiDataTypes();
            return true;
        }
    }
}