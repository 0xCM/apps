//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    sealed class App : WfApp<App>
    {
        AsmCmdService AsmCmd;

        protected override void Initialized()
        {
            AsmCmd = Wf.AsmCmd();
        }

        protected override void Disposing()
        {
            AsmCmd.Dispose();
        }

        protected override void Run()
            => AsmCmd.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }
    }
}