//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class CheckCmd : AppCmdProvider<CheckCmd>
    {
        public static ICmdProvider commands(IWfRuntime wf)
            => wf.CheckCmd();
    }
}