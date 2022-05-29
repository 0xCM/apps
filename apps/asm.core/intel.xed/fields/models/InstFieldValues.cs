//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedOps;

    partial class XedRules
    {
        public class InstFieldValues : Dictionary<string,string>
        {
            public readonly InstClass InstClass;

            public readonly InstForm InstForm;

            public InstFieldValues(InstClass @class, InstForm form, Dictionary<string,string> src)
                : base(src)
            {
                InstClass = @class;
                InstForm = form;
            }

            public Index<FieldValue> ParseFields(out OperandState state)
                => FieldParser.parse(this, out state);

            public static InstFieldValues Empty
                => new InstFieldValues(InstClass.Empty, InstForm.Empty, dict<string,string>());
        }
    }
}