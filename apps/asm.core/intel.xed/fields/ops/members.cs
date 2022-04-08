//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static FieldSet members(bool premise, in RuleTable src)
        {
            var dst = FieldSet.create();
            for(var i=0; i<src.RowCount; i++)
                include(premise, src[i], ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FieldSet members(in RuleTable src)
        {
            var dst = FieldSet.create();
            include(src, ref dst);
            return dst;
        }
    }
}