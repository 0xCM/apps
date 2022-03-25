//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldAssign assign<T>(FieldKind field, T fv)
            where T : unmanaged
                => new FieldAssign(XedFields.value(field, fv));

        static bool assign(bool premise, string input, out FieldKind fk, out string fv)
        {
            fk = 0;
            fv = EmptyString;
            var result = XedParsers.IsAssignment(input);
            if(result)
            {
                var i = text.index(input, "=");
                fv = text.right(input, i);
                result = XedParsers.parse(text.left(input, i), out fk);
            }
            return result;
        }
    }
}