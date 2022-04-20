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
            public readonly InstClass Class;

            public readonly InstForm Form;

            public readonly DisasmProps Props;

            [MethodImpl(Inline)]
            public Instruction(InstClass @class, InstForm form, DisasmProps props)
            {
                Class = @class;
                Form = form;
                Props = props;
            }

            public static Instruction Empty => new Instruction(InstClass.Empty, InstForm.Empty, DisasmProps.Empty);
        }
    }
}