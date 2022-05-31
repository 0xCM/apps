//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmCmdRt : AppService<AsmCmdRt>
    {
        internal AsmCoreCmd CmdSvc;

        internal XedRuntime XedRt;

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

        public XedDisasmSvc XedDisasm => Wf.XedDisasm(Xed);

        protected override void Disposing()
        {
            CmdSvc?.Dispose();
            Xed?.Dispose();
        }

        public void Run()
            => CmdSvc.Run();
    }
}