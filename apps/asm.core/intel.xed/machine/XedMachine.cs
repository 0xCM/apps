//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedMachine;

    partial class XTend
    {
        public static Host XedMachinHost(this IWfRuntime wf)
            => Host.create(wf);
    }

    public partial class XedMachine : IDisposable
    {
        public static XedMachine allocate(IAppService svc)
            => new XedMachine(svc);

        MachineState RuntimeState;

        readonly RuleTables RuleTables;

        readonly IProjectWs Ws;

        readonly IAppService AppService;

        readonly Emitter _Emitter;

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
            RuleTables = XedRules.CalcRuleTables();
            _Emitter = Emitter.create(this, StatusWriter);

            LoadLookups();
        }

        public void Dispose()
            => _Emitter.Dispose();

        WsProjects Projects => Service(Wf.WsProjects);

        XedRules XedRules => Service(Wf.XedRules);
    }
}