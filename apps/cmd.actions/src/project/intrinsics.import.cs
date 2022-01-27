//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("intrinsics/import")]
        Outcome ImportIntrinsics(CmdArgs args)
        {
            var svc = Service(Wf.IntelIntrinsics);
            svc.Emit();
            return true;
        }

        [CmdOp("cult/import")]
        Outcome ImportCultData(CmdArgs args)
            => Wf.CultProcessor().Process();
    }
}