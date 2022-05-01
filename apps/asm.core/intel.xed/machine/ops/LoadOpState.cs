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
        public ref readonly OperandState LoadOpState(in FieldBuffer src)
        {
            ref readonly var fields = ref src.Fields;
            State().Asm() = src.AsmInfo;
            State().Class() = src.Detail.Instruction;
            State().Form() = src.Detail.Form;
            State().Rules() = src.State;
            return ref OpState;
        }
    }
}