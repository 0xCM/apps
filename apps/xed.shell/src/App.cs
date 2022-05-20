//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    sealed class App : WfApp<App>
    {
        static AsmCmdRt CmdRt;

        protected override void Initialized()
        {
            var providers = array<ICmdProvider>(Wf.PbCmd());
            CmdRt = AsmCmdRt.runtime(Wf, new ICmdProvider[]{
                Wf.PbCmd(),
                Wf.IntelIntrinsicsCmd()
            });
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