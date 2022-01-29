//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/cli")]
        Outcome EmitMetadataCli(CmdArgs args)
        {
            EmitCliMetadata();
            return true;
        }
    }
}