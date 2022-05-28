//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntelIntrinsics
    {
        public sealed class AppCmd : AppCmdService<AppCmd,CmdShellState>
        {
            IntrinsicChecks IntrinsicChecks => Service(() => IntrinsicChecks.create(Wf));

            [CmdOp("check")]
            Outcome RunChecks(CmdArgs args)
            {
                IntrinsicChecks.Run();
                return true;
            }
        }
    }
}