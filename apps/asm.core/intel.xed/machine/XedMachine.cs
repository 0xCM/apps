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

        uint MachineId;

        MachineState State;

        RuleTables RuleTables;

        ConstLookup<ushort,InstGroupMember> GroupMembers;

        SortedLookup<InstForm,Index<InstPattern>> _FormPatterns;

        SortedLookup<InstClass,Index<InstPattern>> _ClassPatterns;

        SortedLookup<InstClass,Index<InstForm>> _ClassForms;

        IProjectWs Ws;

        MachineEmitter _Emitter;

        const string Identifier = "xed.machine";

        XedMachine(IWfRuntime wf)
        {
            MachineId = NextId();

            var rules = wf.XedRules();
            State = new();
            RuleTables = rules.CalcRules();
            var patterns = rules.CalcInstPatterns();
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            GroupMembers = members.Select(x => (x.PatternId,x)).ToDictionary();
            _FormPatterns = patterns.FormPatterns();
            _ClassPatterns = patterns.ClassPatterns();
            _ClassForms = patterns.ClassForms();

            var projects = wf.WsProjects();
            Ws = projects.Project(projects.ProjectData(), Identifier);
            _Emitter = new (this);
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
            State.Rules() = src.State;
        }

        public IMachineEmitter Emitter
            => _Emitter;

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
            get => ref State.Group();
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
            => _ClassForms.Find(InstClass, out var dst) ? dst : sys.empty<InstForm>();


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

        public ref RuleState RuleState
        {
            [MethodImpl(Inline)]
            get => ref State.Rules();
        }

        [MethodImpl(Inline)]
        public ref InstPattern Pattern()
        {
            ref var inst = ref State.Pattern();
            State.Group() = GroupMembers[(ushort)inst.PatternId];
            State.Mode() = inst.Mode;
            return ref inst;
        }

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State.Mode();

        [MethodImpl(Inline)]
        TableSpec RuleTable(in RuleSig sig)
        {
            var dst = TableSpec.Empty;
            ref readonly var specs = ref RuleTables.Specs();
            specs.Find(sig,out dst);
            return dst;
        }

        static int Seq;

        [MethodImpl(Inline)]
        static uint NextId() => (uint)inc(ref Seq);
    }
}