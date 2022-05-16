//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : WfApp<App>
    {
        IAppCmdService CmdService;

        XedRuntime XedRt;

        protected override void Initialized()
        {
            var commands = AsmCoreCmd.create(Wf);
            XedRt = XedRuntime.create(Wf);
            commands.With(XedRt);
            XedRt.Start();
            CmdService = commands;
        }

        public XedRuntime Xed
        {
            [MethodImpl(Inline)]
            get => XedRt;
        }

        protected override void Disposing()
        {
            CmdService?.Dispose();
            XedRt?.Dispose();
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