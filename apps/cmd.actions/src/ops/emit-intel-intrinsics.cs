//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("emit-intel-intrinsics")]
        Outcome EmitIntelIntrinsics(CmdArgs args)
        {
            var svc = Service(Wf.IntelIntrinsics);
            svc.Emit();
            return true;
        }
    }
}