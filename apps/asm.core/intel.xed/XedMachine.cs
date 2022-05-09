//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedMachine;

    partial class XTend
    {
        public static Host XedMachinHost(this IWfRuntime wf)
            => Host.create(wf);
    }

    public partial class XedMachine : IDisposable
    {
        public static XedMachine allocate(XedRuntime xed)
            => new XedMachine(xed);

        XedRuntime Xed;

        MachineState RuntimeState;

        readonly RuleTables RuleTables;

        readonly IProjectWs Ws;

        readonly Emitter _Emitter;

        readonly IWfRuntime Wf;

        static int Seq;

        [MethodImpl(Inline)]
        static uint NextId() => (uint)inc(ref Seq);

        const string Identifier = "xed.machine";

        XedMachine(XedRuntime xed)
        {
            Xed = xed;
            Wf = xed.Wf;
            var projects = Projects;
            Ws = projects.Project(projects.ProjectData(), Identifier);
            RuntimeState = new(NextId());
            RuleTables = Xed.Views.RuleTables;
            _Emitter = Emitter.create(this, StatusWriter);

            LoadLookups();
        }

        public void Dispose()
            => _Emitter.Dispose();

        WsProjects Projects => Service(Wf.WsProjects);

        XedRules Rules => Xed.Rules;
    }
}