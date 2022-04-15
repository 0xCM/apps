//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    public partial class XedMachine
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
            public ref InstPattern Pattern()
                => ref _Inst;

            [MethodImpl(Inline)]
            public ref RuleState Rules()
                => ref _State;

            [MethodImpl(Inline)]
            public ref MachineMode Mode()
                => ref _Mode;
        }
    }
}