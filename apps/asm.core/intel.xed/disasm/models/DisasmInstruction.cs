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
        public struct DisasmInstruction
        {
            public InstClass Class;

            public InstForm Form;

            public DisasmProps Props;

            [MethodImpl(Inline)]
            public DisasmInstruction(InstClass @class, InstForm form, DisasmProps props)
            {
                Class = @class;
                Form = form;
                Props = props;
            }

            public static DisasmInstruction Empty => new DisasmInstruction(InstClass.Empty, InstForm.Empty, DisasmProps.Empty);
        }
    }
}