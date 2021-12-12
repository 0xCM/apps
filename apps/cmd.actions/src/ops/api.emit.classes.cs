//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class GlobalCommands
    {
        ApiCatalogs ApiCatalogs => Service(Wf.ApiCatalogs);

        [CmdOp("api/emit/classes")]
        protected Outcome EmitApiClasses(CmdArgs args)
        {
            ApiCatalogs.EmitApiClasses();
            return true;
        }
    }
}