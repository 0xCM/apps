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
        [MethodImpl(Inline)]
        ref MachineState State()
            => ref RuntimeState;

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State().Mode();

        [MethodImpl(Inline)]
        public ref Addressing Addressing()
            => ref State().Addressing();

        [MethodImpl(Inline)]
        public ref InstPattern InstPattern()
        {
            ref var pattern = ref State().Pattern();
            State().Mode() = pattern.Mode;
            State().Group() = PatternGroup;
            State().Class() = pattern.InstClass;
            State().Form() = pattern.InstForm;
            return ref pattern;
        }

        public ref readonly OperandState Load(in FieldBuffer src)
        {
            ref readonly var fields = ref src.Fields;
            State().Asm() = src.AsmInfo;
            State().Class() = src.Detail.Instruction;
            State().Form() = src.Detail.Form;
            State().Rules() = src.State;
            return ref RuleState;
        }
    }
}