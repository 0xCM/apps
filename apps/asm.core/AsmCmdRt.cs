//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmCmdRt : AppService<AsmCmdRt>
    {
        public static AsmCmdRt runtime(IWfRuntime wf, Index<ICmdProvider> providers, bool start = true)
        {
            var runtime = create(wf);
            runtime.XedRt = XedRuntime.create(wf);
            runtime.CmdSvc = AsmCoreCmd.create(wf, runtime, providers);
            if(start)
                runtime.Xed.Start();
            return runtime;
        }

        public static AsmCmdRt runtime(IWfRuntime wf, bool start = true)
            => runtime(wf, sys.empty<ICmdProvider>(), start);

        AsmCoreCmd CmdSvc;

        XedRuntime XedRt;

        public ref readonly XedRuntime Xed
        {
            [MethodImpl(Inline)]
            get => ref XedRt;
        }

        public ICmdProvider Commands
        {
            [MethodImpl(Inline)]
            get => CmdSvc;
        }

        public XedDocs XedDocs => Service(() => Wf.XedDocs().With(Xed));

        public XedDb XedDb => Service(() => Wf.XedDb().With(Xed));

        public XedPaths XedPaths => Service(() => XedPaths.Service);

        public XedRules XedRules => Service(() => Wf.XedRules().With(Xed));

        public XedDisasmSvc XedDisasm => Service(() => Wf.XedDisasm().With(Xed));

        public XedImport XedImport => Service(() => Wf.XedImport().With(Xed));

        protected override void Disposing()
        {
            CmdSvc?.Dispose();
            Xed?.Dispose();
        }

        public void Run()
            => CmdSvc.Run();
    }
}