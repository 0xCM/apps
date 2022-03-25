//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;

    partial class XedRules
    {
        static bool constraint(string input, out FieldKind fk, out string fv)
        {
            fk = 0;
            fv = EmptyString;
            var result = XedParsers.IsCmpNeq(input);
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