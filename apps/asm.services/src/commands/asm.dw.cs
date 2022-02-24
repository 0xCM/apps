//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class AsmCmdProvider
    {
        AsmCodeMaps AsmCodeMaps => Service(Wf.AsmCodeMaps);

        [CmdOp("asm/codemap")]
        Outcome AsmDw(CmdArgs args)
        {

            var project = Project();
            var context = Projects.Context(project);
            AsmCodeMaps.MapCode(context);
            return true;
        }
    }
}