//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedMachine
    {
        class MachineState
        {
            InstPattern _Pattern;

            InstForm _Form;

            InstClass _Class;

            OperandState _RuleState;

            MachineMode _Mode;

            InstGroupMember _Membership;

            Addressing _AddressingMode;

            uint _Id;

            public MachineState(uint id)
            {
                _Id = id;
                Reset();
            }

            public void Reset()
            {
                _RuleState = XedRules.OperandState.Empty;
                _Pattern = XedRules.InstPattern.Empty;
                _Mode = ModeClass.Default;
                _Form = InstForm.Empty;
                _Class = InstClass.Empty;
                _Membership = InstGroupMember.Empty;
            }

            public ref readonly uint Id
            {
                [MethodImpl(Inline)]
                get => ref _Id;
            }

            [MethodImpl(Inline)]
            public ref Addressing Addressing()
                => ref _AddressingMode;

            [MethodImpl(Inline)]
            public ref MachineMode Mode()
                => ref _Mode;
        }
    }
}