//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/classes")]
        protected Outcome EmitApiClasses(CmdArgs args)
        {
            ApiCatalogs.EmitApiClasses();
            return true;
        }
    }
}