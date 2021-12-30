//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("xed/disasm/details")]
        protected Outcome EmitDisasmDetails(CmdArgs args)
        {
            var project = Project();
            return XedDisasm.EmitDisasmDetails(project);
        }
    }
}