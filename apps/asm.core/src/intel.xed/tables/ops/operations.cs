//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules;
    using static XedParsers;

    partial class XedRuleTables
    {
        static bool assignment(bool premise, string input, out FieldKind fk, out string fv)
        {
            fk = 0;
            fv = EmptyString;
            var result = IsAssignment(input);
            if(result)
            {
                var i = text.index(input, "=");
                fv = text.right(input, i);
                result = XedParsers.parse(text.left(input, i), out fk);
            }
            return result;
        }

        static bool notequal(string input, out FieldKind fk, out string fv)
        {
            fk = 0;
            fv = EmptyString;
            var result = IsCmpNeq(input);
            if(result)
            {
                var i = text.index(input, "!=");
                fv = text.right(input, i + 1);
                result = XedParsers.parse(text.left(input, i), out fk);
            }
            return result;
        }
    }
}