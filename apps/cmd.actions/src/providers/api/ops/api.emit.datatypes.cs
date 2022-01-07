//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        const string DatatypesEmitCmd = "api/emit/datatypes";

        [CmdOp(DatatypesEmitCmd)]
        Outcome EmitApiDataTypes(CmdArgs args)
        {
            EmitApiDataTypes();
            return true;
        }
    }
}