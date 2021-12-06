//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("intel/emit/intrinsics")]
        Outcome EmitIntelIntrinsics(CmdArgs args)
        {
            var svc = Service(Wf.IntelIntrinsics);
            svc.Emit();
            return true;
        }
    }
}