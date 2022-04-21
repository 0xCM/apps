//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    public partial class XedMachine : IDisposable
    {
        MachineState RuntimeState;

        readonly RuleTables RuleTables;

        readonly IProjectWs Ws;

        readonly IAppService AppService;

        readonly MachineEmitter _Emitter;

        readonly IWfRuntime Wf;

        static int Seq;

        [MethodImpl(Inline)]
        static uint NextId() => (uint)inc(ref Seq);

        const string Identifier = "xed.machine";

        XedMachine(IAppService svc)
        {
            AppService = svc;
            Wf = svc.Wf;
            var projects = Projects;
            Ws = projects.Project(projects.ProjectData(), Identifier);
            RuntimeState = new(NextId());
            RuleTables = XedRules.CalcRules();
            _Emitter = MachineEmitter.create(this, StatusWriter);

            LoadLookups();
        }

        public void Dispose()
            => _Emitter.Dispose();

        WsProjects Projects => Service(Wf.WsProjects);

        XedRules XedRules => Service(Wf.XedRules);
    }
}