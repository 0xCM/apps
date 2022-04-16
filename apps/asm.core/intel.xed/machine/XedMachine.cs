//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;
    using static XedDisasm;
    using static XedMachine;

    partial class XTend
    {
        public static MachineHost XedMachinHost(this IWfRuntime wf)
            => MachineHost.create(wf);
    }

    public partial class XedMachine : IDisposable
    {
        public static XedMachine allocate(IWfRuntime wf)
            => new XedMachine(wf);

        uint _MachineId;

        MachineState _State;

        RuleTables _RuleTables;

        ConstLookup<ushort,InstGroupMember> _GroupMemberLookup;

        SortedLookup<InstClass,Index<InstGroupMember>> _ClassGroupLookup;

        SortedLookup<InstForm,Index<InstPattern>> _FormPatternLookup;

        SortedLookup<InstClass,Index<InstPattern>> _ClassPatternLookup;

        SortedLookup<InstClass,Index<InstForm>> _ClassFormLookup;

        IProjectWs _Ws;

        MachineEmitter _Emitter;

        [MethodImpl(Inline)]
        ref MachineState State()
            => ref _State;

        public ref readonly uint Id
        {
            [MethodImpl(Inline)]
            get => ref _MachineId;
        }

        const string Identifier = "xed.machine";

        XedMachine(IWfRuntime wf)
        {
            _MachineId = NextId();
            var rules = wf.XedRules();
            _State = new();
            _RuleTables = rules.CalcRules();
            var patterns = rules.CalcInstPatterns();
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            _GroupMemberLookup = members.Select(x => (x.PatternId,x)).ToDictionary();
            _FormPatternLookup = patterns.FormPatterns();
            _ClassPatternLookup = patterns.ClassPatterns();
            _ClassFormLookup = patterns.ClassForms();
            _ClassGroupLookup = groups.ClassGroups();
            var projects = wf.WsProjects();
            _Ws = projects.Project(projects.ProjectData(), Identifier);
            _Emitter = new (this, message => wf.Row(typeof(XedMachine),message,FlairKind.Data));
            wf.Babble(string.Format("Logging to {0}", _Emitter.Target.ToUri()));
        }


        public void Dispose()
        {
            _Emitter.Dispose();
        }

        public void Step(in FieldBuffer src)
        {
            ref readonly var fields = ref src.Fields;
            ref readonly var @class = ref src.Detail.InstClass;
            ref readonly var form = ref src.Detail.InstForm;
            _State.Rules() = src.State;
        }

        public IMachineEmitter Emitter
        {
            [MethodImpl(Inline)]
            get => _Emitter;
        }

        public TableSpec NontermOpTable(byte index)
        {
            var dst = TableSpec.Empty;
            ref readonly var op = ref Pattern().Op(index);
            if(op.Nonterminal(out var nonterm))
            {
                dst = RuleTable(new (RuleTableKind.Enc, nonterm.Name));
                if(dst.IsEmpty)
                    dst = RuleTable(new (RuleTableKind.Dec, nonterm.Name));
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public bool IsNontermOp(byte index)
            => Op(index).NonTerm.IsNonEmpty;

        public ref readonly InstGroupMember Group
        {
            [MethodImpl(Inline)]
            get => ref _State.Group();
        }

        public ref readonly InstClass InstClass
        {
            [MethodImpl(Inline)]
            get => ref Pattern().InstClass;
        }

        public ref readonly InstForm InstForm
        {
            [MethodImpl(Inline)]
            get => ref Pattern().InstForm;
        }

        public Index<InstForm> ClassForms
            => _ClassFormLookup.Find(InstClass, out var dst) ? dst : sys.empty<InstForm>();

        public Index<InstGroupMember> ClassGroups
            => _ClassGroupLookup.Find(InstClass, out var dst) ? dst : sys.empty<InstGroupMember>();

        public ref readonly InstFields InstLayout
        {
            [MethodImpl(Inline)]
            get => ref Pattern().Layout;
        }

        public ref readonly Index<InstOpDetail> Ops
        {
            [MethodImpl(Inline)]
            get => ref Pattern().OpDetails;
        }

        [MethodImpl(Inline)]
        public ref readonly InstOpDetail Op(byte index)
            => ref Ops[index];

        public ref readonly Index<OpName> OpNames
        {
            [MethodImpl(Inline)]
            get => ref Pattern().OpNames;
        }

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => (byte)Pattern().Ops.Count;
        }

        public ref readonly FieldSet InstFieldDeps
        {
            [MethodImpl(Inline)]
            get => ref Pattern().FieldDeps;
        }

        public ref readonly InstFields InstExpr
        {
            [MethodImpl(Inline)]
            get => ref Pattern().Expr;
        }

        public ref readonly XedOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => ref Pattern().OpCode;
        }

        public ref readonly InstIsa Isa
        {
            [MethodImpl(Inline)]
            get => ref Pattern().Isa;
        }

        public ref readonly Category Category
        {
            [MethodImpl(Inline)]
            get => ref Pattern().Category;
        }

        public ref readonly Extension Extension
        {
            [MethodImpl(Inline)]
            get => ref Pattern().Extension;
        }

        public ref readonly ushort PatternId
        {
            [MethodImpl(Inline)]
            get => ref @as<uint,ushort>(Pattern().PatternId);
        }

        ref RuleState RuleState
        {
            [MethodImpl(Inline)]
            get => ref State().Rules();
        }

        [MethodImpl(Inline)]
        public ref InstPattern Pattern()
        {
            ref var inst = ref State().Pattern();
            State().Group() = _GroupMemberLookup[(ushort)inst.PatternId];
            State().Mode() = inst.Mode;
            return ref inst;
        }

        public void Transition(Index<InstPattern> seq, Action f)
        {
            for(var i=0; i<seq.Count; i++)
            {
                Pattern() = seq[i];
                f();
            }
        }

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State().Mode();

        [MethodImpl(Inline)]
        TableSpec RuleTable(in RuleSig sig)
        {
            var dst = TableSpec.Empty;
            ref readonly var specs = ref _RuleTables.Specs();
            specs.Find(sig,out dst);
            return dst;
        }

        static int Seq;

        [MethodImpl(Inline)]
        static uint NextId() => (uint)inc(ref Seq);
    }
}