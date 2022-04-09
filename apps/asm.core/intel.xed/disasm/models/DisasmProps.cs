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
    using static XedPatterns;

    partial class XedDisasm
    {
        public class DisasmProps : Dictionary<string,string>
        {
            public static DisasmProps load(InstClass @class, InstForm form, Index<Facet<string>> src)
            {
                var dst = dict<string,string>();
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var kvp = ref src[i];
                    dst.Add(kvp.Key, kvp.Value);
                }
                return new DisasmProps(@class,form,dst);
            }

            public InstClass Instruction {get;}

            public InstForm Form {get;}

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