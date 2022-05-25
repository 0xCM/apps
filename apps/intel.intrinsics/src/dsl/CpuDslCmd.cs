//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Vdsl;

    public sealed partial class CpuDslCmd : AppCmdService<CpuDslCmd,CmdShellState>
    {
        Intrinsics.Checks IntrinsicChecks => Service(() => Intrinsics.Checks.create(Wf));

        [CmdOp("check")]
        Outcome RunChecks(CmdArgs args)
        {
            IntrinsicChecks.Run();
            return true;
        }
    }
}