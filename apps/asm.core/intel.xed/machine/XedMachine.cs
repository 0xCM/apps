//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    public class XedMachine
    {
        class MachineState
        {
            InstPattern _Inst;

            RuleState _State;

            MachineMode _Mode;

            InstGroupMember _Membership;

            public MachineState()
            {
                _State = RuleState.Empty;
                _Inst = InstPattern.Empty;
                _Mode = ModeKind.Default;
            }

            [MethodImpl(Inline)]
            public ref InstGroupMember Group()
                => ref _Membership;

            [MethodImpl(Inline)]
            public ref InstPattern Inst()
                => ref _Inst;

            [MethodImpl(Inline)]
            public ref RuleState Encoder()
                => ref _State;

            [MethodImpl(Inline)]
            public ref MachineMode Mode()
                => ref _Mode;
        }

        MachineState State;

        RuleTables RuleTables;

        ConstLookup<ushort,InstGroupMember> GroupMembers;

        [MethodImpl(Inline)]
        Index<RowSpec> RuleTable(in RuleSig sig)
        {
            var dst = Index<RowSpec>.Empty;
            ref readonly var specs = ref RuleTables.RowSpecs();
            specs.Find(sig,out dst);
            return dst;
        }

        public XedMachine(IWfRuntime wf)
        {
            var rules = wf.XedRules();
            State = new();
            RuleTables = rules.CalcRules();
            var patterns = rules.CalcInstPatterns();
            var groups = rules.CalcInstGroups(patterns);
            var members = groups.SelectMany(x => x.Members);
            GroupMembers = members.Select(x => (x.PatternId,x)).ToDictionary();
        }

        public Index<RowSpec> ResolveNontermOp(byte index)
        {
            var dst = Index<RowSpec>.Empty;
            ref readonly var op = ref Inst().Op(index);
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
            get => ref Inst().InstClass;
        }

        public ref readonly InstFields InstLayout
        {
            [MethodImpl(Inline)]
            get => ref Inst().Layout;
        }

        public ref readonly Index<InstOpDetail> Ops
        {
            [MethodImpl(Inline)]
            get => ref Inst().OpDetails;
        }

        [MethodImpl(Inline)]
        public ref readonly InstOpDetail Op(byte index)
            => ref Ops[index];

        public ref readonly Index<OpName> OpNames
        {
            [MethodImpl(Inline)]
            get => ref Inst().OpNames;
        }

        public byte OpCount
        {
            get => (byte)Inst().Ops.Count;
        }

        public ref readonly FieldSet InstFieldDeps
        {
            [MethodImpl(Inline)]
            get => ref Inst().FieldDeps;
        }

        public ref readonly InstFields InstExpr
        {
            [MethodImpl(Inline)]
            get => ref Inst().Expr;
        }

        public ref readonly XedOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => ref Inst().OpCode;
        }

        public ref readonly InstIsa Isa
        {
            [MethodImpl(Inline)]
            get => ref Inst().Isa;
        }

        public ref readonly Category Category
        {
            [MethodImpl(Inline)]
            get => ref Inst().Category;
        }

        public ref readonly Extension Extension
        {
            [MethodImpl(Inline)]
            get => ref Inst().Extension;
        }

        public ref RuleState Encoder
        {
            [MethodImpl(Inline)]
            get => ref State.Encoder();
        }

        [MethodImpl(Inline)]
        public ref InstPattern Inst()
        {
            ref var inst = ref State.Inst();
            State.Group() = GroupMembers[(ushort)inst.PatternId];
            State.Mode() = inst.Mode;
            return ref inst;
        }

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State.Mode();
    }
}