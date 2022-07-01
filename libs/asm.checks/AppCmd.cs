//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    unsafe class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.EnvCmd()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));

        [CmdOp("shell/settings")]
        void PartSettings()
        {
            ShellSettings().Iter(setting => Write(setting.Format(Chars.Colon)));
        }
    }
}