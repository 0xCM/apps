//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/check/objhex")]
        Outcome CheckObjHex(CmdArgs args)
        {
            var project = Project();
            var context = Projects.Context(project);
            var result = CoffServices.CheckObjHex(context);
            return result;
        }
    }
}