//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static MachineModes;

    public partial class XedMachine : IDisposable
    {
        ConstLookup<ushort,InstGroupMember> _GroupMemberLookup;

        SortedLookup<InstClass,Index<InstGroupMember>> _ClassGroupLookup;

        SortedLookup<InstClass,Index<InstPattern>> _ClassPatternLookup;

        SortedLookup<InstClass,Index<InstForm>> _ClassFormLookup;

        [MethodImpl(Inline)]
        ref MachineState State()
            => ref RuntimeState;

        void LoadLookups()
        {
            var rules = Rules;
            var patterns = Xed.Views.Patterns;
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            _GroupMemberLookup = members.Select(x => (x.PatternId,x)).ToDictionary();
            _ClassPatternLookup = patterns.ClassPatterns();
            _ClassFormLookup = patterns.ClassForms();
            _ClassGroupLookup = groups.ClassGroups();
        }

        static AppDb AppDb => GlobalSvc.Instance.AppDb;

        public InstGroupMember PatternGroup(ushort id)
            => _GroupMemberLookup.Find(id, out var dst) ? dst : InstGroupMember.Empty;

        public Index<InstForm> ClassForms(InstClass @class)
            => _ClassFormLookup.Find(@class, out var dst) ? dst : sys.empty<InstForm>();

        public Index<InstGroupMember> ClassGroups(InstClass @class)
            => _ClassGroupLookup.Find(@class, out var dst) ? dst : sys.empty<InstGroupMember>();

        public Index<InstPattern> ClassPatterns(InstClass @class)
            => _ClassPatternLookup.Find(@class, out var x) ? x : sys.empty<InstPattern>();

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

        public ref readonly uint Id
        {
            [MethodImpl(Inline)]
            get => ref State().Id;
        }

        public Emitter Emissions
        {
            [MethodImpl(Inline)]
            get => _Emitter;
        }

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State().Mode();

        [MethodImpl(Inline)]
        public ref AddressingKind Addressing()
            => ref State().Addressing();

        internal XedMachine(XedRuntime xed)
        {
            Xed = xed;
            Wf = xed.Wf;
            var projects = Projects;
            Ws = CmdFlows.project(AppDb.DbTargets().Root, Identifier);
            RuntimeState = new(NextId());
            RuleTables = Xed.Views.RuleTables;
            _Emitter = Emitter.create(this, StatusWriter);
            LoadLookups();
        }

        [MethodImpl(Inline)]
        T Service<T>(Func<T> factory)
            => Xed.Service(factory);

        [MethodImpl(Inline)]
        void StatusWriter(object message)
            => Xed.Wf.Row(message,FlairKind.StatusData);

        public void Reset()
        {
            RuntimeState.Reset();
            Emissions.Flush();
        }

        public void Dispose()
            => _Emitter.Dispose();

        WsScripts Projects => Service(Wf.WsScripts);

        XedRules Rules => Xed.Rules;
    }
}