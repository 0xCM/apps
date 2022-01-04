//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static core;

    using Asm;

    partial class ProjectCmdProvider
    {

        [CmdOp("xed/disasm/collect")]
        Outcome CollectXedDisasm(CmdArgs args)
        {
            var project = Project();
            var records = XedDisasm.Collect(project);

            return true;
        }
    }
}