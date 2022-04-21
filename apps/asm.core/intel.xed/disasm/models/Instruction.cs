//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        public readonly record struct Instruction
        {
            public readonly InstructionId Id;

            public readonly asci64 Asm;

            public readonly InstClass Class;

            public readonly InstForm Form;

            public readonly DisasmProps Props;

            [MethodImpl(Inline)]
            public Instruction(InstructionId id, asci64 asm, InstClass @class, InstForm form, DisasmProps props)
            {
                Id = id;
                Asm = asm;
                Class = @class;
                Form = form;
                Props = props;
            }

            public static Instruction Empty => new Instruction(InstructionId.Empty, asci64.Null, InstClass.Empty, InstForm.Empty, DisasmProps.Empty);
        }
    }
}