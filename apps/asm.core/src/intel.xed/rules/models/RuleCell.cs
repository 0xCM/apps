//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCell
        {
            public readonly FieldKind Field;

            public readonly string Data;

            [MethodImpl(Inline)]
            public RuleCell(FieldKind field, string data)
            {
                Field = field;
                Data = data;
            }

            [MethodImpl(Inline)]
            public RuleCell(string data)
            {
                Field = 0;
                Data = data;
            }

            public string Format()
                => Data;

            public override string ToString()
                => Format();
        }
    }
}