//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedDisasm;

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

            AsmInfo _Asm;

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
                _Asm = AsmInfo.Empty;
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

            [MethodImpl(Inline)]
            public ref InstPattern Pattern()
                => ref _Pattern;

            [MethodImpl(Inline)]
            public ref InstForm Form()
                => ref _Form;

            [MethodImpl(Inline)]
            public ref InstClass Class()
                => ref _Class;

            [MethodImpl(Inline)]
            public ref InstGroupMember Group()
                => ref _Membership;

            [MethodImpl(Inline)]
            public ref OperandState Rules()
                => ref _RuleState;

            [MethodImpl(Inline)]
            public ref AsmInfo Asm()
                => ref _Asm;
        }
    }
}