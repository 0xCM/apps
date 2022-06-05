//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/objhex")]
        Outcome CheckObjHex(CmdArgs args)
        {
            var project = Project();
            var context = WsApi.context(project);
            return Coff.CheckObjHex(context);
        }
    }
}