//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("api/emit/classes")]
        protected Outcome EmitApiClasses(CmdArgs args)
        {
            Wf.ApiCatalogs().EmitApiClasses();
            return true;
        }
    }
}