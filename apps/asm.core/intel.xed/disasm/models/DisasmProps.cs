//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        public readonly struct DisasmProp
        {
            public readonly string Name;

            public readonly string Value;

            [MethodImpl(Inline)]
            public DisasmProp(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }

        public class DisasmProps : Dictionary<string,string>
        {
            public readonly InstClass Instruction;

            public readonly InstForm Form;

            public DisasmProps(InstClass @class, InstForm form, Dictionary<string,string> src)
                : base(src)
            {
                Instruction = @class;
                Form = form;
            }

            public static DisasmProps Empty
                => new DisasmProps(InstClass.Empty, InstForm.Empty, dict<string,string>());
        }
    }
}