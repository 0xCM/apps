//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedOperands
    {
        class MachineState : IMachine
        {
            InstPattern Pattern;

            OperandState OpState;

            MachineMode MachineMode;

            readonly XedRules Rules;

            readonly uint Id;

            static uint Seq;

            public MachineState(XedRules rules)
            {
                Id = core.inc(ref Seq);
                Rules = rules;
                Reset();
            }

            public void Reset()
            {
                OpState = OperandState.Empty;
                Pattern = XedRules.InstPattern.Empty;
                MachineMode = default;
            }

            public void LoadPattern(InstPattern src)
            {
                Reset();
                Pattern = src;
            }

            public ref readonly InstFields Layout
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly InstFields Expr
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Layout;
            }

            public ref readonly uint MachineId
            {
                [MethodImpl(Inline)]
                get => ref Id;
            }

            public ref readonly OperandState Operands
            {
                [MethodImpl(Inline)]
                get => ref OpState;
            }

            public ref readonly MachineMode Mode
            {
                [MethodImpl(Inline)]
                get => ref Pattern.Mode;
            }

            public ref readonly InstPattern InstPattern
            {
                [MethodImpl(Inline)]
                get => ref Pattern;
            }

            public ref readonly InstForm InstForm
            {
                [MethodImpl(Inline)]
                get => ref Pattern.InstForm;
            }

            public ref readonly InstClass InstClass
            {
                [MethodImpl(Inline)]
                get => ref iclass(Operands);
            }
        }
    }
}