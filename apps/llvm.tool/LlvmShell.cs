//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using clang;

    [Free]
    sealed class LlvmShell : WfApp<LlvmShell>
    {
        IAppCmdService ToolService;

        IAppCmdService CmdService;

        protected override void Initialized()
        {
            CmdService = LlvmCmd.create(Wf);
        }

        protected override void Disposing()
        {
            ToolService?.Dispose();
            CmdService?.Dispose();
        }

        protected override void Run()
            => CmdService.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }
    }
}