//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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