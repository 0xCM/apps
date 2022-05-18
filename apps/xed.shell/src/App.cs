//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : WfApp<App>
    {
        AsmCmdRt CmdRt;

        protected override void Initialized()
        {
            CmdRt = AsmCmdRt.runtime(Wf);
        }

        protected override void Disposing()
        {
            CmdRt?.Dispose();
        }

        protected override void Run()
            => CmdRt.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = create(wf);
            shell.Run();
        }
    }
}